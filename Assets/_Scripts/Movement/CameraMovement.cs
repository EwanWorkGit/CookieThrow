using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Transform Player;
    [SerializeField] Animator Animator;
    [SerializeField] DefaultDoor Door;
    [SerializeField] Transform CamAnimTarget;

    [SerializeField] float Sensitivity = 2f;

    DeathHandler _DeathHandler;

    float RotationX, RotationY;

    bool IsAnimating = false;
    public bool CanMove => !_DeathHandler.IsDead && !IsAnimating;

    private void Start()
    {
        Door.OnEnter += TriggerAnimate;
        _DeathHandler = DeathHandler.Instance;

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        Debug.Log(CanMove);

        if(CanMove)
        {
            Vector2 inputs = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * Sensitivity * Time.deltaTime;

            RotationX -= inputs.y;
            RotationY += inputs.x;

            RotationX = Mathf.Clamp(RotationX, -90f, 90f);
        }
    }

    private void LateUpdate()
    {
        if (CanMove)
        {
            transform.rotation = Quaternion.Euler(RotationX, Player.eulerAngles.y, 0f);
            Player.transform.rotation = Quaternion.Euler(0f, RotationY, 0f);
        }
    }

    void TriggerAnimate()
    {
        IsAnimating = true;
        StartCoroutine(Animate());
    }
    IEnumerator Animate()
    {
        if(Door != null && Animator != null)
        {
            Animator.SetTrigger("DoorBroken");
            transform.LookAt(CamAnimTarget.position);
            yield return new WaitForSeconds(3f);
            Animator.SetTrigger("EnemyConvoFinished");
            yield return new WaitUntil(() => Animator.GetCurrentAnimatorStateInfo(0).IsName("CameraZoomOutAnimation")); //waits for animation to stop
            Debug.Log("WAIT FINISHED!");
            IsAnimating = false;
        }
    }
}
