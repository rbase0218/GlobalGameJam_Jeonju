using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerTransform;
    public float sensitivity = 2.0f;
    public float maxYAngle = 80.0f;
    public float distanceFromPlayer = 2.0f;

    private float rotationY = 0.0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // 초기 위치 설정
        transform.position = playerTransform.position - playerTransform.forward * distanceFromPlayer;
    }

    private void Update()
    {
        // 마우스 입력을 받아서 카메라를 회전시킵니다.
        float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivity;
        rotationY += Input.GetAxis("Mouse Y") * sensitivity;
        rotationY = Mathf.Clamp(rotationY, -maxYAngle, maxYAngle);

        transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);

        // 카메라 위치를 플레이어 주위로 이동시킵니다.
        transform.position = playerTransform.position - transform.forward * distanceFromPlayer;
    }
}
