using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gazua : MonoBehaviour
{
    public int nA = 0;

    public void Awake()
    {
        if (nA == 0)
            SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);
    }
    public void SelectFunc()
    {
        SceneController.Instance.OnChangeScene("InGameScene");
    }
}
