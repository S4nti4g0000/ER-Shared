using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class b0308 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject objetivo;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger activo");
        objetivo.GetComponent<a0308>().potencia = 500;
        objetivo.GetComponent<a0308>().estado = 2;
    }
}
