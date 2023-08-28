using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Key", menuName = "Inventory System/Items/Keys")]
public class KeyObj : Item
{
    public bool hasKey;
    public void Awake()
    {
        type_ = type.Key1;
    }
}
