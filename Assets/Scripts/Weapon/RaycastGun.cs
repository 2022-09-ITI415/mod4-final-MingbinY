using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastGun : MonoBehaviour
{
    public int damage = 10;
    public float range = 100f;
    public float fireInterval = 0.1f;
    float nextShootTime;
    bool canFire;
    bool reloading;
    int fireCount;
    public int shotPerMag = 30;

    public ParticleSystem[] muzzleFlashes;
    public AudioClip fireSFX;
    public AudioClip reloadSFX;
    public LayerMask layer;

    RaycastHit hitInfo;
    Camera cam;
    AudioSource audioSource;

    public ParticleSystem fleshHitEffect;
    public ParticleSystem otherHitEffect;
    public GameObject tracerEffect;
    public GameObject muzzle;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        nextShootTime = Time.time;
        cam = Camera.main;
        canFire = true;
        reloading = false;
    }

    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Shoot();
        }
        if (Input.GetKey(KeyCode.R) && !reloading)
        {
            Reload();
        }
    }

    void Shoot()
    {
        if (fireCount >= shotPerMag && !reloading)
            Reload();
        if (!canFire)
            return;
        if (Time.time < nextShootTime)
            return;

        audioSource.PlayOneShot(fireSFX);
        nextShootTime = Time.time + fireInterval;
        fireCount++;
        foreach (ParticleSystem muzzleFlash in muzzleFlashes)
            muzzleFlash.Emit(1);
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hitInfo, range, layer))
        {
            GameObject newTracer = Instantiate(tracerEffect, muzzle.transform.position, Quaternion.identity);
            newTracer.GetComponent<TrailRenderer>().AddPosition(newTracer.transform.position);
            newTracer.transform.position = hitInfo.point;
            ZombieHealthManager healthManager = hitInfo.collider.GetComponent<ZombieHealthManager>();
            if (healthManager != null)
            {
                healthManager.TakeDamage(damage);
                if (healthManager.bodyType == BodyType.Flesh)
                {
                    fleshHitEffect.transform.position = hitInfo.point;
                    fleshHitEffect.transform.forward = hitInfo.normal;
                    fleshHitEffect.Emit(1);
                }
                else
                {
                    otherHitEffect.transform.position = hitInfo.point;
                    otherHitEffect.transform.forward = hitInfo.normal;
                    otherHitEffect.Emit(1);
                }
            }
            else
            {
                otherHitEffect.transform.position = hitInfo.point;
                otherHitEffect.transform.forward = hitInfo.normal;
                otherHitEffect.Emit(1);
            }
        }
        else
        {
            GameObject newTracer = Instantiate(tracerEffect, muzzle.transform.position, Quaternion.identity);
            newTracer.GetComponent<TrailRenderer>().AddPosition(newTracer.transform.position);
            var end = cam.transform.position + cam.transform.forward * range;
            newTracer.transform.position = end;
        }
    }

    void Reload()
    {
        reloading = true;
        canFire = false;
        audioSource.PlayOneShot(reloadSFX);
        Invoke("EndReload", reloadSFX.length);
    }

    void EndReload()
    {
        reloading = false;
        fireCount = 0;
        canFire = true;
    }
}
