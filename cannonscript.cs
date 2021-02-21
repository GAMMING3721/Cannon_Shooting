using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonscript : MonoBehaviour
{
    public Transform attackpos,bulletspawnpoint;
    public LayerMask WhatisPlayer;
    public float attackrange;
    public float timepershoot = 3;
    float time, i;
    public GameObject Bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] whatisPlayer = Physics2D.OverlapCircleAll(attackpos.position, attackrange, WhatisPlayer);
        if (whatisPlayer.Length != 0)
        {
            if (i == 0)
            {
                time = Time.time;
                i++;
            }
            if (Time.time >= time)
            {
                Shoot();
                time += timepershoot;
            }
        }
        else
        {
            i = 0;
        }
    }
    void Shoot()
    {
        Instantiate(Bullet, bulletspawnpoint.position, bulletspawnpoint.rotation);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackpos.position, attackrange);
    }

}
