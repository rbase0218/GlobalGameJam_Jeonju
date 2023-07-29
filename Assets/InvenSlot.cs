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
        // ï¿½Ì¹ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½Ì¾Æ¿ï¿½ Ã³ï¿½ï¿½
        defaultImg.sprite = ActiveImage;
        
        return slotName;
    }

    public void ClearImage()
    {
        defaultImg.sprite = DisableImg;
    }
}
