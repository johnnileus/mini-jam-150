using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour{

    [SerializeField] private float timeToLive;
    private float timeSpawned;

    private Vector3 lastPos;
    
    private Rigidbody rb;
    private Transform projModel;

    public void setTimeToLive(float amt){
        timeToLive = amt;
    }
    
    // Start is called before the first frame update
    void Start(){
        rb = gameObject.GetComponent<Rigidbody>();
        timeSpawned = Time.time;
        lastPos = transform.position;
        projModel = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (LevelManager.instance.GetPlayerState()) {
            Destroy(gameObject);
        }
        
        if (timeSpawned + timeToLive < Time.time) {
            Destroy(gameObject);
        }
        
        projModel.LookAt(transform.position*2 - lastPos);
        lastPos = transform.position;
    }

    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player")) {
            other.GetComponent<PlayerHealth>().DamagePlayer();
        }
    }
}
