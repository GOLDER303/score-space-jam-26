using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Asteroid"))
        {
            gameManager.GameOver();
            gameObject.SetActive(false);
            //TODO: spawn particles
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("MagnetPebble"))
        {
            gameManager.AddScore(1);
            Destroy(other.gameObject);
        }
    }
}
