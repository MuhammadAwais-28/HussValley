using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaserSpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject chaserPrefab;
    [SerializeField] private Transform player;
    [SerializeField] private Transform[] spawnPoints;

    [Header("Settings")]
    [SerializeField] private bool spawnOnStart = true;
    [SerializeField] private float releaseDelay = 3f;     // seconds before chasers start hunting
    [SerializeField] private float spawnSpreadRadius = 2f; // used if spawn points < chaser count

    private readonly List<ChaserAI> activeChasers = new List<ChaserAI>();

    private void Start()
    {
        if (spawnOnStart) SpawnChasers();
    }

    public void SpawnChasers()
    {
        ClearChasers();

        int count = GameSession.ChaserCount;

        for (int i = 0; i < count; i++)
        {
            Vector3 pos = GetSpawnPosition(i);

            GameObject obj = Instantiate(chaserPrefab, pos, Quaternion.identity);
            ChaserAI chaser = obj.GetComponent<ChaserAI>();
            chaser.Init(player, releaseDelay);
            activeChasers.Add(chaser);
        }
    }

    private Vector3 GetSpawnPosition(int index)
    {
        Vector3 basePos = transform.position;

        if (spawnPoints != null && spawnPoints.Length > 0)
        {
            Transform sp = spawnPoints[index % spawnPoints.Length];
            basePos = sp.position;

            // If we reuse a spawn point, spread them out so they don't stack
            if (index >= spawnPoints.Length)
            {
                Vector2 offset = Random.insideUnitCircle * spawnSpreadRadius;
                basePos += new Vector3(offset.x, 0f, offset.y);
            }
        }

        if (NavMesh.SamplePosition(basePos, out NavMeshHit hit, 5f, NavMesh.AllAreas))
            return hit.position;

        Debug.LogWarning("ChaserSpawner: spawn point not near NavMesh, using raw position.");
        return basePos;
    }

    public void StopAllChasers()
    {
        foreach (var c in activeChasers)
            if (c != null) c.Stop();
    }

    public void ClearChasers()
    {
        foreach (var c in activeChasers)
            if (c != null) Destroy(c.gameObject);
        activeChasers.Clear();
    }
}