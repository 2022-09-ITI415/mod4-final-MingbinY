using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastGun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireInterval = 0.1f;
    float nextShootTime;

    public ParticleSystem[] muzzleFlashes;

    RaycastHit hitInfo;
    Camera cam;

    public ParticleSystem fleshHitEffect;
    public ParticleSystem otherHitEffect;
    public GameObject tracerEffect;
    public GameObject muzzle;

    private void Start()
    {
        nextShootTime = Time.time;
        cam = Camera.main;
    }

    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (Time.time < nextShootTime)
            return;

        nextShootTime = Time.time + fireInterval;
        foreach (ParticleSystem muzzleFlash in muzzleFlashes)
            muzzleFlash.Emit(1);
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hitInfo, range))
        {
            GameObject newTracer = Instantiate(tracerEffect, muzzle.transform.position, Quaternion.identity);
            newTracer.GetComponent<TrailRenderer>().AddPosition(newTracer.transform.position);
            newTracer.transform.position = hitInfo.point;
            BasicHealthManager healthManager = hitInfo.collider.GetComponent<BasicHealthManager>();
            if (healthManager != null)
            {
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
}
