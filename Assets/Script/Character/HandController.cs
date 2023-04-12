using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandController : MonoBehaviour
{
    // this field will contain the actions wrapper instance
    Controller actions;

    void Awake()
    {
        // instantiate the actions wrapper class
        actions = new Controller();

       
    }

    void Update()
    {
        // our update loop polls the "move" action value each frame
        Vector2 moveVector = actions.Gameplay.move.ReadValue<Vector2>();
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        // this is the "jump" action callback method
        Debug.Log("Jump!");
    }

    void OnEnable()
    {
        actions.Gameplay.Enable();
    }
    void OnDisable()
    {
        actions.Gameplay.Disable();
    }
}
