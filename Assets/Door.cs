using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{

    public PlayerInv pInv_;
    bool pass;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(pass && Input.GetKey(KeyCode.F))
            SceneManager.LoadScene("Mercado");
      
            
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Colliding");
        if (Input.GetKey(KeyCode.F))
        {
            SceneManager.LoadScene("Mercado");
            pass = true;
        }
    }
}
