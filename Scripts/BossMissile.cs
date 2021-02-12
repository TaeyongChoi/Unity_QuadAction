using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossMissile : Bullet
{
    public Transform target;
    NavMeshAgent nav;
    public Boss boss;

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }
    
    void Update()
    {
        nav.SetDestination(target.position);
        StartCoroutine(EndMissile());
    }

    IEnumerator EndMissile()
    {
        if(boss.isDead == true)
            Destroy(gameObject);
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
        
}
