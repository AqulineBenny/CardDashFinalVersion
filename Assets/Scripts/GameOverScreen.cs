using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    public GameObject gameOverPanel;
    public TextMeshProUGUI scoreText;
    public Button tryAgainButton;

    private void Start()
    {
        gameOverPanel.SetActive(false);
        tryAgainButton.onClick.AddListener(RestartGame);
    }

    public void ShowGameOverScreen(int score)
    {
        gameOverPanel.SetActive(true);
        scoreText.text = "Score: " + score.ToString();
        Time.timeScale = 0; // Pause the game
    }

    void RestartGame()
    {
        gameOverPanel.SetActive(false);
        Time.timeScale = 1;

        PlayerController playerController = FindObjectOfType<PlayerController>();
        if (playerController != null)
        {
            playerController.ResetPlayerPosition();
            playerController.ResetScore();
        }

        RockSpawner rockSpawner = FindObjectOfType<RockSpawner>();
        if (rockSpawner != null)
        {
            rockSpawner.ResetSpawning();
        }

        CoinSpawner coinSpawner = FindObjectOfType<CoinSpawner>();
        if (coinSpawner != null)
        {
            coinSpawner.ResetSpawning();
        }
    }
}
