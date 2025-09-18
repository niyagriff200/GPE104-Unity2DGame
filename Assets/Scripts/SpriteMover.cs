using UnityEngine;

public class SpriteMover : MonoBehaviour
{

    //Float variables for the range of X (Can be changed in editor)
    public float minX;
    public float maxX;

    //Float variables for the range of Y (Can be changed in editor)
    public float minY;
    public float maxY;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //If the player presses down on the Space Key, move a to a random position in range (minX, maxX) and (minY, maxY)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Update in console
           Debug.Log("The ship HAS moved");

           Transform player = GetComponent<Transform>();

           float x = Random.Range(minX, maxX);
           float y = Random.Range(minY, maxY);
           player.position = new Vector3(x, y, 0);
        }
    }
}
