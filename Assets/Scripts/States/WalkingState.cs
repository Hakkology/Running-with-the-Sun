public class WalkingState : IState
{
    private readonly float speed = 5f;
    private PlayerController playerController;

    public WalkingState(PlayerController playerController){

        this.playerController = playerController;
    }

    public void Enter()
    {
        Debug.Log("Enter Jumping State");
    }

    public void Execute()
    {
        Debug.Log("Execute Walking State");
        float move = Input.GetKey(KeyCode.A) ? -1 : Input.GetKey(KeyCode.D) ? 1 : 0;
        playerController.transform.Translate(move * speed * Time.deltaTime, 0, 0);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            playerController.ChangeState(new RunningState(playerController));
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerController.ChangeState(new JumpingState(playerController));
        }
    }

    public void Exit()
    {
        Debug.Log("Exit Jumping State");
    }
}