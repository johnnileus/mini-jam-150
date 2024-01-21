using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfter : MonoBehaviour{

    [SerializeField] private float time;
    // Update is called once per frame
    private void KillSelf(){
        Destroy(gameObject);
    }
    
    private void Start(){
        Invoke(nameof(KillSelf), time);
    }
}
