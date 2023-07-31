public class StateMachine
{
    private IState currentState {get; private set;}

    public void ChangeState(IState newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState?.Enter();
    }

    public void Update()
    {
        currentState?.Execute();
    }
}