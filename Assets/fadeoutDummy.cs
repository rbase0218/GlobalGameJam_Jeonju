using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadeoutDummy : MonoBehaviour
{
    private void Awake()
    {
        FadeManager.Instance.FadeOut(1f);
    }
}
