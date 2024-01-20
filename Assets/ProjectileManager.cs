using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    private void SpawnProjectile(ProjectileSO p, Vector3 pos){
        GameObject proj = Instantiate(p.projectile, pos, Quaternion.identity);
        proj.GetComponent<Rigidbody>().AddForce(p.projDirection * p.projSpeed);
        proj.GetComponent<ProjectileScript>().setTimeToLive(p.timeToLive);
    }
    
    // Update is called once per frame
    void Update(){
        for (int i = 0; i < projectiles.Length; i++) {
            ProjectileSO p = projectiles[i];
            if (lastAttacked[i] + p.attackDelay < Time.time) {

                switch (p.shootType) {
                    case ProjectileSO.ShootType.Single: {
                        SpawnProjectile(p, spawnPoints[p.spawnIndexes[curShootIndex[i]]].position);
                        lastAttacked[i] = Time.time;
                        curShootIndex[0] = (curShootIndex[0] + 1) % p.spawnIndexes.Length;
                        break;
                    }case ProjectileSO.ShootType.Multiple: {
                        for (int j = 0; j < p.spawnIndexes.Length; j++) {
                            SpawnProjectile(p, spawnPoints[p.spawnIndexes[j]].position);
                            lastAttacked[i] = Time.time;
                        }
                        break;
                    }case ProjectileSO.ShootType.Random: {
                        Vector3 spawnPos = spawnPoints[p.spawnIndexes[Random.Range(0, p.spawnIndexes.Length)]].position;
                        SpawnProjectile(p, spawnPos);
                        lastAttacked[i] = Time.time;
                        break;
                    }case ProjectileSO.ShootType.RandomMultiple: {
                        List<int> nums = new List<int>();
                        
                        for (int j = 0; j < p.spawnIndexes.Length; j++) {
                            nums.Add(j);
                        }
                        
                        for (int j = 0; j < 2; j++) {
                            int rand = Random.Range(0, nums.Count);
                            nums.Remove(rand);
                            Vector3 spawnPos = spawnPoints[p.spawnIndexes[rand]].position;
                            SpawnProjectile(p, spawnPos);
                        }
                        lastAttacked[i] = Time.time;
                        
                        break;
                    }
                    
                }
                
            }
        }
        
    }
}
