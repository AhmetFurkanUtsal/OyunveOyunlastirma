using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float horizontal;
    [SerializeField] private float vertical;

    private Rigidbody rb;
    private PlayerAnimator playerAnimator;
    [SerializeField] private float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<PlayerAnimator>();
    }

    // FixedUpdate is used for physics-related updates
    void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0, vertical);
        float magnitude = movement.magnitude;
        magnitude = Mathf.Clamp01(magnitude);
        movement.Normalize();

        // Use MovePosition to update the kinematic Rigidbody's position
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

        if (movement != Vector3.zero)
        {
            playerAnimator.SetBool("Walk", true);
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            playerAnimator.SetBool("Walk", false);
        }
    }
}

