using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptForEnd : MonoBehaviour
{
    public GameObject enemyFishPrefab;
    public float spawnInterval = 5f;

   
    void Start()
    {
        StartCoroutine(SpawnEnemyFish());
    }

   
    void Update()
    {
       
    }

    IEnumerator SpawnEnemyFish()
    {
        while (true)
        {
          
            float playerYPosition = Random.Range(-2f, 2f); 

            
            Vector3 spawnPosition = new Vector3(transform.position.x + 5f, playerYPosition, 0f);
            GameObject enemyFish = Instantiate(enemyFishPrefab, spawnPosition, Quaternion.identity);

          
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
