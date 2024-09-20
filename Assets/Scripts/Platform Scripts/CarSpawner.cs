using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> cars = new List<GameObject>();
    [SerializeField] float startDelay = 0;
    [SerializeField] float spawnDelay = 0;
    private float spawnTimer = 0;


    private void Update()
    {
        if (startDelay > 0)
        {
            startDelay -= Time.deltaTime;
            return;
        }

        if (spawnTimer > 0)
        {
            spawnTimer -= Time.deltaTime;
            return;
        }

        SpawnCar();
    }

    private void SpawnCar()
    {
        Vector3 spawnPosition = transform.position + new Vector3(Random.Range(-1f, 0f), 0, 0);
        Instantiate(cars[Random.Range(0, cars.Count)], spawnPosition, Quaternion.identity, transform);
        spawnTimer = spawnDelay;
    }
}
