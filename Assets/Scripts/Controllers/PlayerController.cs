using UnityEngine;

public class PlayerController : Controller
{
    public Pawn pawn;

    private void Update()
    {
        if (pawn != null)
        {
            if (Input.GetKey(KeyCode.W))
            {
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

            if (Input.GetKeyDown(KeyCode.T))
            {
                pawn.TeleportRandom();
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                pawn.shooter.Shoot();
            }
        }
    }
}
