using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Dissolve : MonoBehaviour
{
    public Material[] DissolveMaterial;
    public float animationSpeed;
    public string transparencyPropertyName = "_Dissolve";

    private void Start()
    {
        foreach (Material mat in DissolveMaterial)
        {
            mat.SetFloat(transparencyPropertyName, 1);
        }
    }

    //Turns portal on
    [ContextMenu("Turn On")]
    public void TurnOn()
    {
        foreach (Material mat in DissolveMaterial)
        {
            mat.DOFloat(1, transparencyPropertyName, animationSpeed);
        }
    }


    //Turns portal off
    [ContextMenu("Turn Off")]
    public void TurnOff()
    {
        foreach (Material mat in DissolveMaterial)
        {
            mat.DOFloat(0, transparencyPropertyName, animationSpeed);
        }
    }
}
