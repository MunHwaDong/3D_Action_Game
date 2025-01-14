using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MIdleState : IState
{
    public MIdleState(StateMachine stateMachine)
    {
        FSM = stateMachine;
    }
    
    public void EnterState()
    {
        animator = FSM.BlackBoard.GetData<Animator>("Animator");
        transform = FSM.BlackBoard.GetData<Transform>("Transform");
        
        animator.Rebind();
        animator.CrossFade("Idle", 0.1f);
    }

    public void UpdateState()
    {
        Collider[] hit = Physics.OverlapBox(transform.position, new Vector3(10f, 5f, 10f), Quaternion.identity, 1 << LayerMask.NameToLayer("Player"));
        
        if (hit.Length > 0)
        {
            FSM.ChangeState<MWalkState>();
            return;
        }
    }

    public void ExitState()
    {
        
    }

    public StateMachine FSM { get; set; }

    private Animator animator;
    private Transform transform;
}
