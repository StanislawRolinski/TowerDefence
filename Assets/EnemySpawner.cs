using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject parent;
    [SerializeField] float timeBetweenSpawns = 3f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            Instantiate(enemy, transform.position, Quaternion.identity, parent.transform);
            yield return new WaitForSeconds(timeBetweenSpawns);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
