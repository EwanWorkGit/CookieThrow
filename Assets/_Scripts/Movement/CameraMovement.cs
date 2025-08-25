using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Transform Player;
    [SerializeField] float Sensitivity = 2f;

    float RotationX, RotationY;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        Vector2 inputs = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * Sensitivity * Time.deltaTime;

        RotationX -= inputs.y;
        RotationY += inputs.x;

        RotationX = Mathf.Clamp(RotationX, -90f, 90f);
    }

    private void LateUpdate()
    {
        transform.rotation = Quaternion.Euler(RotationX, Player.eulerAngles.y, 0f);
        Player.transform.rotation = Quaternion.Euler(0f, RotationY, 0f);
    }
}
