using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    [SerializeField] private InputActionReference Back;
    private CharacterController _characterController;

    private void Start() => _characterController = GetComponent<CharacterController>();

    // Update is called once per frame

    private void Update() 
    {
        if(Back.action.ReadValue<float>()>0.5)
        {
            SceneManager.LoadScene(0);
        }
    }


}
