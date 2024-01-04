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

    private float saglik = 100;
    bool hayattaMi;
    void Start()
    {
        hayattaMi = true;
        rb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<PlayerAnimator>();
    }

    // FixedUpdate is used for physics-related updates
    void FixedUpdate()
    {
        if (saglik <= 0)
        {
            hayattaMi = false;
            playerAnimator.SetBool("Dead", hayattaMi);

        }
        if (hayattaMi == true)
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
    public bool YasiyorMu()
    {
        return hayattaMi;
    }

    public void HasarAl()
    {
        saglik -= Random.Range(10, 20);
    }
}