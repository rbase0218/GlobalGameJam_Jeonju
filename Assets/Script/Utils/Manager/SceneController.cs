using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : Singleton<SceneController>
{
    private AsyncOperation oper = new AsyncOperation();

    public void OnChangeScene(string SceneName)
    {
        StartCoroutine("ChangeScene", SceneName);
    }
    private IEnumerator ChangeScene(string SceneName)
    {
        FadeManager.Instance.FadeIn(1f, NextScene);

        oper = SceneManager.LoadSceneAsync(SceneName, LoadSceneMode.Single);
        oper.allowSceneActivation = false;

        while (!oper.isDone)
        {
            yield return null;
        }
    }

    private void NextScene()
    {
        oper.allowSceneActivation = true;
    }
}
