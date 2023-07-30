using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gazua : MonoBehaviour
{
    public int nA = 0;

    public void Start()
    {
        if (nA == 0)
        {
            nA++;

            SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);

            //SceneController.Instance.OnChangeScene("MenuScene");
        }
    }

    public void SelectFunc()
    {
        SceneController.Instance.OnChangeScene("InGameScene");
    }
}
