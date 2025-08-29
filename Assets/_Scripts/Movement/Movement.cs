using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] CameraMovement CamMovement;
    [SerializeField] Camera Cam;
    [SerializeField] Vector3 MovementVector;

    [SerializeField] AudioSource AudioPlayer;
    [SerializeField] AudioClip Footstep;

    [SerializeField] float Speed = 5f, UpForce = 100f, JumpRayDistance = 0.6f, StepInterval = 0.2f;
    [SerializeField] bool IsJumping = false;

    Rigidbody Rb;

    float StepTimer;

    private void Start()
    {
        Rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (CamMovement.CanMove)
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

            if (!IsJumping && Input.GetKeyDown(KeyCode.Space))
            {
                Rb.AddForce(new Vector3(0f, UpForce));
            }
        }

        if(Mathf.Abs(Rb.velocity.x) > 0.1f || Mathf.Abs(Rb.velocity.z) > 0.1f)
        {
            if(!IsJumping)
            {
                StepTimer += Time.deltaTime;

                if (StepTimer >= StepInterval)
                {
                    StepTimer = 0;
                    AudioPlayer.pitch = Random.Range(0.9f, 1.1f);
                    AudioPlayer.PlayOneShot(Footstep);
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if(CamMovement.CanMove)
        {
            Rb.velocity = new Vector3(MovementVector.x, Rb.velocity.y, MovementVector.z);
        }
    }
}
