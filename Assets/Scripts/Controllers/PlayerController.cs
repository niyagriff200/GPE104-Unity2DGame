using UnityEngine;

public class PlayerController : Controller
{
    public Pawn pawn;

    // Update is called once per frame
    void Update()
    {
        if (pawn != null)
        {
            //Local Space Inputs
            if (Input.GetKey(KeyCode.W))
            {
                //Check if LShift or RShift is being pressed
                if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                {
                    pawn.MoveTurbo(pawn.transform.up);
                }
                else
                {
                    pawn.Move(pawn.transform.up);
                }
            }

            if (Input.GetKey(KeyCode.S))
            {
                //Check if LShift or RShift is being pressed
                if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                {
                    pawn.MoveTurbo(-pawn.transform.up);
                }
                else
                {
                    pawn.Move(-pawn.transform.up);
                }
            }

            if (Input.GetKey(KeyCode.A))
            {
                pawn.Rotate(1.0f);
            }

            if (Input.GetKey(KeyCode.D))
            {
                pawn.Rotate(-1.0f);
            }

            //World Space Inputs for teleport
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                pawn.Teleport(Vector3.up);
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                pawn.Teleport(Vector3.down);
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                pawn.Teleport(Vector3.left);
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                pawn.Teleport(Vector3.right);
            }

            //Random Teleport using T
            if (Input.GetKeyDown(KeyCode.T))
            {
                pawn.TeleportRandom();
            }

            //Space to shoot
            if (Input.GetKeyDown(KeyCode.Space))
            {
                pawn.shooter.Shoot();
            }
        }
        else
        {
            Debug.LogWarning("The pawn doesn't exist anymore.");
        }
    }
}
