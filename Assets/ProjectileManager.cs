using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ProjectileManager : MonoBehaviour{


    [SerializeField] private ProjectileSO[] projectiles;
    
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float[] lastAttacked;
    private float initTime;
    
    private int[] curShootIndex; // tracks the next spawn point in Single
    private int[] lastShot; // index of last projectile shot in delay list
    // Start is called before the first frame update
    void Start(){
        for (int i = 0; i < projectiles.Length; i++) {
            projectiles[i].projDirection = projectiles[i].projDirection.normalized;
        }
        curShootIndex = new int[projectiles.Length];
        lastShot = new int[projectiles.Length];
        lastAttacked = new float[projectiles.Length];
        initTime = Time.time;
    }

    private void SpawnProjectile(ProjectileSO p, Vector3 pos){
        GameObject proj = Instantiate(p.projectile, pos, Quaternion.identity);
        proj.GetComponent<Rigidbody>().AddForce(p.projDirection * p.projSpeed);
        proj.GetComponent<ProjectileScript>().setTimeToLive(p.projLifetime);
    }
    
    
    // Update is called once per frame
    void Update(){
        
        //grid based projectiles
        for (int i = 0; i < projectiles.Length; i++) {
            ProjectileSO p = projectiles[i];


            bool ready = false;

            
            switch (p.delayType) {
                case ProjectileSO.DelayType.Uniform: {
                    if (lastAttacked[i] + p.uniformInterval < Time.time) {
                        ready = true;
                    }

                    break;
                }case ProjectileSO.DelayType.List: {
                    if (lastShot[i] < p.delayList.Length && p.delayList[lastShot[i]] + initTime < Time.time) {
                        ready = true;
                        lastShot[i]++;
                    }
                    break;
                }
            }
            
            if (ready) {
                switch (p.shootType) {
                    case ProjectileSO.ShootType.SingleConsecutive: {
                        SpawnProjectile(p, spawnPoints[p.spawnIndexes[curShootIndex[i]]].position);
                        lastAttacked[i] = Time.time;
                        curShootIndex[i] = (curShootIndex[i] + 1) % p.spawnIndexes.Length;
                        break;
                    }case ProjectileSO.ShootType.All: {
                        for (int j = 0; j < p.spawnIndexes.Length; j++) {
                            SpawnProjectile(p, spawnPoints[p.spawnIndexes[j]].position);
                            lastAttacked[i] = Time.time;
                        }
                        break;
                    }case ProjectileSO.ShootType.RandomSingle: {
                        Vector3 spawnPos = spawnPoints[p.spawnIndexes[Random.Range(0, p.spawnIndexes.Length)]].position;
                        SpawnProjectile(p, spawnPos);
                        lastAttacked[i] = Time.time;
                        break;
                    }case ProjectileSO.ShootType.RandomMultiple: {
                        List<int> nums = new List<int>();
                        
                        for (int j = 0; j < p.spawnIndexes.Length; j++) {
                            nums.Add(j);
                        }
                        
                        for (int j = 0; j < p.randomMultipleAmt; j++) {
                            int rand = Random.Range(0, nums.Count);
                            int num = nums[rand];
                            nums.RemoveAt(rand);
                            
                            Vector3 spawnPos = spawnPoints[p.spawnIndexes[num]].position;
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
