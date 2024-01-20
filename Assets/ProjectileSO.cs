using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "ScriptableObjects/ProjectileModule")]
public class ProjectileSO : ScriptableObject
{
    
    public enum ShootType{ Single, Multiple, Random, RandomMultiple }
    
    public GameObject projectile;

    public float projSpeed;
    public Vector3 projDirection;
    
    [Space(16)]
    public float attackDelay;
    public float timeToLive;
    
    [Space(16)]
    public ShootType shootType;
    public int[] spawnIndexes;
}
