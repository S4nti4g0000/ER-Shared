using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[CreateAssetMenu(fileName ="New Inventory", menuName = "Inventory System/Inventory")]

public class InventoryObject : ScriptableObject, ISerializationCallbackReceiver
{
    public string savePath;

    public ObjectDatabase database;
    public List<InventorySlot> container = new List<InventorySlot>(); 

    public void addItem(Item it_, int amm_)
    {
        bool hasItem = false;

        for(int i  = 0; i < container.Count; i++)
        {
            if (container[i].item_ = it_)
            {
                container[i].addAmmount(amm_);
                break;
            } 
        }
        if (!hasItem)
            container.Add(new InventorySlot(database.GetID[it_], it_, amm_));
    }

    public void OnAfterDeserialize()
    {
        for(int i = 0; i < container.Count;i++)
        {
            container[i].item_ = database.GetItem[container[i].ID];
        }
    }

    public void OnBeforeSerialize()
    {
        
    }

    public void Save()
    {
        string saveData = JsonUtility.ToJson(this, true);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(string.Concat(Application.persistentDataPath, savePath));
        bf.Serialize(file, saveData);
        file.Close();
    }
    public void Load()
    {
        if(File.Exists(Application.persistentDataPath))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(string.Concat(Application.persistentDataPath, savePath), FileMode.Open);
            JsonUtility.FromJsonOverwrite(bf.Deserialize(file).ToString(), this);
            file.Close();
        }

    }

}


[System.Serializable]
public class InventorySlot
{
    public int ID;
    public Item item_;
    public int ammount;

    public InventorySlot(int id_, Item it, int amm)
    {
        ID = id_;
        item_ = it;
        ammount = amm;
    }

    public void addAmmount(int value)
    {
        ammount += value;
    }
}