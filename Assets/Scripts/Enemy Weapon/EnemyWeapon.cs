﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyWeapon : MonoBehaviour
{
    public int damage;
    public float fireRate;

    public GameObject projectile;
    public Transform spawnPoint;

    public abstract void Attack();
}