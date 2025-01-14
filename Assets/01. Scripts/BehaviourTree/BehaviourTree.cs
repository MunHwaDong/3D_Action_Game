using UnityEngine;

public class BehaviourTree : MonoBehaviour
{
    private Node root;
    
    private MonsterController monsterController;

    void Start()
    {
        monsterController = GetComponent<MonsterController>();
        
        root = BehaviourNodeFactory.CreateBehaviourNode<MonsterBehaviourNodeFactory>(monsterController);
    }

    void Update()
    {
        root.Evaluate();
    }
}