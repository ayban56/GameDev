using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour
{
    public float spawnInterval = 3f;
    public float spawnIntervalTwo = 4f;
    public float speed = 5f;
    public float verticalBound = 4f;
    public float horizontalBound = 9f;

    

    
    void Start()
    {
      
        StartCoroutine(SpawnEnemyFish());
          StartCoroutine(SpawnEatenFish());
    }

    
    void Update()
    {
       
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

      
        Vector2 movement = new Vector2(horizontalInput, verticalInput);

       
        transform.Translate(movement * speed * Time.deltaTime);

     
        Vector3 clampedPosition = transform.position;
        clampedPosition.y = Mathf.Clamp(transform.position.y, -verticalBound, verticalBound);
        clampedPosition.x = Mathf.Clamp(transform.position.x, -horizontalBound, horizontalBound);
        transform.position = clampedPosition;
    }

   IEnumerator SpawnEnemyFish()
    {
        while (true)
        {
            
            float camHeight = Camera.main.orthographicSize;
            float camWidth = camHeight * Camera.main.aspect;

            
            Vector3 playerPosition = transform.position;

            
            float spawnXPosition = playerPosition.x + camWidth + 10f;

            
            float spawnYPosition = Random.Range(playerPosition.y - camHeight, playerPosition.y + camHeight);

           
            GameObject[] enemyFishPrefabs = GameObject.FindGameObjectsWithTag("EnemyFish");

            if (enemyFishPrefabs.Length > 0)
            {
               
                GameObject selectedEnemyFishPrefab = enemyFishPrefabs[Random.Range(0, enemyFishPrefabs.Length)];

               
                Vector3 spawnPosition = new Vector3(spawnXPosition, spawnYPosition, 0f);
                Instantiate(selectedEnemyFishPrefab, spawnPosition, Quaternion.identity);
            }
            else
            {
                Debug.LogWarning("No enemy fish prefabs found with the 'EnemyFish' tag.");
            }

           
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    IEnumerator SpawnEatenFish()
    {
        while (true)
        {
            float camHeight = Camera.main.orthographicSize;
            float camWidth = camHeight * Camera.main.aspect;
            Vector3 playerPosition = transform.position;
            float spawnXPosition = playerPosition.x + camWidth + 10f;
            float spawnYPosition = Random.Range(playerPosition.y - camHeight, playerPosition.y + camHeight);

            GameObject[] eatenFishPrefabs = GameObject.FindGameObjectsWithTag("EatenFish");

            if (eatenFishPrefabs.Length > 0)
            {
                GameObject selectedEatenFishPrefab = eatenFishPrefabs[Random.Range(0, eatenFishPrefabs.Length)];
                Vector3 spawnPosition = new Vector3(spawnXPosition, spawnYPosition, 0f);
                Instantiate(selectedEatenFishPrefab, spawnPosition, Quaternion.identity);
            }
            else
            {
                Debug.LogWarning("No eaten fish prefabs found with the 'EatenFish' tag.");
            }

            yield return new WaitForSeconds(spawnIntervalTwo);
        }
    }
}
