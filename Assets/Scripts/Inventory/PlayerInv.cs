using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.InputSystem;
using UnityEngine.TextCore.Text;
using TMPro;
using UnityEngine.UI;

public class PlayerInv : MonoBehaviour
{
    #region JSON declaration
    public DataJSON misDatos;
    string filePat;
    #endregion

    public InventoryObject mainInventory;
    //public AudioSource soundEffect;

    public bool canPass;

    private void Start()
    {
        if (File.Exists(filePat))
        {
            string s = File.ReadAllText(filePat);
            misDatos = JsonUtility.FromJson<DataJSON>(s);
            canPass = misDatos.hasKey;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (File.Exists(filePat))
        {
            misDatos.hasKey = true;

            string s = JsonUtility.ToJson(misDatos, true);
            File.WriteAllText(filePat, s);
        }
        var item = other.GetComponent<keyIT>();
        if (item != null)
        {
            mainInventory.addItem(item.keyItem, 1);
            Destroy(other.gameObject);

            

            SceneManager.LoadScene("Juego");
        }
        if(other.CompareTag("Door"))
        {

        }
    }

    private void OnApplicationQuit()
    {
        mainInventory.Save();
        mainInventory.container.Clear();
    }  

}
