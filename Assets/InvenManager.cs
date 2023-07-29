using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvenManager : Singleton<InvenManager>
{
    public InvenSlot[] invenSlot;
    public SlotData currItemName;

    private void Awake()
    {
        foreach(var slot in invenSlot)
        {
            slot.ClearImage();
        }

        SetCurrName(invenSlot[0].GetSlot());
    }


    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            foreach (var slot in invenSlot)
            {
                slot.ClearImage();
            }

            SetCurrName(invenSlot[0].GetSlot());
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            foreach (var slot in invenSlot)
            {
                slot.ClearImage();
            }

            SetCurrName(invenSlot[1].GetSlot());
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            foreach (var slot in invenSlot)
            {
                slot.ClearImage();
            }

            SetCurrName(invenSlot[2].GetSlot());
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            foreach (var slot in invenSlot)
            {
                slot.ClearImage();
            }
            SetCurrName(invenSlot[3].GetSlot());
        }
    }

    private void SetCurrName(SlotData data)
    {
        currItemName.itemName = data.itemName;
        Debug.Log("CURR NAME : " + currItemName.itemName);
    }
}
