using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetAsteroid : Asteroid
{
    protected override void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            Destroy(gameObject);
        }
    }
}
