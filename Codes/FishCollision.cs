using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishCollision : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EatenFish"))
        {
            
            ScoreManager.Instance.IncreaseScore();

           
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("EnemyFish"))
        {
           
            HandlePlayerCollision();
        }
    }

    private void HandlePlayerCollision()
    {
        
        Destroy(gameObject);
        
         ScoreManager.Instance.GameOver();
       
    }
}
