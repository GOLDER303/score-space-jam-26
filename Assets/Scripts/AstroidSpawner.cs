using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidSpawner : MonoBehaviour
{
    [SerializeField] private GameObject asteroidPrefab;
    [SerializeField] private float secondsBetweenSpawns = 1f;
    [SerializeField] private float spawnDistance = 15f;
    [SerializeField] private float asteroidForce = 15f;
    [SerializeField] private float trajectoryVariance = 15f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnAsteroid), secondsBetweenSpawns, secondsBetweenSpawns);
    }

    private void SpawnAsteroid()
    {
        Vector2 spawnPointDirection = Random.insideUnitCircle.normalized;
        Vector2 spawnPointCoordinates = spawnPointDirection * spawnDistance + new Vector2(transform.position.x, transform.position.y);

        Quaternion rotation = Quaternion.AngleAxis(Random.Range(-trajectoryVariance, trajectoryVariance), Vector3.forward);

        GameObject asteroid = Instantiate(asteroidPrefab, spawnPointCoordinates, rotation);
        asteroid.GetComponent<Asteroid>().Setup();

        Rigidbody2D asteroidRigidBody = asteroid.GetComponent<Rigidbody2D>();

        Vector2 trajectory = rotation * -spawnPointDirection;
        asteroidRigidBody.AddForce(trajectory * asteroidForce, ForceMode2D.Impulse);
    }
}
