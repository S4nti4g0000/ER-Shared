using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using System.IO;
using UnityEngine.InputSystem;
using UnityEngine.TextCore.Text;
using TMPro;
using Unity.VisualScripting;

public class Movement : MonoBehaviour
{
    #region JSON declaration
    public DataJSON misDatos;
    string filePat;
    #endregion

    public GameObject playerObj_;

    int status;
    public float speedM;
    int direction;
    public float rot_direction;
    Vector3 pos_;
    GameObject character;
    Vector3 prevPosition;
    bool classic_;

    public GameObject modernCam_cinemachine;
    public GameObject modernCam_main;
    public GameObject classicCam_main;
    public GameObject classicCam_cinemachine;

    private Vector3 previousDirection = Vector3.forward;

    void Start()
    {
        filePat = Application.streamingAssetsPath + "/" + "data1.json";

        status = 0;
        speedM = 5.0f;
        character = this.gameObject;

        modernCam_main.SetActive(false);
        modernCam_cinemachine.SetActive(false);

        if (File.Exists(filePat))
        {
            string s = File.ReadAllText(filePat);
            misDatos = JsonUtility.FromJson<DataJSON>(s);
            classic_ = misDatos.classic;
        }
        

    }

    void Update()
    {
        InputHandler();
        StateMachine();
        prevPosition = character.transform.position;
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
        if(classic_ == true)
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
        else
        {
            classicCam_main.SetActive(false);
            classicCam_cinemachine.SetActive(false);
            modernCam_main.SetActive(true);
            modernCam_cinemachine.SetActive(true);

            if (Input.GetKey(KeyCode.D))
                character.transform.Rotate(0, 0.5f, 0);
            else if (Input.GetKey(KeyCode.A))
                character.transform.Rotate(0, -0.5f, 0);

            // Check for W and S keys
            if (Input.GetKey(KeyCode.S))
                direction = -1;
            else if (Input.GetKey(KeyCode.W))
                direction = 1;
            else
            {
                //--- Slow down ---//

                if (speedM > 0.0f)
                    speedM -= 5.0f * Time.deltaTime;
                else
                    speedM = 0.0f;

                // Reset direction when not moving
                direction = 0;
            }

            if (direction != 0)
            {
                speedM += 4.5f * Time.deltaTime;
                speedM = Mathf.Clamp(speedM, 0.0f, 5.0f);

                character.transform.Translate(Vector3.forward * speedM * direction * Time.deltaTime);
            }


        }

        
        
    }

    private void OnCollisionEnter(Collision collider)
    {
        if(collider.gameObject.CompareTag("world") || collider.gameObject.CompareTag("world"))
        {
            // Reset character position
            character.transform.position = prevPosition;

        }
    }
}
