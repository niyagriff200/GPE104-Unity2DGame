using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    public void StartButton()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.ShowGameplay();
        }
    }

    public void ExitButton()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.QuitGame();
        }
    }
}
