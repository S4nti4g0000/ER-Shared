using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

using System.IO;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public DataJSON misDatos;

    public GameObject opMen;
    public TMP_Text txt;
    public UnityEngine.UI.Slider slider;
    bool actClassic;

    string filePat;

    void Awake()
    {
        opMen.SetActive(false);
        filePat = Application.streamingAssetsPath + "/" + "data1.json";

        if (File.Exists(filePat))
        {
            string s = File.ReadAllText(filePat);
            misDatos = JsonUtility.FromJson<DataJSON>(s);
            txt.text = misDatos.optionsText_movement;
            slider.value = misDatos.moveValue;
        }

        
    }
    public void OnValueChanged()
    {
        if (slider.value == 0)
        {
            misDatos.classic = true;
            misDatos.optionsText_movement = "Classic";
            txt.text = misDatos.optionsText_movement;
            misDatos.moveValue = 0;
            string s = JsonUtility.ToJson(misDatos, true);
            File.WriteAllText(filePat, s);
        }
        else
        {
            misDatos.classic = false;
            misDatos.optionsText_movement = "Modern";
            txt.text = misDatos.optionsText_movement;
            misDatos.moveValue = 1;
            string s = JsonUtility.ToJson(misDatos, true);
            File.WriteAllText(filePat, s);
        }
    }
}
