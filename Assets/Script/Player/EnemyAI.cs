using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float moveSpeed = 3f; // 적 AI 이동 속도
    private GameObject player; // 플레이어 오브젝트를 저장할 변수

    private void Start()
    {
        // 플레이어를 "Player" 태그로 찾아서 변수에 할당
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        // 플레이어가 존재하면 해당 위치를 향해 이동
        if (player != null)
        {
            Vector3 targetDirection = player.transform.position - transform.position;
            targetDirection.y = 0f; // 높이 차이는 무시하여 수평 이동만 고려

            // 적 AI를 플레이어 쪽으로 부드럽게 회전
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 3f);

            // 적 AI를 플레이어 쪽으로 이동
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
    }
}
