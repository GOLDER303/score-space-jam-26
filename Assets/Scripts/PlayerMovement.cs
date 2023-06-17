using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;

    private InputActions inputActions;
    private Vector2 moveVector = Vector2.zero;
    private Rigidbody2D playerRigidBody;

    private void Awake()
    {
        inputActions = new InputActions();
        playerRigidBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        playerRigidBody.AddForce(moveVector * moveSpeed * Time.deltaTime);
    }

    private void OnEnable()
    {
        inputActions.Enable();
        inputActions.Player.Move.performed += OnMovementPerformed;
        inputActions.Player.Move.canceled += OnMovementCanceled;
    }

    private void OnDisable()
    {
        inputActions.Disable();
        inputActions.Player.Move.performed -= OnMovementPerformed;
        inputActions.Player.Move.canceled -= OnMovementCanceled;
    }

    private void OnMovementPerformed(InputAction.CallbackContext callbackContext)
    {
        moveVector = callbackContext.ReadValue<Vector2>();
    }

    private void OnMovementCanceled(InputAction.CallbackContext callbackContext)
    {
        moveVector = Vector2.zero;
    }
}
