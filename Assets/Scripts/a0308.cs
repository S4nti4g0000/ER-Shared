using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class a0308 : MonoBehaviour
{
    // Start is called before the first frame update
    public bool onGround;
    public int estado;
    //0=reposo
    //1: saltando
    public float potencia;
    public float multiplicador;
    void Start()
    {
        onGround = false;
        estado = 0;
        potencia = 0;
        //GameObject.Find("Sphere").GetComponent<a0308>().estado = 0;
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine();
    }

    void stateMachine()
    {
        switch (estado)
        {
            case 0: //reposo
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    estado = 1;
                    potencia = 0;
                }
                break;
            case 1: //impulsando
                potencia = potencia + Time.deltaTime*multiplicador;
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    estado = 2;
                }
                break;
            case 2:
                this.GetComponent<Rigidbody>().AddForce(new Vector3(0, potencia, 0));
                estado = 3;
                break;
            case 3: // en el aire
                if (onGround)
                {
                    estado = 0;
                    potencia = 0;
                }
                break;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        onGround = true;
        estado = 0;
    }

    private void OnCollisionExit(Collision collision)
    {
        onGround = false;
        estado = 1;
    }

    

}
