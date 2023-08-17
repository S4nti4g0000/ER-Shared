using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System.IO;
using UnityEngine.InputSystem;
using TMPro;

public class gameAdmin : MonoBehaviour
{
    public int lives_;
    public int level_;

    public DataJSON misDatos;
    public Vector2 movimiento;

    public TMP_Text nameDisplay;
    public TMP_Text livesDisplay;
    public TMP_InputField inputField;

    string s;
    string filePat;

    // Start is called before the first frame update
    void Start()
    {
        filePat = Application.streamingAssetsPath + "/" + "data1.json";
        

        if (File.Exists(filePat))
        {
           s = File.ReadAllText(filePat);
           misDatos = JsonUtility.FromJson<DataJSON>(s);
           nameDisplay.text = misDatos.nombre_jugador;
           lives_ = misDatos.lives; 
           level_ = misDatos.lvlNum;
           livesDisplay.SetText("Lives: " + lives_.ToString() + "\n Level: " + level_.ToString());

        }
        
    }

    void Update()
    {
       
    }

    public void saveName()
    {
        if(File.Exists(filePat))
        {
            misDatos.nombre_jugador = inputField.text;
            nameDisplay.text = misDatos.nombre_jugador;
                       
            s = JsonUtility.ToJson(misDatos, true);
            File.WriteAllText(filePat,s);
        }
    }
}
