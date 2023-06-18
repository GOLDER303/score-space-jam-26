using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidSpawner : MonoBehaviour
{
    [SerializeField] private GameObject asteroidPrefab;
    [SerializeField] private GameObject magnetAsteroidPrefab;
    [SerializeField] private float asteroidSpawnDelay = 1f;
    [SerializeField] private float magnetAsteroidSpawnDelay = 1f;
    [SerializeField] private float spawnDistance = 15f;
    [SerializeField] private float asteroidForce = 15f;
    [SerializeField] private float trajectoryVariance = 15f;

    private void Start()
    {
        StartCoroutine(SpawnAsteroid(asteroidPrefab, asteroidSpawnDelay));
        StartCoroutine(SpawnAsteroid(magnetAsteroidPrefab, magnetAsteroidSpawnDelay));
    }

    private IEnumerator SpawnAsteroid(GameObject asteroidToSpawn, float delayBetweenSpawns)
    {
        while (true)
        {
            Vector2 spawnPointDirection = Random.insideUnitCircle.normalized;
            Vector2 spawnPointCoordinates = spawnPointDirection * spawnDistance + new Vector2(transform.position.x, transform.position.y);

            Quaternion rotation = Quaternion.AngleAxis(Random.Range(-trajectoryVariance, trajectoryVariance), Vector3.forward);

            GameObject asteroid = Instantiate(asteroidToSpawn, spawnPointCoordinates, rotation);
            asteroid.GetComponent<Asteroid>().Setup();

            Rigidbody2D asteroidRigidBody = asteroid.GetComponent<Rigidbody2D>();

            Vector2 trajectory = rotation * -spawnPointDirection;
            asteroidRigidBody.AddForce(trajectory * asteroidForce, ForceMode2D.Impulse);

            yield return new WaitForSeconds(delayBetweenSpawns);
        }
    }
}
