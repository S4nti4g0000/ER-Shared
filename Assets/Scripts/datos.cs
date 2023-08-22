using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Serialization;

[System.Serializable]
public class DataJSON : System.Object
{

    [SerializeField]
    public string nombre_jugador, optionsText_movement;
    [SerializeField]
    public bool classic, hasKey,alive;
    [SerializeField]
    public int lives, attempts, lvlNum, itemsInv, moveValue;
    
    public DataJSON()
    {
    }

    public DataJSON(string jugador_, bool alive_, 
        int lives_, int attempts_, 
        bool hasKey_, int lvlNum_, 
        int itemsInv_, bool classic_, 
        string opText_, int moveValue_)
    {
        this.nombre_jugador = jugador_;
        this.alive = alive_;
        this.lives = lives_;
        this.attempts = attempts_;
        this.hasKey = hasKey_;
        this.lvlNum = lvlNum_;
        this.itemsInv = itemsInv_;
        this.classic = classic_;
        this.optionsText_movement = opText_;
        this.moveValue = moveValue_;
    }

    //-- Getters --//
    int getLives()
    {
        return lives;
    }
    int getAttempts()
    {
        return attempts;
    }
    int getLevel()
    {
        return lvlNum;
    }
    int getItems()
    {
        return itemsInv;
    }
    
    //-- Setters --//

    void setAlive(bool al) 
    {
        alive = al;
    }
    void setKey(bool key) 
    {
        hasKey = key;
    }
    void setItems(int it) 
    {
        itemsInv = it;
    }

}