using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public Text scoreText;
    public Text evolveText;
    public Text gameOverText;
    public GameObject[] playerFishPrefabs;

    public int requiredPointsForLevel = 10;
    public int nextScene = 0;

    private int score = 0;
    private int evolveCount = 0;
    private GameObject currentFish;
    private PlayerFishState currentFishState;
    private bool isGameOver = false;
    
    private BackgroundMovement backgroundMovement;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateScoreText();
        UpdateEvolveText();

        backgroundMovement = FindObjectOfType<BackgroundMovement>();
    }

    public void IncreaseScore()
    {
        if (isGameOver)
        {
            return;
        }

        if (evolveCount >= 5)
        {
            evolveCount = 0;

            Destroy(currentFish);

            SpawnPlayerFish();
        }

        score++;
        evolveCount++;

        UpdateScoreText();
        UpdateEvolveText();

        if (score >= requiredPointsForLevel)
        {
            LoadNextLevel();
        }
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    private void UpdateEvolveText()
    {
        if (evolveText != null)
        {
            evolveText.text = "Evolve " + evolveCount + "/5";
        }
    }

    void SpawnPlayerFish()
{
    gameObject.SetActive(false);

    // Instantiate the player fish
    currentFish = Instantiate(playerFishPrefabs[evolveCount], transform.position, Quaternion.identity);
    FishMovement fishMovement = currentFish.AddComponent<FishMovement>();

    // Find all enemy fish with the "EnemyFish" tag
    GameObject[] enemyFishArray = GameObject.FindGameObjectsWithTag("EnemyFish");

    foreach (GameObject enemyFish in enemyFishArray)
    {
        // Change the tag of enemy fish to "EatenFish"
        enemyFish.tag = "EatenFish";
    }
}


    void LoadNextLevel()
    {
        
        SceneManager.LoadSceneAsync(nextScene); // Load the next level scene.
    }

    public void GameOver()
    {
        isGameOver = true;
        // Update your UI or perform any other game over actions
        if (gameOverText != null)
        {
            gameOverText.text = "Game Over";
        }
    }
}

public class PlayerFishState : MonoBehaviour
{
    public int score;
    public int evolveCount;
}
