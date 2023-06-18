using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetAsteroid : Asteroid
{
    [SerializeField] private GameObject magnetPebble;
    [SerializeField] private int magnetPebbleAmount = 5;

    protected override void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            Destroy(gameObject);

            for (int i = 0; i < magnetPebbleAmount; i++)
            {
                SpawnMagnetPebble();
            }
        }
    }

    private void SpawnMagnetPebble()
    {
        Vector3 spawnPosition = Random.insideUnitCircle;
        spawnPosition += transform.position;
        Instantiate(magnetPebble, spawnPosition, Quaternion.identity);
    }
}
