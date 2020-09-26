using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float secondBetweenSpawns = 1f;
    [SerializeField] int enemiesToSpawn = 5;
    [SerializeField] GameObject enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawning());
    }


    IEnumerator Spawning()
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            var newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            newEnemy.transform.parent = gameObject.transform;
            yield return new WaitForSeconds(secondBetweenSpawns);
        }
    }
}
