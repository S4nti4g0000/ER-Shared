using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using System.IO;
using UnityEngine.InputSystem;
using TMPro;

public class gameAdmin : MonoBehaviour
{

    public DataJSON misDatos;

    public GameObject menu;
    public GameObject opmen;

    public TMP_Text nameDisplay;
    public TMP_InputField inputField;

    string filePat;

    void Start()
    {
        filePat = Application.streamingAssetsPath + "/" + "data1.json";
        

        if (File.Exists(filePat))
        {
            string s = File.ReadAllText(filePat);
            misDatos = JsonUtility.FromJson<DataJSON>(s);
            nameDisplay.text = misDatos.nombre_jugador;
        }
    }

    public void saveName()
    {
        if (File.Exists(filePat))
        {
            misDatos.nombre_jugador = inputField.text;
            nameDisplay.text = misDatos.nombre_jugador;

            string s = JsonUtility.ToJson(misDatos, true);
            File.WriteAllText(filePat, s);
        }
        inputField.text = "";
    }
    public void nextLevel()
    {
        SceneManager.LoadScene(sceneName: "FirstLevel");
    }
}