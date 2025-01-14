using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[
    RequireComponent(typeof(Rigidbody)),
    RequireComponent(typeof(CapsuleCollider)),
    RequireComponent(typeof(Animator)),
    //RequireComponent(typeof(StateMachine))
    RequireComponent(typeof(BehaviourTree))
]
public class MonsterController : MonoBehaviour
{
    void Awake()
    {
        monsterBlackBoard = new BlackBoard();
        
        for (int i = 0; i < gameObject.GetComponentCount(); ++i)
        {
            var component = gameObject.GetComponentAtIndex(i);
            string[] componentName = component.GetType().ToString().Split('.');
            
            monsterBlackBoard.SetData(componentName[componentName.Length - 1], component);
        }
        
        //monsterStateMachine = monsterBlackBoard.GetData<StateMachine>("StateMachine");
        
        //monsterStateMachine.RunMachine<MonsterStatesFactory>(monsterBlackBoard);
    }
    
    public BlackBoard monsterBlackBoard;
    public StateMachine monsterStateMachine;
}
