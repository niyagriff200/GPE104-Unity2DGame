using UnityEngine;

public class QuitGame : MonoBehaviour
{  
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("The player has quit the game.");
            //When the player pushes down on esc key, they will quit the application
            Application.Quit();
        }
    }
}
