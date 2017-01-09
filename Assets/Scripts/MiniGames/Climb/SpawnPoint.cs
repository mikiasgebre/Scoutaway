using System.Collections.Generic;
using UnityEngine;

public enum SpawnMode
{
    SpawnByDistanceXY,
    SpawnByDistanceX,
    SpawnByDistanceY,
    SpawnByTime
}

public class SpawnPoint : MonoBehaviour
{
    public bool SpawnAtStart;
    public SpawnMode SpawningMode;
    [Tooltip("Minimum distance before the desired gameobject may spawn")]
    public float MinSpawnDistance;
    [Tooltip("Maximum distance before the desired gameobject may spawn")]
    public float MaxSpawnDistance;
    [Tooltip("How many times this script will spawn an item. -1 for infinite.")]
    public int TimesToSpawn = -1;
    public List<GameObject> ObjectsToSpawn;
    [Tooltip("Chance to spawn gameobject (0-100)")]
    public List<float> ChanceToSpawn;
    public bool SpawnAsChild;
    public float MinSpawnTime;
    public float MaxSpawnTime;
    private int randomObject;
    private float timer;
    private Vector3 startPosition;
    private float spawnRoll;
    private bool hasSpawned;
    private bool objectNotSpawnedOnce = true;
    private float totalChanceToSpawn;
    private GameObject spawnedObject = null;
    private float spawnDistance;

    public void SpawnObject()
    {
        spawnDistance = Random.Range(MinSpawnDistance, MaxSpawnDistance);
        if (TimesToSpawn != 0)
        {
            spawnRoll = Random.Range(0, totalChanceToSpawn);
            for (int i = 0; i < ObjectsToSpawn.Count; i++)
            {
                spawnRoll -= ChanceToSpawn[i];
                if (spawnRoll < 0)
                {
                    if (ObjectsToSpawn[i] != null)
                    {
                        spawnedObject = (GameObject)Instantiate(ObjectsToSpawn[i], transform.position, transform.rotation);
                        if (SpawnAsChild)
                        {
                            spawnedObject.transform.parent = gameObject.transform;
                        }

                        if (TimesToSpawn > 0)
                        {
                            TimesToSpawn--;
                        }
                    }
                    else
                    {
                        Debug.LogWarning("'Objects To Spawn' list has empty cells.");
                    }

                    break;
                }
            }
        }
    }

    private void Start()
    {
        totalChanceToSpawn = 0;
        for (int i = 0; i < ChanceToSpawn.Count; i++)
        {
            totalChanceToSpawn += ChanceToSpawn[i];
        }

        if (totalChanceToSpawn < 100)
        {
            totalChanceToSpawn = 100;
        }

        startPosition = transform.position;
        timer = Random.Range(MinSpawnTime, MaxSpawnTime);
        if (SpawnAtStart)
        {
            SpawnObject();
        }
    }

    protected void Update()
    {
        if (SpawningMode == SpawnMode.SpawnByDistanceXY && (transform.position - startPosition).magnitude > spawnDistance)
        {
            startPosition = transform.position;
            SpawnObject();
        }
        else if (SpawningMode == SpawnMode.SpawnByDistanceX && (transform.position.x - startPosition.x) > spawnDistance)
        {
            startPosition = transform.position;
            SpawnObject();
        }
        else if (SpawningMode == SpawnMode.SpawnByDistanceY && (transform.position.y - startPosition.y) > spawnDistance)
        {
            startPosition = transform.position;
            SpawnObject();
        }
        else if (SpawningMode == SpawnMode.SpawnByTime)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = Random.Range(MinSpawnTime, MaxSpawnTime);
                SpawnObject();
            }
        }
    }
}