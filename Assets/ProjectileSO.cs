using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "ScriptableObjects/ProjectileModule")]
public class ProjectileSO : ScriptableObject
{
    
    public enum ShootType{ SingleConsecutive, All, RandomSingle, RandomMultiple }
    public enum DelayType{ Uniform, List }
    
    public GameObject projectile;

    public float projSpeed;
    public Vector3 projDirection;
    public float projLifetime;
    
    [Space(16)]
    public DelayType delayType;
    public float uniformInterval;
    //public float uniformDelay;

    public float[] delayList;
    
    
    [Space(16)]
    public ShootType shootType;
    public int randomMultipleAmt;
    public int[] spawnIndexes;
}
