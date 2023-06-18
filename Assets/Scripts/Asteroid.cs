using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private float downscaleRange = .8f;
    [SerializeField] private float upscaleRange = 2f;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void Setup()
    {
        transform.eulerAngles = new Vector3(0f, 0f, Random.value * 360);

        float size = Random.Range(downscaleRange, upscaleRange);

        transform.localScale = new Vector3(size, size, 0);
        rb.mass = size;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
