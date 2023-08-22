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

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        filePat = Application.streamingAssetsPath + "/" + "data1.json";

        if (File.Exists(filePat))
        {
            string s = File.ReadAllText(filePat);
            misDatos = JsonUtility.FromJson<DataJSON>(s);
            livesNum = misDatos.lives;
            livesTxt.SetText("Lives: " + livesNum.ToString());
        }

    }
}
