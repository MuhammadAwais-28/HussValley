using System;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class ChaserAI : MonoBehaviour
{
    public static event Action OnPlayerCaught;

    [Header("Movement")]
    [SerializeField] private float baseSpeed = 0.8f;
    [SerializeField] private float acceleration = 4f;
    [SerializeField] private float repathInterval = 0.3f;


    [Header("Formation")]
    [SerializeField] private float formationRange = 2f; // inside this distance the row closes in on the player

    private Vector3 sideDir;
    private float sideOffset;

    [Header("Difficulty Speed Multiplier")]
    [SerializeField] private float normalMultiplier = 0.5f;
    [SerializeField] private float mediumMultiplier = 0.6f;
    [SerializeField] private float hardMultiplier = 0.7f;

    [Header("Lane Behaviour")]
    [SerializeField] private float lockRange = 1.2f;   // within this distance it turns and chases the player

    [Header("Catch")]
    [SerializeField] private float catchDistance = 0.3f;

    [Header("Optional")]
    [SerializeField] private Animator animator;

    private NavMeshAgent agent;
    private Transform target;
    private Vector3 laneEnd;
    private float repathTimer;
    private float releaseTime;
    private bool active;
    private bool caught;
    private bool locked;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        if (animator == null) animator = GetComponentInChildren<Animator>();
    }

    public void Init(Transform player, float delay, Vector3 laneDestination, Vector3 side, float offset)
    {
        sideDir = side;
        sideOffset = offset;
        target = player;
        laneEnd = laneDestination;
        releaseTime = Time.time + delay;

        float mult = normalMultiplier;
        switch (GameSession.SelectedMode)
        {
            case GameMode.Medium: mult = mediumMultiplier; break;
            case GameMode.Hard: mult = hardMultiplier; break;
        }

        agent.speed = baseSpeed * mult;
        agent.acceleration = acceleration;
        agent.stoppingDistance = 0f;
        agent.autoBraking = false;
        agent.obstacleAvoidanceType = ObstacleAvoidanceType.NoObstacleAvoidance;

        active = true;
        caught = false;
        locked = false;
    }

    private void Update()
    {
        if (!active || caught || target == null) return;

        if (Time.time < releaseTime) { SetAnim(0f); return; }

        Vector3 toPlayer = target.position - transform.position;
        toPlayer.y = 0f;
        float distToPlayer = toPlayer.magnitude;

        Vector3 toLaneEnd = laneEnd - transform.position;
        toLaneEnd.y = 0f;

        if (!locked && (distToPlayer <= lockRange || toLaneEnd.magnitude < 0.5f))
            locked = true;

        repathTimer -= Time.deltaTime;
        if (repathTimer <= 0f)
        {
            repathTimer = repathInterval;
            if (agent.isOnNavMesh)
                agent.SetDestination(locked ? GetChaseDestination(distToPlayer) : laneEnd);
        }

        SetAnim(agent.velocity.magnitude);

        if (distToPlayer <= catchDistance)
            CatchPlayer();
    }

    private void CatchPlayer()
    {
        if (caught) return;
        caught = true;
        Debug.Log("Player is caught by " + gameObject.name);
        Stop();
        OnPlayerCaught?.Invoke();
    }

    public void Stop()
    {
        active = false;
        if (agent != null && agent.isOnNavMesh)
        {
            agent.isStopped = true;
            agent.velocity = Vector3.zero;
        }
        SetAnim(0f);
    }

    private void SetAnim(float speed)
    {
        if (animator != null) animator.SetFloat("Speed", speed);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, catchDistance);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, lockRange);
    }

    private Vector3 GetChaseDestination(float distToPlayer)
    {
        // Full side spacing while far away, shrinking to 0 inside formationRange
        float t = Mathf.Clamp01(distToPlayer / formationRange);
        Vector3 dest = target.position + sideDir * (sideOffset * t);

        if (NavMesh.SamplePosition(dest, out NavMeshHit hit, 1f, NavMesh.AllAreas))
            return hit.position;

        return target.position; // fallback if the offset point is off the NavMesh
    }
}