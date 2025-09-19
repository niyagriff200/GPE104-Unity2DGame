using UnityEngine;

public class SpriteMover : MonoBehaviour
{

    //Float variables for the range of X (Can be changed in editor)
    public float minX;
    public float maxX;

    //Float variables for the range of Y (Can be changed in editor)
    public float minY;
    public float maxY;

    //Private variables x and y for random range
    private float x;
    private float y;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //If the player presses down on the Space Key, move a to a random position in range (minX, maxX) and (minY, maxY)
        if (Input.GetKeyDown(KeyCode.T))
        {
           Transform player = GetComponent<Transform>();

           x = Random.Range(minX, maxX);
           y = Random.Range(minY, maxY);
           player.position = new Vector3(x, y, 0);
        }
    }
}
