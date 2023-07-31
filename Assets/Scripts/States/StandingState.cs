public class StandingState : IState
{
    private PlayerController playerController;

    public StandingState(PlayerController playerController)
    {
        this.playerController = playerController;
    }

    public void Enter()
    {
        Debug.Log("Enter Standing State");
    }

    public void Execute()
    {
        Debug.Log("Execute Standing State");

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            playerController.ChangeState(new WalkingState(playerController));
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerController.ChangeState(new JumpingState(playerController));
        }
    }

    public void Exit()
    {
        Debug.Log("Exit Standing State");
    }
}