using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 20;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = -transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag.Equals("Player"))
        {
            Health_Player Player = coll.gameObject.GetComponent<Health_Player>();
            Player.DamagePlayer(10);
            Destroy(this.gameObject);
        }
        if (coll.gameObject.tag.Equals("Default"))
        {
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject, 5f);
        }
    }
}
