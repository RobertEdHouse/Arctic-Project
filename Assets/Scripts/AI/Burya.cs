using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachines;
using UnityEngine.AI;

public class Burya : MonoBehaviour
{

    private NavMeshAgent agent;
    public float ordinarySpeed;
    public float chaseSpeed;

    public State wanderingState;
    public State attackState;
    public State chaseState;
    public State teleportationState;

    public StateMachine stateMachine;


    public List<Zone> borders;
    [SerializeField]
    private Player player;

    public Transform[] points;
    private Animator _animator;

    private int lastPoint = 0;
    public Zone zone1;
    public Zone zone3;
    public bool IsBlocked = false;

    public void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        CreateStates();
    }
    public void CreateStates()
    {
        stateMachine = new StateMachine();
        wanderingState = new WanderingState(stateMachine, this, player);
        attackState = new AttackState(stateMachine, this, player);
        chaseState = new ChaseState(stateMachine, this, player);
        teleportationState = new TeleportationState(stateMachine, this, player);
        stateMachine.Initialize(wanderingState);
    }
    public void Update()
    {
        stateMachine.Update();
    }

    public void TeleportToPoint(Vector3 point)
    {
        transform.position = point;
    }

    public void MoveToPointOnTheMap()
    {
        if (IsBlocked) return;
        if (points==null) return;
        if (!agent.hasPath)
        {
            lastPoint = Random.Range(0, points.Length - 1);
            MoveToPoint(points[lastPoint]);
        }
    }
    public void MoveToPoint(Transform point)
    {
        if (IsBlocked) return;
        agent.SetDestination(point.position);
        
    }

    
}
