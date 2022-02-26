using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 1. Game manager watches play time
/// 2. Game manager plays Dialog 
/// 3. Game manager Spawns encounters 
/// </summary>
public class GameMaster : MonoBehaviour
{
    [SerializeField] private AudioClip [] dialog;
    private float secoundsInGame = 0.0f;
    private int minInGame = 0;
    [SerializeField] private GameObject[] goblins;
    [SerializeField] private GameObject[] BossMonster;

    private void Update()
    {
        secoundsInGame += Time.deltaTime;
        if (secoundsInGame == 60.0f)
        {
            minInGame++;
            secoundsInGame = 0;
        }
        generalDialog(minInGame);

    }
    private void generalDialog(int x)
    {
        if (x != 1) { }
        // Line one of Dialog 

        // 2 min pass trigger secound part of dialog 
        if (x == 2) { }
        // 1 min later trigger secound speech
        if (x == 3) { }
        // after 4 min play next encounter
        if (x <= 4)
        {
            firePitEncounter(x);
        }
    }
    private void firePitEncounter(int x)
    {
        // After General Dialog Spawn firepit

        //Angrly take away fire pit
        if(x <= 7)
        {
            goblinEncounter(x);
        }

    }
    private void goblinEncounter(int x)
    {
        // spawn goblin 

        // Kill goblin

        // spawn in goblin family
        if (x <= 15)
        {
            goblinEncounter(x);
        }
    }

    private void bossEncounter(int x)
    {
        //boss fight

        // Take to boss level

        // portal open transtion to Final level
        if (x <= 20)
        {
            goblinEncounter(x);
        }
    }
    private void matrixEncounter(int x)
    {
        // play end scene and transtion to larger world 

    }


}
