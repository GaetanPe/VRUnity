using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    public LayerMask interact;
    [SerializeField] Transform characterCamera;
    [SerializeField] Controller movementAction;
    [SerializeField] Rigidbody rbCharacter;
    [SerializeField] Transform characterTransform;
    [SerializeField] private float speed;
    [SerializeField] private bool interactpressed;
    [SerializeField] private float interactionDistance;
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
        Ray interactionRay = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(interactionRay, out RaycastHit hit, interactionDistance, interact))
        {
            interactpressed = movementAction.Gameplay.interaction.ReadValue<bool>();
            InteractableObject interactableObject = hit.transform.GetComponent<InteractableObject>();
            if (interactableObject != null && interactpressed) 
            {
                interactableObject.GetComponent<Rigidbody>().AddForce(transform.forward * 100f);
            }
        }
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
