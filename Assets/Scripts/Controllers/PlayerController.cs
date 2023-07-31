using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController 
{
    public event Action OnPlayerJumped;
    public event Action OnPlayerWalked;
    public event Action OnPlayerRun;

    private StateMachine stateMachine;
    private Animator animator;
    private Rigidbody2D rigidbody;
    private Transform transform;

    public PlayerController(Animator animator, Rigidbody2D rigidbody, Transform transform){

        this.animator = animator;
        this.rigidbody = rigidbody;
        this.transform = transform;
        
        stateMachine = new StateMachine();
        stateMachine.ChangeState(new WalkingState(this));
    }
    

    void Start()
    {
        
    }


    void Update()
    {
        stateMachine.Update();

        if (stateMachine.currentState is JumpingState)
            OnPlayerJumped?.Invoke();
        else if (stateMachine.currentState is RunningState)
            OnPlayerRun?.Invoke();
        else if(stateMachine.currentState is WalkingState)
            OnPlayerWalked?.Invoke();
    }

    public void ChangeState(IState newState)
    {
        stateMachine.ChangeState(newState);
    }

    public Animator Animator
    {
        get { return animator; }
    }

    public Rigidbody2D Rigidbody
    {
        get { return rigidbody; }
    }

    public Transform Transform
    {
        get { return transform; }
    }
}
