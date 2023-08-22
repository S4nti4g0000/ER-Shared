using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.IO;

public class CamSwitch : MonoBehaviour
{
    #region JSON declaration
    DataJSON misDatos;
    string filePat;
    #endregion

    public GameObject cinemachine;
    public GameObject Main_cinemachine;
    GameObject camera;
    GameObject player;
    public string cam_name;
    bool classicCam;

    void Start()
    {
        filePat = Application.streamingAssetsPath + "/" + "data1.json";


        camera = GameObject.Find(cam_name);
        player = GameObject.Find("Capsule");

        if (File.Exists(filePat))
        {
            string s = File.ReadAllText(filePat);
            misDatos = JsonUtility.FromJson<DataJSON>(s);
            classicCam = misDatos.classic;
        }

    }

    void Update()
    {
        if (classicCam == true)
        {
            Main_cinemachine.SetActive(true);
            camera.SetActive(false);
            cinemachine.SetActive(false);
        }
        else
        {
            Main_cinemachine.SetActive(false);
            camera.SetActive(false);
            cinemachine.SetActive(false);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject == player)
        {
            this.gameObject.SetActive(false);
            camera.SetActive(true);
            cinemachine.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(true);
            camera.SetActive(false);
            cinemachine.SetActive(false);
        }
     
    }
}
