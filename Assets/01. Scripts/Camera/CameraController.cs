using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public event Action<float> OnMove;
    
    void Start()
    {
        mouseX = target.rotation.eulerAngles.x;
        mouseY = target.rotation.eulerAngles.y;
    }
    
    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position - (target.forward * offset.z) + Vector3.up * offset.y, Time.deltaTime * 20f);
        
        if (playerInput.actions["Look"].triggered)
        {
            var inp = playerInput.actions["Look"].ReadValue<Vector2>().normalized;
        
            mouseX += inp.x * Time.deltaTime * sensitivity;
            mouseY -= inp.y * Time.deltaTime * sensitivity;
        
            mouseY = Mathf.Clamp(mouseY, -45f, 45f);

            Quaternion rot = Quaternion.Euler(mouseY, mouseX, 0f);
            transform.localRotation = Quaternion.Lerp(transform.localRotation, rot, Time.deltaTime * 20f);
            
            OnMove?.Invoke(mouseX);
        }
    }
    
    [SerializeField] private Transform target;
    
    [SerializeField] private Vector3 offset;
    [SerializeField] private float xRotation;
    
    [SerializeField] private PlayerInput playerInput;

    private float mouseX = 0f;
    private float mouseY = 0f;
    private float sensitivity = 320f;
}
