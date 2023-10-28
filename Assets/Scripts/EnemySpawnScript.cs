using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnScript : MonoBehaviour
{
    public GameObject Enemy;
    public float spawnRate;
    private float timer = 0;
    public float offset;

    void Start()
    {
    }

    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            float lowestPoint = transform.position.y - offset;
            float highestPoint = transform.position.y + offset;
            Instantiate(Enemy, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
            timer = 0;
        }
    }
}
