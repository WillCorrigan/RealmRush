using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float secondsBetweenSpawns = 1f;
    [SerializeField] int enemiesToSpawn = 10;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Transform enemyParentTransform;
    [SerializeField] Text spawnedEnemies;
    [SerializeField] AudioClip spawnedEnemySFX;
    int score = 0;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RepeatedlySpawnEnemies());
        spawnedEnemies.text = score.ToString();
    }


    IEnumerator RepeatedlySpawnEnemies()
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            AddScore();
            GetComponent<AudioSource>().PlayOneShot(spawnedEnemySFX);
            var newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            newEnemy.transform.parent = enemyParentTransform.transform;
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }

    private void AddScore()
    {
        score++;
        spawnedEnemies.text = score.ToString();
    }
}
