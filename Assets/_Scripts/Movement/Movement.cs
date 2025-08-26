using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] Camera Cam;
    [SerializeField] Vector3 MovementVector;

    [SerializeField] float Speed = 5f, UpForce = 100f, JumpRayDistance = 0.6f;
    [SerializeField] bool IsJumping = false;
    Rigidbody Rb;

    private void Start()
    {
        Rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector2 inputs = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        Vector3 right = Cam.transform.right;
        right.y = 0;
        Vector3 forward = Cam.transform.forward;
        forward.y = 0;

        MovementVector = (right * inputs.x + forward * inputs.y).normalized * Speed;

        Physics.Raycast(transform.position, -transform.up, out RaycastHit hit, JumpRayDistance);
        Debug.DrawRay(transform.position, -transform.up * JumpRayDistance, Color.yellow);
        IsJumping = hit.collider == null;

        if(!IsJumping && Input.GetKeyDown(KeyCode.Space))
        {
            Rb.AddForce(new Vector3(0f, UpForce));
        }
    }

    private void FixedUpdate()
    {
        Rb.velocity = new Vector3(MovementVector.x, Rb.velocity.y, MovementVector.z);
    }
}
