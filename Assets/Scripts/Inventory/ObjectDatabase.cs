using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item Database", menuName = "Inventory System/Items/Database")]
public class ObjectDatabase : ScriptableObject, ISerializationCallbackReceiver
{

    public Item[] items_;
    public Dictionary<Item, int> GetID = new Dictionary<Item, int>();
    public Dictionary<int, Item> GetItem = new Dictionary<int, Item>();

    public void OnAfterDeserialize()
    {
        GetID = new Dictionary<Item, int>();
        GetItem = new Dictionary<int, Item>();
        for (int i = 0; i < items_.Length; i++)
        {
            GetID.Add(items_[i], i);
            GetItem.Add(i, items_[i]);
        }
    }

    public void OnBeforeSerialize()
    {
        
    }
}
