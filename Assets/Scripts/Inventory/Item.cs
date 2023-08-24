using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;

public class Item : MonoBehaviour
{
    public TMP_Text alert_;
    private bool inTrigger;

    void Start()
    {
        inTrigger = false;        
    }

    // Update is called once per frame
    void Update()
    {
        if(inTrigger == true && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Pressed e inside trigger");
            Destroy(this.gameObject);
            alert_.text = "";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            alert_.text = "Press E to grab";

            inTrigger = true;
        }
            
        else { alert_.text = ""; }

        
            
    }
}
