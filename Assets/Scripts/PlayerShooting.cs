using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float projectileForce = 20f;

    private void OnFire()
    {
        Shoot();
    }

    private void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D projectileRigidBody = projectile.GetComponent<Rigidbody2D>();
        projectileRigidBody.AddForce(firePoint.up * projectileForce, ForceMode2D.Impulse);
    }
}
