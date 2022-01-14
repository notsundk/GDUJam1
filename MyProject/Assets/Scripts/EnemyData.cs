using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "EnemyParameter", order = 1)]
public class EnemyData : ScriptableObject
{
    public float hp;
    public float atk;
    public float movespeed;
}