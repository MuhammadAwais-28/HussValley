using System;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class ChaserAI : MonoBehaviour
{
    // Listen to this from your Round/UI manager to show "Round Failed"
    public static event Action OnPlayerCaught;

    [Header("Movement")]
    [SerializeField] private float baseSpeed = 5f;
    [SerializeField] private float acceleration = 12f;
    [SerializeField] private float repathInterval = 0.2f;

    [Header("Difficulty Speed Multiplier")]
    [SerializeField] private float normalMultiplier = 0.85f;
    [SerializeField] private float mediumMultiplier = 0.95f;
    [SerializeField] private float hardMultiplier = 1.05f;

    [Header("Catch")]
    [SerializeField] private float catchDistance = 1.5f;

    [Header("Optional")]
    [SerializeField] private Animator animator; // needs a float param "Speed"

    private NavMeshAgent agent;
    private Transform target;
    private float repathTimer;
    private float releaseTime;
    private bool active;
    private bool caught;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        if (animator == null)
            animator = GetComponentInChildren<Animator>();
    }

    public void Init(Transform player, float delay)
    {
        target = player;
        releaseTime = Time.time + delay;

        float mult = normalMultiplier;
        switch (GameSession.SelectedMode)
        {
            case GameMode.Medium: mult = mediumMultiplier; break;
            case GameMode.Hard: mult = hardMultiplier; break;
        }

        agent.speed = baseSpeed * mult;
        agent.acceleration = acceleration;
        agent.stoppingDistance = catchDistance * 0.5f;
        agent.autoBraking = false;

        active = true;
        caught = false;
    }

    private void Update()
    {
        if (!active || caught || target == null) return;

        if (Time.time < releaseTime)
        {
            SetAnim(0f);
            return;
        }

        repathTimer -= Time.deltaTime;
        if (repathTimer <= 0f)
        {
            repathTimer = repathInterval;
            if (agent.isOnNavMesh) agent.SetDestination(target.position);
        }

        SetAnim(agent.velocity.magnitude);

        Vector3 flat = target.position - transform.position;
        flat.y = 0f;
        if (flat.magnitude <= catchDistance)
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
}