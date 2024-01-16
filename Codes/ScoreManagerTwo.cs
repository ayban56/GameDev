using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManagerTwo : MonoBehaviour
{
    public static ScoreManagerTwo Instance;

    public Text scoreText;
    public Text evolveText;
    public Text gameOverText;
    public GameObject[] playerFishPrefabs;

    private int score = 0;
    private int evolveCount = 0;
    private GameObject currentFish;
    private PlayerFishStateTwo currentFishState;
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

        if (score >= 9)
        {
            SceneManager.LoadSceneAsync(2);
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
            evolveText.text = "Evolve " + evolveCount + "/10";
        }
    }

    void SpawnPlayerFish()
{
    // Destroy the current player fish
    if (currentFish != null)
    {
        Destroy(currentFish);
    }

    // Instantiate the new player fish
    currentFish = Instantiate(playerFishPrefabs[evolveCount], transform.position, Quaternion.identity);
    currentFish.AddComponent<FishMovement>();
    currentFish.AddComponent<FishCollision>();
}



}

public class PlayerFishStateTwo : MonoBehaviour
{
    public int score;
    public int evolveCount;
}
