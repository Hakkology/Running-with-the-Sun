using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController 
{
    public event Action OnPlayerMoved;
    public event Action OnPlayerMovedTrees;
    public event Action OnPlayerMovedJumpPlatforms;

    private StateMachine stateMachine;

    private float lastSpawnXPosition;
    private float lastSpawnXPositionTrees;
    private float lastSpawnXPositionJumpPlatforms;

    private const float SpawnInterval = 1f;
    private float SpawnIntervalTrees = UnityEngine.Random.Range(4f, 9f);
    private float SpawnIntervalJumpPlatforms = UnityEngine.Random.Range(6f, 14f);

    private Animator animator;
    private Rigidbody2D rigidbody;
    public Transform transform;

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


    public void Update()
    {
        stateMachine.Update();

        // path spawn
        if (Mathf.Abs(transform.position.x - lastSpawnXPosition) >= SpawnInterval)
        {
            OnPlayerMoved?.Invoke();
            lastSpawnXPosition = transform.position.x;
        }

        // tree spawn
        if (Mathf.Abs(transform.position.x - lastSpawnXPositionTrees) >= SpawnIntervalTrees)
        {
            OnPlayerMovedTrees?.Invoke();
            lastSpawnXPositionTrees = transform.position.x;

            SpawnIntervalTrees = UnityEngine.Random.Range(4f, 9f);
        }

        // jump platform
        if (Mathf.Abs(transform.position.x - lastSpawnXPositionJumpPlatforms) >= SpawnIntervalJumpPlatforms)
        {
            OnPlayerMovedJumpPlatforms?.Invoke();
            lastSpawnXPositionJumpPlatforms = transform.position.x;

            SpawnIntervalJumpPlatforms = UnityEngine.Random.Range(6f, 14f);
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
