using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button1234 : MonoBehaviour
{
    public void One()
    {
        GameManager.Instance.ResumeGame();
    }

    public void Two()
    {
        GameManager.Instance.ExitGame();
    }
}
