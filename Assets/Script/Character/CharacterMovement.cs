using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    public Controller movementAction;
    public Rigidbody rb;
    public Transform playerTransform;
    void Awake()
    {
        // instantiate the actions wrapper class
        movementAction = new Controller();
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerTransform = GetComponent<Transform>();
    }

    void Update()
    {
        Vector2 movementInput = movementAction.Gameplay.move.ReadValue<Vector2>();
        rb.AddForce(new Vector2(movementInput.x, 0) * 10);
    }

    void OnEnable()
    {
        movementAction.Gameplay.Enable();
    }
    void OnDisable()
    {
        movementAction.Gameplay.Disable();
    }
}
