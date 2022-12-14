using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    public int damage;

    private void Start()
    {
        damage = GetComponentInParent<ZombieController>().damage;    
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerHealthManager phm = other.GetComponent<PlayerHealthManager>();
        if (phm != null)
        {
            phm.TakeDamage(damage);
        }
    }
}
