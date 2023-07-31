using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController 
{
    public event Action OnPlayerMoved;

    private StateMachine stateMachine;
    private float lastSpawnXPosition;
    private const float SpawnInterval = 1.5f;

    private Animator animator;
    private Rigidbody2D rigidbody;
    private Transform transform;

    public PlayerController(Animator animator, Rigidbody2D rigidbody, Transform transform){

        this.animator = animator;
        this.rigidbody = rigidbody;
        this.transform = transform;
        
        stateMachine = new StateMachine();
        
        var standingState = new StandingState(this);
        var walkingState = new WalkingState(this);
        var runningState = new RunningState(this);
        var jumpingState = new JumpingState(this);
        
        stateMachine.ChangeState(standingState);

        lastSpawnXPosition = transform.position.x;
    }
    

    void Start()
    {
        
    }


    void Update()
    {
        stateMachine.Update();

        if (Mathf.Abs(transform.position.x - lastSpawnXPosition) >= SpawnInterval)
        {
            OnPlayerMoved?.Invoke();
            lastSpawnXPosition = transform.position.x;
        }
    }

    public void ChangeState(IState newState)
    {
        stateMachine.ChangeState(newState);
    }

    public Animator Animator => animator;
    public Rigidbody2D Rigidbody => rigidbody;
    public Transform Transform => transform;
}
