using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MWalkState : IState
{
    public MWalkState(StateMachine stateMachine)
    {
        FSM = stateMachine;
    }
    
    public void EnterState()
    {
        Animator anim = FSM.BlackBoard.GetData<Animator>("Animator");
        rb = FSM.BlackBoard.GetData<Rigidbody>("Rigidbody");
        transform = FSM.BlackBoard.GetData<Transform>("Transform");
        
        anim.SetFloat(Speed, 1f);
        anim.CrossFade("Idle", 0.1f);
    }

    public void UpdateState()
    {
        Collider[] hit = Physics.OverlapBox(transform.position, new Vector3(10f, 5f, 10f), Quaternion.identity, 1 << LayerMask.NameToLayer("Player"));
        
        Vector3 direction = hit[0].transform.position - transform.position;
        direction.Normalize();

        rb.velocity = direction * 2f;
        rb.rotation = Quaternion.LookRotation(direction);

        if (hit[0] != null && Vector3.Distance(hit[0].transform.position, transform.position) < 3f)
        {
            FSM.ChangeState<MSkillState>();
            return;
        }
    }

    public void ExitState()
    {
    }

    public StateMachine FSM { get; set; }

    private Rigidbody rb;
    private Transform transform;
    private static readonly int Speed = Animator.StringToHash("Speed");
}
