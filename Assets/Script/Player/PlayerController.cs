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

    
    public float rotationSpeed = 60f;
    private float targetRotationY = 0f;
    private Quaternion targetRotation;

    
    public string dropOption = "null";
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {


        // WASD 키 입력을 받아 이동 방향 계산
        movement = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
        // 플레이어 회전 처리
        if (Input.GetKey(KeyCode.D))
        {
            // 'W' 키를 누르면 왼쪽으로 45도 회전
            targetRotationY += rotationSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            // 'S' 키를 누르면 오른쪽으로 45도 회전
            targetRotationY -= rotationSpeed * Time.deltaTime;
        }

        // 부드럽게 회전하기 위해 Quaternion.Slerp() 사용
        transform.rotation = Quaternion.Euler(0f, targetRotationY, 0f);

        
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

        dropOption = InvenManager.Instance.currItemName.itemName;
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
            if (dropOption == "Grass" && GameManager.Instance.seeds > 1)
            {
                Instantiate(bulletPrefabA, transform.position, Quaternion.identity);
                GameManager.Instance.setSeeds(1f);
            }
            else if (dropOption == "Tree" && GameManager.Instance.seeds >= 1 && GameManager.Instance.sprits >= 1)
            {
                Instantiate(bulletPrefabB, transform.position, Quaternion.identity);
                GameManager.Instance.setSeeds(1f);
                GameManager.Instance.SetSprits(1f);
            }
            else if (dropOption == "Web" && GameManager.Instance.seeds >= 2 && GameManager.Instance.sprits >= 2)
            {
                Instantiate(bulletPrefabC, transform.position, Quaternion.identity);
                GameManager.Instance.setSeeds(2f);
                GameManager.Instance.SetSprits(2f);
        }
            else if (dropOption == "Flower" && GameManager.Instance.seeds >= 2 && GameManager.Instance.sprits >= 2)
            {
                Instantiate(bulletPrefabD, transform.position, Quaternion.identity);
                GameManager.Instance.setSeeds(1f);
                GameManager.Instance.SetSprits(8f);
        }
            else
            {
                Debug.Log("No options were selected");
            }
        
    }
}    




