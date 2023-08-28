using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;

public enum type
{
    Default = 0,
    Key1,
    Important_Object1,

    _LAST_OBJECT_TYPE
}

public class Item : ScriptableObject
{

    public TMP_Text alert_;
    private bool inTrigger;

    public GameObject prefab;
    public type type_;
    public string desc;
}
