using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
    public GameObject playerObj_;

    int status;
    public float speedM;
    int direction;
    public float rot_direction;
    Vector3 pos_;
    bool classic;

    void Start()
    {
        status = 0;
        speedM = 5.0f;
        classic = true;
    }

    void Update()
    {
        InputHandler();
        StateMachine();
    }

    void InputHandler()
    {
        if (Input.GetKey(KeyCode.A))
        {
            status = 2;
            rot_direction = -0.5f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            status = 2;
            rot_direction = 0.5f;
        }

        if (Input.GetKey(KeyCode.W))
        {
            status = 1;
            direction = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            status = 1;
            direction = -1;
        }
    }

    private void StateMachine()
    {
        if(classic == true)
        {
            switch (status)
            {

                //--- Repose ---//

                case 0:

                    break;

                //--- Forward movement ---//

                case 1:
                    playerObj_.transform.Translate(Vector3.forward * speedM * direction * Time.deltaTime);

                    if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
                        status = 0;
                    if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
                        status = 2;

                    break;

                //--- Rotation Normal ---//

                case 2:
                    playerObj_.transform.Rotate(0, rot_direction, 0, Space.Self);

                    if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
                        status = 0;
                    if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.W))
                        status = 1;

                    break;
            }
        }
        
    }
}
