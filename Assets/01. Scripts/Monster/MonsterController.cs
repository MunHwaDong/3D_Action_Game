using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

[
    RequireComponent(typeof(Animator)),
    RequireComponent(typeof(BehaviourTree)),
]
public class MonsterController : MonoBehaviour, IHitable
{
    void Start()
    {
        BlackBoard = new BlackBoard();
        InitController();

        _monsterBehaviours = GetComponent<BehaviourTree>();
        _monsterBehaviours.Run<BullMonsterBehaviourFactory>(this);
    }
    
    private void InitController()
    {
        HashSet<Type> types = new HashSet<Type>();

        // var components = GetComponentsInChildren<Component>().Where(c => types.Add(c.GetType())).ToArray();
        // var enumValue = Enum.GetValues(typeof(MonsterComponentsType)).Cast<MonsterComponentsType>().ToArray();
        //
        // //몬스터 컴포넌트를 파싱하도록 변경해야함
        // for (int i = 0; i < components.Length; i++)
        //     BlackBoard.SetData(enumValue[i], components[i]);
        
        BlackBoard.SetData(MonsterComponentsType.ANIMATOR, GetComponent<Animator>());
        BlackBoard.SetData(MonsterComponentsType.RIGIDBODY, GetComponentInChildren<Rigidbody>());

        MonsterData = Addressables.LoadAssetAsync<MonsterData>("Assets/03. Prefabs/MonsterData.asset").WaitForCompletion();
    }

    public void Movement(Vector3 move)
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, MonsterData.speed * Time.deltaTime);
        transform.rotation = Quaternion.LookRotation(move);
    }
    
    public async void TakenHit(float damage)
    {
        Animator anim = BlackBoard.GetData<Animator>(MonsterComponentsType.ANIMATOR);
        
        anim.Rebind();
        anim.SetTrigger("Hit");
        anim.CrossFade("Hit", 0.2f);
        
        MonsterData.health -= damage;
        
        await UniTask.WaitUntil(() =>
        {
            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 0.5f)
            {
                return false;
            }
            else
            {
                anim.Rebind();
                anim.SetFloat(Speed, 0f);
                anim.CrossFade("Idle", 0.1f);
                return true;
            }
        });
    }
    
    private BehaviourTree _monsterBehaviours;
    
    public BlackBoard BlackBoard { get; private set; }
    public MonsterData MonsterData { get; private set; }
    public Transform target;
    private static readonly int Speed = Animator.StringToHash("Speed");
}
