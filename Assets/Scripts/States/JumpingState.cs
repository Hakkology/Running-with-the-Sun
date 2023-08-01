using UnityEngine;
public class JumpingState : IState
{
    
    private PlayerController playerController;
    private float jumpForce = 7.5f;
    private bool hasJumped = false;

    public JumpingState(PlayerController playerController)
    {
        this.playerController = playerController;
    }

    public void Enter()
    {

    }

    public void Execute()
    {

        if(!hasJumped)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float adjustedHorizontalSpeed = Input.GetKey(KeyCode.LeftShift) ? 10f : 5f;

            playerController.Rigidbody.AddForce(new Vector2(horizontalInput * adjustedHorizontalSpeed, jumpForce), ForceMode2D.Impulse);
            hasJumped = true;
        }
        
        if (Mathf.Abs(playerController.Rigidbody.velocity.y) < 0.0001f)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                playerController.ChangeState(new RunningState(playerController));
            }
            else
            {
                playerController.ChangeState(new WalkingState(playerController));
            }
        }
    }

    public void Exit()
    {

    }
}