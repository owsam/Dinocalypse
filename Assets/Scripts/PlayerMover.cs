using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private Animator animator;
    [SerializeField] private float weight = 50;

    // Stuff from Unity
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;

    private Vector2 movementVector = new();
    private bool jumped;

    private float mass = 3.0F; // defines the character mass
    private Vector3 impact = Vector3.zero;

    void Start()
    {
        weight *= 0.01f;
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(movementVector.x, 0, 0);
        controller.Move(playerSpeed * Time.deltaTime * move);
        if(move != Vector3.zero)
            animator.SetBool("walk", true);
        else
            animator.SetBool("walk", false);

        // Changes the height position of the player..
        if (jumped && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight / weight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
        jumped = false;

        // apply the impact force:
        if (impact.magnitude > 0.2F) controller.Move(impact * Time.deltaTime);
        // consumes the impact energy each cycle:
        impact = Vector3.Lerp(impact, Vector3.zero, Time.deltaTime / 2);
        //if(impact == Vector3.zero)
    }

    void OnMove(InputValue movementValue)
    {
        movementVector = movementValue.Get<Vector2>();
    }

    void OnJump(InputValue jumpVal)
    {
        jumped = jumpVal.isPressed;
    }

    public void AddImpact(Vector3 dir, float force)
    {
        dir.Normalize();
        if (dir.y < 0) dir.y = -dir.y; // reflect down force on the ground
        impact += dir.normalized * force / mass;
        Debug.Log("throw",gameObject);
    }
}
