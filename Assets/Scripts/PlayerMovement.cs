using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;

    private InputActions inputActions;
    private Vector2 moveVector = Vector2.zero;
    private Vector2 mousePosition = Vector2.zero;
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

    private void Update()
    {
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector3 direction = (mouseWorldPosition - transform.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    private void OnEnable()
    {
        inputActions.Enable();
        inputActions.Player.Move.performed += OnMovementPerformed;
        inputActions.Player.Move.canceled += OnMovementCanceled;
        inputActions.Player.PointerPosition.performed += OnPointerPositionPerformed;
    }

    private void OnDisable()
    {
        inputActions.Disable();
        inputActions.Player.Move.performed -= OnMovementPerformed;
        inputActions.Player.Move.canceled -= OnMovementCanceled;
        inputActions.Player.PointerPosition.performed -= OnPointerPositionPerformed;
    }

    private void OnMovementPerformed(InputAction.CallbackContext callbackContext)
    {
        moveVector = callbackContext.ReadValue<Vector2>();
    }

    private void OnMovementCanceled(InputAction.CallbackContext callbackContext)
    {
        moveVector = Vector2.zero;
    }

    private void OnPointerPositionPerformed(InputAction.CallbackContext callbackContext)
    {
        mousePosition = callbackContext.ReadValue<Vector2>();
    }
}
