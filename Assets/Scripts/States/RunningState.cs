using UnityEngine;
public class RunningState : IState
{
        
    private readonly float speed = 10f;
    private PlayerController playerController;

    public RunningState(PlayerController playerController)
    {
        this.playerController = playerController;
    }

    public void Enter()
    {

    }

    public void Execute()
    {

        float move = Input.GetKey(KeyCode.A) ? -1 : Input.GetKey(KeyCode.D) ? 1 : 0;
        playerController.transform.Translate(move * speed * Time.deltaTime, 0, 0);

        if (!Input.GetKey(KeyCode.LeftShift))
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

    }
}