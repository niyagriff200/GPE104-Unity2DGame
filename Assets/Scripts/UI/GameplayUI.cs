using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameplayUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public Image healthBar;

    private void Update()
    {
        scoreText.text = "Score: " + GameManager.instance.score.ToString("0000");

        Health health = GameManager.instance.players[0].pawn.health;
        healthBar.fillAmount = health.PercentHealth();
    }
}
