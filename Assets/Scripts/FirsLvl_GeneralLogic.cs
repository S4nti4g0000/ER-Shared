using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.InputSystem;
using UnityEngine.TextCore.Text;
using TMPro;

public class FirsLvl_GeneralLogic : MonoBehaviour
{

    #region JSON declaration
    public DataJSON misDatos;
    string filePat;
    #endregion

    public TMP_Text livesTxt;
    int livesNum;

    public GameObject invPanel;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        invPanel.SetActive(false);

        filePat = Application.streamingAssetsPath + "/" + "data1.json";

        if (File.Exists(filePat))
        {
            string s = File.ReadAllText(filePat);
            misDatos = JsonUtility.FromJson<DataJSON>(s);
            livesNum = misDatos.lives;
            livesTxt.SetText("Lives: " + livesNum.ToString());
        }

    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
            invPanel.SetActive(true);

        if(invPanel.activeSelf == true)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }else {Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked; }
    }
}
