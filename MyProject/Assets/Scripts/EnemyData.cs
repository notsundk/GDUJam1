using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "EnemyParameter", order = 1)]
public class EnemyData : ScriptableObject
{
    public int hp;
    public int atk;
    public float movespeed;
}