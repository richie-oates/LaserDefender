using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime = 5f;
    [SerializeField] float firingDelay = 0.2f;

    [HideInInspector] public bool useAI;
    [HideInInspector] public float firingDelayVariance = 0.2f;
    [HideInInspector] public float minimumFiringDelay = 0.2f;

    [HideInInspector] public bool isFiring;
    
    Coroutine firingCoroutine;
    AudioPlayer audioPlayer;

    private void OnEnable()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }
    private void Start()
    {
        if (useAI) { isFiring = true; }
    }

    private void Update()
    {
        Fire();
    }

    private void Fire()
    {
        if (isFiring && firingCoroutine == null)
        {
            firingCoroutine = StartCoroutine(FireContinuously());
        }
        else if(!isFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }

    IEnumerator FireContinuously()
    {
        while (isFiring)
        {
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Destroy(projectile, projectileLifetime);

            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = transform.up * projectileSpeed;
            }

            PlaySFX();

            yield return new WaitForSeconds(useAI ? GetRandomDelay() : firingDelay);
        }
    }

    void PlaySFX()
    {
        if (audioPlayer != null)
        {
            audioPlayer.PlayShootingSFX();
        }
    }

    public float GetRandomDelay()
    {
        float delay = UnityEngine.Random.Range(firingDelay - firingDelayVariance,
                                        firingDelay + firingDelayVariance);
        return Mathf.Max(firingDelay, minimumFiringDelay);
    }
}
