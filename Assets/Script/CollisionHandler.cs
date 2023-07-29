using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public GameObject replacementPrefab; // 바꿀 프리팹을 Inspector에서 할당하기 위한 변수

    // 충돌 처리
    private void OnCollisionEnter(Collision collision)
    {
        GameObject otherObject = collision.gameObject;

        // 충돌한 오브젝트가 Ground태그를 가진 오브젝트인지 확인
        if (otherObject.CompareTag("Ground"))
        {
            // 충돌한 오브젝트가 Seed태그를 가진 오브젝트인지 확인
            if (gameObject.CompareTag("Seed"))
            {
                // 다른 프리팹으로 교체
                ReplaceWithPrefab();
            }
        }
    }

    // 프리팹 교체 함수
    private void ReplaceWithPrefab()
    {
        // 현재 오브젝트의 위치와 회전값 저장
        Vector3 position = transform.position;
        Quaternion rotation = transform.rotation;

        // 기존 오브젝트 파괴
        Destroy(gameObject);

        // 새로운 프리팹 생성 및 위치, 회전값 적용
        Instantiate(replacementPrefab, position, rotation);
    }
}

