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
            // Increase the score
            ScoreManager.Instance.IncreaseScore();

            // Destroy the enemy fish
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("EnemyFish"))
        {
            // Handle collision with enemy fish (e.g., destroy the player)
            HandlePlayerCollision();
        }
    }

    private void HandlePlayerCollision()
    {
        // Add any additional logic you want for player collision (e.g., game over)
        // For now, destroy the player
        Destroy(gameObject);
        
         ScoreManager.Instance.GameOver();
        // You might want to add additional logic here, such as showing a game over screen or restarting the level.
        // Example: GameManager.Instance.GameOver();
    }
}
