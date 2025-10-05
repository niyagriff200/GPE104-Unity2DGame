using UnityEngine;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    private void Update()
    {
        if (GameManager.instance != null)
        {
            scoreText.text = "Score: " + GameManager.instance.score.ToString("0000");
            highScoreText.text = "High Score: " + GameManager.instance.topScore.ToString("0000");
        }
    }

    public void PlayAgainButton()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.ShowGameplay();
        }
    }

    public void MainMenuButton()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.ShowMainMenu();
        }
    }
}
