using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "TurretData", menuName = "TurretParameter", order = 1)]
public class TurretData : ScriptableObject
{
    public int hp;
    public int atk;
    public int cost;
    public float range;
    public float atkInterval;
}


