using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Serialization;

[System.Serializable]
public class DataJSON : System.Object
{

    [SerializeField]
    public int lives;
    [SerializeField]
    private int attempts;
    [SerializeField]
    public int lvlNum;
    [SerializeField]
    private int itemsInv;
    [SerializeField]
    public string nombre_jugador;
    [SerializeField]
    public bool alive;
    [SerializeField]
    public bool hasKey;
    
    public DataJSON()
    {
    }

    public DataJSON(int lives_, int attempts_, int lvlNum_, int itemsInv_, string jugador_, bool alive_, bool hasKey_)
    { //, Date created_at, Date updated_at) {
        this.lives = lives_;
        this.attempts = attempts_;
        this.itemsInv = itemsInv_;
        this.lvlNum = lvlNum_;
        this.nombre_jugador = jugador_;
        this.alive = alive_;
        this.hasKey = hasKey_;
    }

    //-- Getters --//

    public int getLives()
    {
        return lives;
    }
    public int getAtt()
    {
        return attempts;
    }
    public int getLvl()
    {
        return lvlNum;
    }
    public int getItems()
    {
        return itemsInv;
    }
    public string getPlayer()
    {
        return nombre_jugador;
    }
    public bool getAl()
    {
        return alive;
    }
    public bool getKey()
    {
        return hasKey;
    }

    //-- Setters --//}

    public void setLives(int l)
    {
        lives = l;
    }
    public void setItems(int i)
    {
        itemsInv = i;
    }
    public void setNombre(string N)
    {
        nombre_jugador = N;
    }
    public void setAlive(bool al)
    {
        alive = al;
    }
    

}