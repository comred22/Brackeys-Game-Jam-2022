using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This is a way to Contain all possible player sprite and what makes a player
/// first a Player Has a controler and a sprite 
/// The goal is to code each diffrent Robot with a mechanic
/// 
/// Thus when you die or swap to one this handels all possible player sprites. 
/// 
/// So the Sprite "Model" will contain the ablities scripts
/// <summary>
public abstract class AbstractPlayer : MonoBehaviour
{
    [SerializeField] protected GameObject playerControls;
    [SerializeField] protected GameObject Spirte;

    protected int index = 0;
    public GameObject getPlayerControls()
    {
        return playerControls;
    }
    public void setPlayerControls(GameObject x)
    {
        playerControls = x;
    }
    public GameObject getSpirte()
    {
        return Spirte;
    }
    public void setSpirte(GameObject x)
    {
        Spirte = x;
    }
}

