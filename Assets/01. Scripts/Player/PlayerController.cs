using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.InputSystem;
using UnityEngine.ResourceManagement.AsyncOperations;

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
        InitController();
        
        _stateMachine.RunStateMachine<PlayerStatesFactory>(_blackBoard);
        PlayerInput a = GetComponent<PlayerInput>();
        
        _playerCam.OnMove += Rotation;
        
    }

    private void InitController()
    {
        HashSet<Type> types = new HashSet<Type>();

        var components = GetComponentsInChildren<Component>().Where(c => types.Add(c.GetType())).ToArray();
        var enumValue = Enum.GetValues(typeof(PlayerComponentsType)).Cast<PlayerComponentsType>().ToArray();

        for (int i = 0; i < components.Length; i++)
            _blackBoard.SetData(enumValue[i], components[i]);

        _playerData = Addressables.LoadAssetAsync<PlayerData>("Assets/03. Prefabs/PlayerData.asset").WaitForCompletion();
        _stateMachine = GetComponent<StateMachine>();
    }

    public void Movement(Vector2 input)
    {
        Rigidbody rb = _blackBoard.GetData<Rigidbody>(PlayerComponentsType.Rigidbody);

        input = transform.InverseTransformDirection(input);
        
        Vector3 localVelocity = transform.InverseTransformDirection(rb.velocity);
        localVelocity = new Vector3(input.x * _playerData.speed, localVelocity.y, input.y * _playerData.speed);
        
        rb.velocity = transform.TransformDirection(localVelocity);
    }

    public void Jump()
    {
        Rigidbody rb = _blackBoard.GetData<Rigidbody>(PlayerComponentsType.Rigidbody);
        
        float jumpPower = _playerData.jumpPower;
        
        rb.velocity = new Vector3(rb.velocity.x, jumpPower, rb.velocity.z);
    }

    public void Rotation(float inputY)
    {
        transform.localRotation = Quaternion.Euler(0, inputY, 0);
    }
    
    private readonly BlackBoard _blackBoard = new BlackBoard();
    private PlayerData _playerData;
    private StateMachine _stateMachine;
    
    [SerializeField] private CameraController _playerCam;
}
