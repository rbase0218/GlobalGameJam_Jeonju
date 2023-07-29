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
    public Image defaultImg;

    public Sprite DisableImg;
    public Sprite ActiveImage;
    
    private void Awake()
    {
        defaultImg = GetComponent<Image>();

        //InvenManager.Instance.currItemName.itemName;

    }

    public SlotData GetSlot()
    {
        // �̹��� ���̾ƿ� ó��
        defaultImg.sprite = ActiveImage;
        
        return slotName;
    }

    public void ClearImage()
    {
        defaultImg.sprite = DisableImg;
    }
}
