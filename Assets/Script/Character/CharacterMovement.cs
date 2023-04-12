using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    public Controller movementAction;
    public Rigidbody rbCharacter;
    public Transform characterTransform;
    [SerializeField] private float speed;
    Vector3 characterMovement = Vector3.zero;
    void Awake()
    {
        // instantiate the actions wrapper class
        movementAction = new Controller();
    }
    void Start()
    {
        rbCharacter = GetComponent<Rigidbody>();
        characterTransform = GetComponent<Transform>();
    }

    void Update()
    {
        Vector2 movementInput = movementAction.Gameplay.move.ReadValue<Vector2>();
        characterMovement = new Vector3 (movementInput.x,0,movementInput.y)* speed *Time.deltaTime;
        rbCharacter.MovePosition(characterTransform.position +characterMovement);
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
