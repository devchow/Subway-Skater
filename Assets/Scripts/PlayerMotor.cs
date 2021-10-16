using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private const float LaneDistance = 3.0f;
    private const float TurnSpeed = 0.05f;
    
    // Animation
    private Animator anim;
    
    // Movement
    private CharacterController controller;
    private float jumpForce = 4.0f; // ---------Add Jump force
    private float gravity = 12.0f;
    private float verticalVelocity;
    private float speed = 7.0f;
    private int desiredLane = 1; // 0 = Left, 1 = middle, 2 = Right
    
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        // Gather the inputs on which lane we should be
        // Move Left
        if (MobileInput.Instance.SwipeLeft)
        {
            Debug.Log("Left---");
            MoveLane(false);
        }

        // Move Right
        if (MobileInput.Instance.SwipeRight)
        {
            Debug.Log("Right---");
            MoveLane(true);
        }
        
        // Calculate where we should be in the future
        Vector3 targetPos = transform.position.z * Vector3.forward;
        
        if (desiredLane == 0)
            targetPos += Vector3.left * LaneDistance;
        else if(desiredLane == 2)
            targetPos += Vector3.right * LaneDistance;
        
        // Calculate Move Delta
        Vector3 moveVector = Vector3.zero;
        moveVector.x = (targetPos - transform.position).normalized.x * speed;

        bool isGrounded = IsGrounded();
        anim.SetBool("Grounded", isGrounded);
        
        // Calculate Y
        if (IsGrounded())
        {
            verticalVelocity = -0.1f;

            // Jump
            if (MobileInput.Instance.SwipeUp)
            {
                anim.SetTrigger("Jump");
                verticalVelocity = jumpForce;
                Debug.Log("Jumping Up");
            }
        }
        else
        {
            verticalVelocity -= (gravity * Time.deltaTime);
            
            // Fast Falling Mechanic
            if (MobileInput.Instance.SwipeDown)
            {
                verticalVelocity = -jumpForce;
                Debug.Log("Jumping Down");
            }
        }
        
        moveVector.y = verticalVelocity;
        moveVector.z = speed;
        
        // Move the Player
        controller.Move(moveVector * Time.deltaTime);
        
        // Rotate player to where he is going
        Vector3 dir = controller.velocity;
        dir.y = 0;
        transform.forward = Vector3.Lerp(transform.forward,dir, TurnSpeed);
    }

    private void MoveLane(bool goingRight)
    {
        desiredLane += (goingRight) ? 1 : -1;
        desiredLane = Mathf.Clamp(desiredLane, 0, 2);
    }

    private bool IsGrounded()
    {
        // Ray groundRay = new Ray(new Vector3(controller.bounds.center.x,
        //     (controller.bounds.center.y - controller.bounds.extents.y) + 0.2f, 
        //     controller.bounds.center.z), Vector3.down);
        
        Ray groundRay = new Ray(
            new Vector3(
                controller.bounds.center.x,
                controller.bounds.center.y - controller.bounds.extents.y + 0.2f,
                controller.bounds.center.z),
            Vector3.down);
        
        Debug.DrawRay(groundRay.origin, groundRay.direction, Color.cyan, 1.0f);

        return (Physics.Raycast(groundRay, 0.2f + 0.1f));
    }
}































