using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Default Object", menuName = "Inventory System/Items/Default")]

public class DefaultObj : Item
{
    public void Awake()
    {
        type_ = type.Default;
    }
}
