using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TreeColHandler : MonoBehaviour
{
    // 감소시킬 값의 초기 값
        public int initialValue = 5;
    // 충돌시 감소할 값
    public int decreaseAmount = 1;

    private int currentValue;

    private void Start()
    {
        currentValue = initialValue;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 충돌한 물체의 태그가 "특정태그"인 경우에만 감소
        if (collision.gameObject.CompareTag("Enemy"))
        {
            currentValue -= decreaseAmount;
            Debug.Log("값이 감소했습니다. 현재 값: " + currentValue);
        }
    }
}