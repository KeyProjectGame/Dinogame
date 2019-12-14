using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] spawnObject;
    [SerializeField] float xSpawnStart = 17;
    [SerializeField] float xSpawnEnd = 19;
    [SerializeField] float ySpawnStart = 5f;
    [SerializeField] float ySpawnEnd = 6.2f;
    private float spawnDelay = 2;
    [SerializeField] float spawnInterval = 5f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObjects", spawnDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObjects()
    {
        // Set random spawn location and random object index
        int index = Random.Range(0, spawnObject.Length);
        Vector2 spawnLocation = new Vector2(Random.Range(xSpawnStart, xSpawnEnd), Random.Range(ySpawnStart, ySpawnEnd));

        // If game is still active, spawn new object
        
            Instantiate(spawnObject[index], spawnLocation, spawnObject[index].transform.rotation);

    }
}
