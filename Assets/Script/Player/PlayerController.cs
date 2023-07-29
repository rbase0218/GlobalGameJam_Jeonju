using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 5f; // 플레이어 이동 속도
    public GameObject bulletPrefabA; // 생성할 프리팹 오브젝트
    public GameObject bulletPrefabB; // 생성할 프리팹 오브젝트
    public GameObject bulletPrefabC; // 생성할 프리팹 오브젝트
    public GameObject bulletPrefabD; // 생성할 프리팹 오브젝트

    public float DelayTime;

    public bool chkDelay;
    private Rigidbody rb;
    private Vector3 movement;

    public string dropOption = "null";
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // WASD 키 입력을 받아 이동 방향 계산
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        float wheelInput = Input.GetAxis("Mouse ScrollWheel");
        Vector3 cameraPos;

        movement = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // 마우스 왼쪽 버튼 클릭 시 프리팹 오브젝트 생성
        if (Input.GetMouseButtonDown(0))
        {
            if (chkDelay == false)
            {
                SpawnBullet();
                chkDelay = true;
                AudioManager.Inst.PlaySFX("Seeds-dropped");
                Invoke("DelayMouse", DelayTime);
            }
            else
            {
                Debug.Log("Activate Delay");
            }


            
        }
    }

    private void FixedUpdate()
    {
        // 이동 실행
        MovePlayer();
    }
    private void DelayMouse() {
        chkDelay = false;
    }
    private void MovePlayer()
    {
        // 이동 방향을 기준으로 이동 속도만큼 이동
        Vector3 velocity = movement * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(transform.position + velocity);
    }

    private void SpawnBullet()
    {
        
            // 플레이어의 현재 위치에서 프리팹 오브젝트 생성
            if (dropOption == "A")
            {
                Instantiate(bulletPrefabA, transform.position, Quaternion.identity);
            }
            else if (dropOption == "B")
            {
                Instantiate(bulletPrefabB, transform.position, Quaternion.identity);
            }
            else if (dropOption == "C")
            {
                Instantiate(bulletPrefabC, transform.position, Quaternion.identity);
            }
            else if (dropOption == "D")
            {
                Instantiate(bulletPrefabD, transform.position, Quaternion.identity);
            }
            else
            {
                Debug.Log("No options were selected");
            }
        
    }
}    




