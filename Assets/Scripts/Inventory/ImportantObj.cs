using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Important Object", menuName = "Inventory System/Items/Objects"
    )]
public class ImportantObj : Item
{
    public bool canPass;
    public void Awake()
    {
        type_ = type.Important_Object1;
    }
}
