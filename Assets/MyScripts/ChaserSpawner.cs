using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaserSpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject chaserPrefab;
    [SerializeField] private Transform player;
    [SerializeField] private Transform startLine;      // empty object at the player's start line
    [SerializeField] private Transform[] spawnPoints;  // only their average position is used

    [Header("Settings")]
    [SerializeField] private bool spawnOnStart = true;
    [SerializeField] private float releaseDelay = 1f;
    [SerializeField] private float laneOvershoot = 3f; // how far past the start line each lane ends
    [SerializeField] private float laneSpacing = 0.5f; // gap between neighbouring chasers

    private readonly List<ChaserAI> activeChasers = new List<ChaserAI>();

    private void Start()
    {
        if (spawnOnStart) SpawnChasers();
    }

    public void SpawnChasers()
    {
        ClearChasers();

        if (spawnPoints == null || spawnPoints.Length == 0 || startLine == null)
        {
            Debug.LogWarning("ChaserSpawner: assign Spawn Points and Start Line.");
            return;
        }

        Vector3 center = Vector3.zero;
        foreach (var sp in spawnPoints) center += sp.position;
        center /= spawnPoints.Length;

        Vector3 axis = startLine.position - center;
        axis.y = 0f;
        axis.Normalize();
        Vector3 side = Vector3.Cross(Vector3.up, axis);

        int count = GameSession.ChaserCount;

        for (int i = 0; i < count; i++)
        {
            float offset = (i - (count - 1) * 0.5f) * laneSpacing;
            Vector3 spawnPos = SnapToNavMesh(center + side * offset);

            float along = Vector3.Dot(startLine.position - spawnPos, axis) + laneOvershoot;
            Vector3 laneEnd = SnapToNavMesh(spawnPos + axis * along);

            GameObject obj = Instantiate(chaserPrefab, spawnPos, Quaternion.LookRotation(axis));
            ChaserAI chaser = obj.GetComponent<ChaserAI>();
            chaser.Init(player, releaseDelay, laneEnd, side, offset);
            activeChasers.Add(chaser);
        }
    }

    private Vector3 SnapToNavMesh(Vector3 pos)
    {
        if (NavMesh.SamplePosition(pos, out NavMeshHit hit, 5f, NavMesh.AllAreas))
            return hit.position;

        Debug.LogWarning("ChaserSpawner: point not near NavMesh: " + pos);
        return pos;
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