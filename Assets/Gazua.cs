using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gazua : MonoBehaviour
{
    public void SelectFunc()
    {
        SceneController.Instance.OnChangeScene("InGameScene");
    }
}
