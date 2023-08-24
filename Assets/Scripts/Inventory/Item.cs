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

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            alert_.text = "Press E to grab";
        else { alert_.text = ""; }
    }
}
