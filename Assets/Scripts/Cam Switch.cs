using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitch : MonoBehaviour
{
    public GameObject cinemachine;
    GameObject camera;
    GameObject player;
    public string cam_name;

    void Start()
    {
        camera = GameObject.Find(cam_name);
        player = GameObject.Find("Capsule");
    }

    void Update()
    {
            camera.SetActive(false);
            cinemachine.SetActive(false);
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
