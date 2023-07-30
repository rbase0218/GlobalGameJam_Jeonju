using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text seedsText;
    public TMP_Text spiritsText;

    private readonly string defaultText = " X ";

    public void SetSeedText(string text)
    {
        seedsText.text = defaultText + text;
    }

    public void SetSpiritText(string text)
    {
        spiritsText.text = defaultText + text;
    }
}
