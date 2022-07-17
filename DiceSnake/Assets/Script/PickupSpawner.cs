using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    public Pickup[] pickups;
    public float[] spawnRates;

    private float SpawnTime = 5f;
    private float SpawnTimeStamp = 0f;

    private int SpawnNumbers = 2;

    private void Update()
    {
        if (Time.time-SpawnTimeStamp >= SpawnTime)
        {
            for (int i = 0; i < SpawnNumbers; i++)
            {
                SpawnRandom();
            }

            SpawnTimeStamp = Time.time;
        }
    }

    private void SpawnRandom()
    {
        float rand = Random.Range(0f, 1f);
        float r = spawnRates[0];
        int n = 0;

        while (r < rand)
        {
            n++;
            r += spawnRates[n];
        }

        if (n == -1) n = 0;

        GridCell gc = GridManager.GetRandomFreeCell();

        gc.changeContent(Instantiate(pickups[n], gc.anchor.position, Quaternion.identity));
    }
}