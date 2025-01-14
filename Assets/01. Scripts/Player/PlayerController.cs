using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[
    RequireComponent(typeof(Rigidbody)),
    RequireComponent(typeof(CapsuleCollider)),
    RequireComponent(typeof(Animator)),
    RequireComponent(typeof(StateMachine)),
    RequireComponent(typeof(PlayerInput))
]
public class PlayerController : MonoBehaviour
{
    void Start()
    {
        playerBlackBoard = new BlackBoard();
        
        for (int i = 0; i < gameObject.GetComponentCount(); ++i)
        {
            var component = gameObject.GetComponentAtIndex(i);
            string[] componentName = component.GetType().ToString().Split('.');
            
            playerBlackBoard.SetData(componentName[componentName.Length - 1], component);
        }
        
        playerStateMachine = playerBlackBoard.GetData<StateMachine>("StateMachine");
        
        playerStateMachine.RunMachine<PlayerStatesFactory>(playerBlackBoard);
    }
    
    public BlackBoard playerBlackBoard;
    public StateMachine playerStateMachine;
}
