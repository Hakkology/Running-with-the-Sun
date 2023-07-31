public class JumpingState : IState
{
    
    private PlayerController playerController;
    private float jumpForce = 5f;
    private bool hasJumped = false;

    public JumpingState(PlayerController playerController)
    {
        this.playerController = playerController;
    }

    public void Enter()
    {
        Debug.Log("Enter Jumping State");
    }

    public void Execute()
    {
        Debug.Log("Execute Jumping State");
        if(!hasJumped)
        {
            playerController.Rigidbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
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
        Debug.Log("Exit Jumping State");
    }
}