using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour{


    [SerializeField] private ProjectileSO[] projectiles;
    
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float[] lastAttacked;
    
    private int[] curShootIndex; // tracks the next spawn point
    
    // Start is called before the first frame update
    void Start(){
        for (int i = 0; i < projectiles.Length; i++) {
            projectiles[i].projDirection = projectiles[i].projDirection.normalized;
        }
        curShootIndex = new int[projectiles.Length];
        lastAttacked = new float[projectiles.Length];
    }

    // Update is called once per frame
    void Update(){
        for (int i = 0; i < projectiles.Length; i++) {
            ProjectileSO p = projectiles[i];
            if (lastAttacked[i] + p.attackDelay < Time.time) {
                if (p.shootType == ProjectileSO.ShootType.Single) {
                    GameObject proj = Instantiate(p.projectile, spawnPoints[curShootIndex[0]].position, Quaternion.identity);
                    Rigidbody projRB = proj.GetComponent<Rigidbody>();
                    projRB.AddForce(p.projDirection * p.projSpeed);
                    lastAttacked[i] = Time.time;
                    curShootIndex[0] = (curShootIndex[0] + 1) % spawnPoints.Length;
                }
                else if (p.shootType == ProjectileSO.ShootType.Multiple) {
                    for (int j = 0; j < spawnPoints.Length; j++) {
                        GameObject proj = Instantiate(p.projectile, spawnPoints[j].position, Quaternion.identity);
                        Rigidbody projRB = proj.GetComponent<Rigidbody>();
                        projRB.AddForce(p.projDirection * p.projSpeed);
                        lastAttacked[i] = Time.time;
                    }
                }else if (p.shootType == ProjectileSO.ShootType.Multiple) {
                    
                }



            }
        }
        
    }
}
