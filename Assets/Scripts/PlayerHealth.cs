using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour{

    private int currentHealth;


    public void DamagePlayer(){
        currentHealth--;
        //update UI
        if (currentHealth <= 0) {
            KillPlayer();
        }
    }

    public void KillPlayer(){
        GameObject.FindWithTag("LevelManager").GetComponent<LevelManager>().KillPlayer();
    }
    
    // Start is called before the first frame update
    void Start(){
        currentHealth = 300;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
