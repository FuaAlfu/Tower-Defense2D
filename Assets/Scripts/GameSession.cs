using UnityEngine;
using TMPro;

/// <summary>
/// 2023.9.12
/// </summary>

public class GameSession : MonoBehaviour
{
    private int score = 0;
    private int currentScore;
    private bool isGameOver = false;
    private static GameSession instance;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI titleText;

    public static GameSession Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameSession>();
                if (instance == null)
                {
                    GameObject gameSessionObject = new GameObject("GameSession");
                    instance = gameSessionObject.AddComponent<GameSession>();
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void Start()
    {
        UpdateUI();
        currentScore = score;
    }

    private void Update()
    {
        // To retrieve the highest score:
        int highestScore = HighScore.Instance.highestScore;

        // To update the highest score (for example, when the player achieves a new high score):
        int newScore = highestScore; // Replace with the actual new score.
        HighScore.Instance.UpdateHighScore(newScore);
        highScoreText.text = "High Score: " + highestScore;

    }

    public int GetScore()
    {
        return score;
    }

    public void AddToScore(int points)
    {
        if (!isGameOver)
        {
            score += points;
            UpdateUI();
        }
    }

    public void GameOver(bool hasWon)
    {
        isGameOver = true;

        if (hasWon)
        {
            titleText.text = "You Win!";
        }
        else
        {
            titleText.text = "You Lose!";
        }

        // Show or hide relevant UI elements here.
    }

    public void ResetGame()
    {
        score = 0;
        isGameOver = false;
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }
}
