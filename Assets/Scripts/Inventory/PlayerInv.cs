using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInv : MonoBehaviour
{
    public InventoryObject mainInventory;
    public AudioSource soundEffect;

    public void OnTriggerEnter(Collider other)
    {
        var item = other.GetComponent<keyIT>();
        if (item != null)
        {
            mainInventory.addItem(item.keyItem, 1);
            Destroy(other.gameObject);  
        }

        soundEffect.Play();

    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P)) 
        {
            mainInventory.Save();
            Debug.Log("Saved!");
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            mainInventory.Load();
            Debug.Log("Loaded!");
        }
    }

    private void OnApplicationQuit()
    {
        mainInventory.container.Clear();
    }  

}
