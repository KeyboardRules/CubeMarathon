using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlane : MonoBehaviour
{
    public Plane[] planeObstacles;
    public float obstacleSpeed;
    public float existTime;
    public float spawnTime;

    float countSpawn;
    private void Awake()
    {
        countSpawn = spawnTime;
    }
    private void Update()
    {
        if (countSpawn >= spawnTime)
        {
            GameObject obstaclePlane = Instantiate(planeObstacles[Random.Range(0, planeObstacles.Length)].gameObject, transform.position, Quaternion.identity);
            obstaclePlane.GetComponent<Plane>().speed = obstacleSpeed;
            Destroy(obstaclePlane, existTime);
            countSpawn = 0;
        }
        countSpawn += Time.deltaTime;
    }
}
