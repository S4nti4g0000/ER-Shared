using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour


{
    public CharacterController controller;
    public float speed = 3.5f;
    public float gravity = 9.81f;
    public GameObject _muzzleFlash;
    public GameObject _hitMarkerPrefab;
    public AudioSource _weaponAudio;



    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetMouseButton(0))

        {
            _muzzleFlash.SetActive(true);
            _weaponAudio.Play();
            Ray rayOrigin = Camera.main.ViewportPointToRay(new Vector3(0.5f,0.5f,0));
            RaycastHit hitInto;

            if (Physics.Raycast(rayOrigin, out hitInto))
            {
                Debug.Log("Hit;" + hitInto.transform.name);
                GameObject hitMarker = Instantiate (_hitMarkerPrefab,hitInto.point, Quaternion.LookRotation(hitInto.normal));
                Destroy(hitMarker, 1f);
            }
            else
            {
                _muzzleFlash.SetActive(false);
                _weaponAudio.Stop();
            }
            if (Physics.Raycast(rayOrigin, Mathf.Infinity))
            {
                Debug.Log("RayCast Hit Something!!");
            }
        }




        if (Input.GetKeyDown  (KeyCode.Escape))

        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }



        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 velocity = direction * speed;
        velocity.y -= gravity;

        velocity = transform.transform.TransformDirection(velocity);
        controller.Move(velocity * Time.deltaTime);
    }
}
