using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject chaserPrefab;
    [SerializeField] private GameObject randomPrefab;
    [SerializeField] private GameObject staticPrefab;

    [SerializeField] private float chaserInterval = 2.5f;
    [SerializeField] private float randomInterval = 1;
    [SerializeField] private float staticInterval = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(chaserInterval, chaserPrefab));
        StartCoroutine(spawnEnemy(randomInterval, randomPrefab));
        StartCoroutine(spawnEnemy(staticInterval, staticPrefab));                
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-8f, 8f), Random.Range(-8f, 8f), 0), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
        
    }
}
