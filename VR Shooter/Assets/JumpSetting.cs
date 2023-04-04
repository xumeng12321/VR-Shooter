using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class JumpSetting : MonoBehaviour
{

    [SerializeField] private InputActionReference JumpButton;
    [SerializeField] private float JumpHeight = 2.0f;
    
    [SerializeField] private float GravityValue = -9.81f;

    private CharacterController _characterController;
    private Vector3 _playerVelovity; 

    private void Awake() => _characterController = GetComponent<CharacterController>();
    private void OnEnable() => JumpButton.action.performed += Jumping;

    private void OnDisable() => JumpButton.action.performed -= Jumping;
    private void Jumping(InputAction.CallbackContext obj)
    {
        if(!_characterController.isGrounded) return;
        _playerVelovity.y = Mathf.Sqrt(JumpHeight * -1 * GravityValue);

    } 

    private void Update()
    {
        if(!_characterController.isGrounded && _playerVelovity.y < 0) 
        {
            _playerVelovity.y = 0;
        }

        _playerVelovity.y += GravityValue * Time.deltaTime;
        _characterController.Move(_playerVelovity * Time.deltaTime);
    }
    
}
