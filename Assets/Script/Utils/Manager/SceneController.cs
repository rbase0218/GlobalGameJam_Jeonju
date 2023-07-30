using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : Singleton<SceneController>
{
    private AsyncOperation oper = new AsyncOperation();

    public void OnChangeScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);

        //   StartCoroutine("ChangeScene", SceneName);
    }
    private IEnumerator ChangeScene(string SceneName)
    {
        FadeManager.Instance.FadeIn(1f);

        oper.allowSceneActivation = false;

        while (!oper.isDone)
        {

            if (oper.progress >= 0.9f)
            {
                NextScene();
            }

            yield return null;
        }
    }

    private void NextScene()
    {
        oper.allowSceneActivation = true;
    }
}
