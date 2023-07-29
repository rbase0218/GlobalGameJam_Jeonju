using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ScaleBounce : MonoBehaviour
{
    public GameObject[] objects;
    public float scale = 1.1f;
    public float animationDuration = 0.5f;
    public float Delay = 0.5f;
    public Ease ease = Ease.InOutSine;

    private List<Vector3> scaleSaver = new List<Vector3>();

    private void Start()
    {
        foreach (GameObject obj in objects)
        {
            scaleSaver.Add(obj.transform.localScale);

            obj.transform.localScale = Vector3.zero;
        }

        StartCoroutine(ScaleUp());
    }

    [ContextMenu("Start Scaling")]
    public void StartScaling()
    {
        foreach (GameObject obj in objects)
        {
            scaleSaver.Add(obj.transform.localScale);

            obj.transform.localScale = Vector3.zero;
        }

        StartCoroutine(ScaleUp());
    }

    private IEnumerator ScaleUp()
    {
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].transform.DOScale(scaleSaver[i], animationDuration).SetEase(ease);
            yield return new WaitForSeconds(Delay);
        }
    }
}
