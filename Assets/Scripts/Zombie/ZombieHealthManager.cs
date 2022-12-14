using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealthManager : BasicHealthManager
{
    public override void Death()
    {
        GetComponent<ZombieController>().state = ZombieState.death;
        Destroy(gameObject, 5f);
    }
}
