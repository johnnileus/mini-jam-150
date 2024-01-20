using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour{

    [SerializeField] private float timeToLive;
    private float timeSpawned;
    
    
    private Rigidbody rb;

    public void setTimeToLive(float amt){
        timeToLive = amt;
    }
    
    // Start is called before the first frame update
    void Start(){
        rb = gameObject.GetComponent<Rigidbody>();
        timeSpawned = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeSpawned + timeToLive < Time.time) {
            Destroy(gameObject);
        }
    }
}
