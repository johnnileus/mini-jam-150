using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using FixedUpdate = Unity.VisualScripting.FixedUpdate;

public class test : MonoBehaviour
{
    
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float runStamCost;
    [SerializeField] private float dashStrength;
    [SerializeField] private float dashLength;
    [SerializeField] private float dashCost;
    [SerializeField] private float velDamp;
    [SerializeField] private float maxStamina;
    [SerializeField] private float staminaRegen;

    private Rigidbody rb;
    
    // Start is called before the first frame update
    void Start(){
        rb = gameObject.GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate(){
        rb.MovePosition(rb.position + new Vector3(1f,0,0)* Time.deltaTime);
    }
}
