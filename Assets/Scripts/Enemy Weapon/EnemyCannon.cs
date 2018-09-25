using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCannon : Weapon
{
    public override void Attack()
    {
        GameObject clone = Instantiate(projectile, spawnPoint.position, spawnPoint.rotation);
        PlayerProjectile newBullet = clone.GetComponent<PlayerProjectile>();
        newBullet.Fire(transform.forward);
    }
}
