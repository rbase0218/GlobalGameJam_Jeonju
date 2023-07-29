using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct SlotData
{
    public string itemName;
}

public class InvenSlot : MonoBehaviour
{
    public SlotData slotName;
    private Image currImage;

    public Sprite[] spr;

    private void Awake()
    {
        currImage = GetComponent<Image>();
    }

    public SlotData GetSlot()
    {
        // 이미지 레이아웃 처리
        currImage.sprite = spr[1];
        return slotName;
    }

    public void ClearImage()
    {
        currImage.sprite = spr[0];
    }
}
