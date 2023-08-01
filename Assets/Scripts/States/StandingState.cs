using UnityEngine;
public class StandingState : IState
{
    private PlayerController playerController;

    public StandingState(PlayerController playerController)
    {
        this.playerController = playerController;
    }

    public void Enter()
    {

    }

    public void Execute()
    {


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

    }
}