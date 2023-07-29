using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneAfterLoad : MonoBehaviour
{

    public void Awake()
    {
        FadeManager.Instance.FadeOut(1f);
    }
}
