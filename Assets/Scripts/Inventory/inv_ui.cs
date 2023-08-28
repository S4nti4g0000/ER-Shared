using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class inv_ui : MonoBehaviour
{
    public InventoryObject mainInv_;    

    public int xStart;
    public int yStart;
    public int ui_X_SPACE;
    public int ui_Y_SPACE;
    public int ui_COLUMN;

    Dictionary<InventorySlot, GameObject> itDisplayed = new Dictionary<InventorySlot, GameObject>();
    void Start()
    {
        CreateDisplay();
    }

    void Update()
    {
        UpdateDisplay();
    }
    public void CreateDisplay()
    {
        for(int i = 0; i < mainInv_.container.Count; i++)
        {
            var obj = Instantiate(mainInv_.container[i].item_.prefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            obj.GetComponentInChildren<TextMeshProUGUI>().text = mainInv_.container[i].ammount.ToString("n0");
            itDisplayed.Add(mainInv_.container[i], obj);
        }
    }
    
    public Vector3 GetPosition(int i)
    {
        return new Vector3(xStart+(ui_X_SPACE *(i % ui_COLUMN)), yStart+(-ui_Y_SPACE * (i/ui_COLUMN)), 0);
    }

    public void UpdateDisplay()
    {
        for(int i = 0; i < mainInv_.container.Count; i++)
        {
            if (itDisplayed.ContainsKey(mainInv_.container[i]))
            {
                itDisplayed[mainInv_.container[i]].GetComponentInChildren<TextMeshProUGUI>().text = mainInv_.container[i].ammount.ToString("n0");
            }
            else
            {
                var obj = Instantiate(mainInv_.container[i].item_.prefab, Vector3.zero, Quaternion.identity, transform);
                obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
                obj.GetComponentInChildren<TextMeshProUGUI>().text = mainInv_.container[i].ammount.ToString("n0");
                itDisplayed.Add(mainInv_.container[i], obj);
            }
        }
    }
}
