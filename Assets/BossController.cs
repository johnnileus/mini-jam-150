using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour{

    [SerializeField] private int health;

    [SerializeField] private GameObject lightningEffect;
    
    public void AttackBoss(){
        health--;
        Instantiate(lightningEffect, transform.position, Quaternion.identity);
        print($"boss health: {health}");
        if (health <= 0) {
            LevelManager.instance.SetNextLevelMenuActive(true);
            LevelManager.instance.SetPlayerState(true);
            Destroy(gameObject);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
