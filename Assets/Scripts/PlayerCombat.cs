using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PlayerCombat : MonoBehaviour{

    [SerializeField] private int maxHealth;
    [SerializeField] private int fagHealAmt;
    [SerializeField] private int attackHealthCost;
    private int currentHealth;

    private float timeLitFag;
    [SerializeField]private float timeToUnlight;
    public bool fagLit;
    public bool canMove = true;

    [SerializeField] private Slider hpSlider;

    public void DamagePlayer(int dmg){
        currentHealth -= dmg;
        //update UI
        if (currentHealth <= 0) {
            KillPlayer();
        }

        updateHealthUI();
    }


    private void updateHealthUI (){
        hpSlider.value = (float)currentHealth / maxHealth;
        print($"{currentHealth} {maxHealth} {currentHealth/maxHealth}");
    }
    
    private void AttackBoss(){
        if(currentHealth - attackHealthCost <= 0)
        {
            print(currentHealth - attackHealthCost);
            return;
        }
        DamagePlayer(attackHealthCost);
        GameObject.FindWithTag("Enemy").GetComponent<BossController>().AttackBoss();
    }
    
    private void KillPlayer(){
        GameObject.FindWithTag("LevelManager").GetComponent<LevelManager>().KillPlayer();
    }

    private void LightCiggy(){
        print("cig lit");
        timeLitFag = Time.time;
        fagLit = true;
        currentHealth += fagHealAmt;

        if (currentHealth >= maxHealth) currentHealth = maxHealth;

        updateHealthUI();

        //animate lighting the fag
        //have lit fag
    }

    private void UnlightFag(){
        print("cig unlit");
        fagLit = false;
        //animate fag dimming
    }
    
    // Start is called before the first frame update
    void Start(){
        currentHealth = maxHealth;
        timeLitFag = Time.time;
        updateHealthUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            if(canMove)
                AttackBoss();
        }

        if (fagLit && timeLitFag + timeToUnlight < Time.time) {
            UnlightFag();
            canMove = true;
        }
        
        if (!fagLit && Input.GetKeyDown(KeyCode.R)) {
            print("ciggy lit");
            LightCiggy();
            canMove = false;
        }
        
    }
}
