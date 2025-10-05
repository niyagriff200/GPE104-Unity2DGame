using UnityEngine;
using TMPro;

public class AddedPointsUI : MonoBehaviour
{
    public TextMeshProUGUI pointsText;
    public float duration = 0.5f;

    private float timer = 0f;
    private bool isShowing = false;

    public void ShowPoints(int amount)
    {
        pointsText.text = "+" + amount.ToString();
        gameObject.SetActive(true);
        timer = 0f;
        isShowing = true;
    }

    private void Update()
    {
        if (!isShowing) return;

        timer += Time.deltaTime;

        if (timer >= duration)
        {
            gameObject.SetActive(false);
            isShowing = false;
        }
    }
}
