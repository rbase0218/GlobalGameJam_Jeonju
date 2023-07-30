using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;


public class SpiritController : MonoBehaviour
{
    [field: SerializeField] public Transform SpiritBody { get; private set; }


    // MAX TIME = originTimer + offsetTimer

    [field: SerializeField] public float OffsetTimer { get; private set; }
    [field: SerializeField] public float MaxTimer { get; private set; }

    private int selector = 0;

    // Selector Timer
    private float timer = .0f;
    private float MAX = .0f;

    // 1. Idle
    public List<Vector3> bezierPoints;
    public List<Transform> spotPoint;

    private bool isStartCoroutine = false;

    // 2. Movement
    public float radiusOffset = .0f;
    public Vector3 targetPos;
    private bool isMove = false;
    public float moveTime = .0f;

    public Vector3 middlePos;

    // 3. Stop
    private bool isStop = false;

    // 5. Around
    public Transform startPos;
    public Transform endPos;

    // But used to Animation Curves
    // 3. Selector

    private void Awake()
    {
        MAX = SetMaxTimer(MaxTimer, UpdateTimer());

        for (int i = 0; i < spotPoint.Count; ++i)
        {
            Vector3 t = spotPoint[i].localPosition;
            t.y = SpiritBody.localPosition.y;

            spotPoint[i].localPosition = t;
        }

        // IdleMovement();
    }

    private void OnEnable()
    {
        if(gameObject.activeSelf)
            IdleMovement();
    }

    private void Update()
    {
        if (timer >= MAX && !isMove && !isStartCoroutine && !isStop)
        {
            timer = .0f;
            MAX = SetMaxTimer(MaxTimer, UpdateTimer());

            // 0 - Idle
            // 1 - Movement
            selector = UnityEngine.Random.Range(0, 2);
            //selector = 1;
        }

        if(isStop)
        {
            StopCoroutine("Move");
            StopCoroutine("CurveMove");

            isStartCoroutine = isMove = false;
        }

        //if (Input.GetKeyDown(KeyCode.A))
        //    IdleMovement();
        //if (Input.GetKeyDown(KeyCode.D))
        //    Movement();

        if(!isStop)
            timer += Time.deltaTime;
    }

    private void FixedUpdate()
    {
        if (!isStop)
        {
            switch (selector)
            {
                case 0:
                    if (!isStartCoroutine)
                        IdleMovement();
                    break;

                case 1:
                    if (!isMove)
                        Movement();
                    break;
            }
        }
    }

    private float SetMaxTimer(float max, float offset)
    {
        return max + offset;
    }

    private void IdleMovement()
    {
        Debug.Log("IDLE!");

        isStartCoroutine = true;

        StartCoroutine("CurveMove");
    }

    private void Movement()
    {
        Debug.Log("MOVE!");

        isMove = true;

        targetPos = new Vector3(UnityEngine.Random.Range(-radiusOffset, radiusOffset + 1), 0, UnityEngine.Random.Range(-radiusOffset, radiusOffset + 1));
        targetPos.y = SpiritBody.transform.position.y;

        StartCoroutine("Move");
    }

    private void Movement(Vector3 target)
    {
        Debug.Log("MOVE! - Target Ver");

        isMove = true;

        targetPos = target;
        targetPos.y = SpiritBody.transform.position.y;

        StartCoroutine("Move");
    }

    private IEnumerator Move()
    {
        float time = 0f;

        SpiritBody.LookAt(targetPos);

        var localPos = SpiritBody.position;

        middlePos.y = 3f;

        middlePos = new Vector3(targetPos.x, middlePos.y, 0f);

        //test[0].transform.position = localPos;
        //test[1].transform.position = middlePos;
        //test[2].transform.position = targetPos;

        // 거리 / 속도 = 시간
        float speeed = .0f;

        speeed = (Vector3.Distance(localPos, targetPos) < 3) ? 5f : 10f;
        moveTime = Vector3.Distance(localPos, targetPos) / speeed;

        // 방향을 구함.
        SpiritBody.LookAt(targetPos);

        while (true)
        {
            if (time > 1f)
            {
                time = 0f;

            }

            Vector3 v1 = Vector3.Lerp(localPos, middlePos, time);
            Vector3 v2 = Vector3.Lerp(middlePos, targetPos, time);

            SpiritBody.position = Vector3.Lerp(v1, v2, time);

            time += Time.deltaTime / moveTime;

            yield return null;

            if ((targetPos - SpiritBody.position).sqrMagnitude < 2.0f)
            {
                isMove = false;

                StopCoroutine("Move");

                break;
            }
        }
    }

    private IEnumerator CurveMove()
    {
        float time = 0f;
        int spotProcess = 0;

        Vector3[] dummyPos = new Vector3[12];

        for (int i = 0; i < spotPoint.Count; ++i)
        {
            dummyPos[i] = spotPoint[i].position;
            dummyPos[i].y = 3f;
        }

        while (true)
        {
            Vector3 v1 = Vector3.Lerp(dummyPos[0], dummyPos[1], time);
            Vector3 v2 = Vector3.Lerp(dummyPos[1], dummyPos[2], time);

            Vector3 v3 = Vector3.Lerp(dummyPos[2], dummyPos[3], time);
            Vector3 v4 = Vector3.Lerp(dummyPos[3], dummyPos[0], time);

            Vector3 v5 = Vector3.Lerp(dummyPos[0], dummyPos[4], time);
            Vector3 v6 = Vector3.Lerp(dummyPos[4], dummyPos[5], time);

            Vector3 v7 = Vector3.Lerp(dummyPos[5], dummyPos[6], time);
            Vector3 v8 = Vector3.Lerp(dummyPos[6], dummyPos[0], time);

            switch (spotProcess)
            {
                case 0:
                    SpiritBody.position = Vector3.Lerp(v1, v2, time);
                    break;

                case 1:
                    SpiritBody.position = Vector3.Lerp(v3, v4, time);
                    break;

                case 2:
                    SpiritBody.position = Vector3.Lerp(v5, v6, time);
                    break;

                case 3:
                    SpiritBody.position = Vector3.Lerp(v7, v8, time);
                    break;
            }

            time += Time.deltaTime / 1f;

            if (time > 1f)
            {
                time = 0f;
                spotProcess++;
            }

            yield return null;

            if (spotProcess >= 4)
            {
                isStartCoroutine = false;

                StopCoroutine("CurveMove");

                break;
            }
        }
    }
    private float UpdateTimer()
    {
        return UnityEngine.Random.Range(-OffsetTimer, (OffsetTimer + 1f));
    }


    // 3. Stop
    public void SetStop()
    {
        isStop = true;
    }

    public void SetMove()
    {
        isStop = false;
    }

    // 4. Target Move

    public void SetTargetMove(Vector3 target)
    {
        Movement(target);
    }

    // 5. Trap
    public GameObject testObj;

    // 원의 Center, 원의 반지름
    public void SetAround(Vector3 startPos, Vector3 endPos)
    {
        //StartCoroutine(StartAroundMove(startPos, endPos));
    }

    public float objSpeed = 10f;
    public int rotateNum = 0;
    private IEnumerator StartAroundMove(Vector3 startPos, Vector3 endPos)
    {
        SetStop();

        float deg = .0f;
        float radius = Vector3.Distance(endPos, startPos) / 2;


        while (true)
        {
            deg += Time.deltaTime * objSpeed;

            if (deg < 360)
            {
                var rad = Mathf.Deg2Rad * (deg);
                var x = radius * Mathf.Sin(rad);
                var y = radius * Mathf.Cos(rad);

                var dummyPos = ((endPos + startPos) / 2) + new Vector3(x, 0, y);
                dummyPos.y = SpiritBody.position.y;

                SpiritBody.position = dummyPos;
                SpiritBody.rotation = Quaternion.Euler(0, 0, deg * -1); //가운데를 바라보게 각도 조절
            }
            else
            {
                rotateNum++;
                deg = 0;

                if(rotateNum >= 5)
                {
                    SetMove();
                    break;
                }

            }

            yield return null;
        }

    }
}
