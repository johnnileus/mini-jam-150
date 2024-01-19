using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "ScriptableObjects/ProjectileModule")]
public class ProjectileSO : ScriptableObject
{
    public GameObject projectile;

    public float projSpeed;
    public Vector3 projDirection;
    
    public float attackDelay;
    

    

    public enum ShootType{
        Single,
        Multiple,
        SingleRandom
    }

    public ShootType shootType;
}
