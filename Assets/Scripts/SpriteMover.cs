using UnityEngine;

public class SpriteMover : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            Debug.Log("The ship has moved");
        }
        else
        {
            Debug.Log("The ship has not moved");
        }
    }
}
