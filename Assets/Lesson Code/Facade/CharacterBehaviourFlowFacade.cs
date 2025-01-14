using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class CharacterBehaviourFlowFacade : MonoBehaviour
{
    public PlayerController player1;
    public PlayerController player2;
    public PlayerController player3;
    
    public Button doing;

    void Start()
    {
        doing.onClick.AddListener(Facade);
    }

    void Facade()
    {
        player1.playerStateMachine.ChangeState<JumpState>();
        player2.playerStateMachine.ChangeState<WalkState>();

        Wait().Forget();
    }

    async UniTaskVoid Wait()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(3f));
        
        player3.playerStateMachine.ChangeState<JumpState>();
        
        player3.playerStateMachine.ChangeState<WalkState>();
        
        Debug.Log("After 3 seconds Do Jumping");
    }
}
