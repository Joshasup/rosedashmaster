using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserScript : MonoBehaviour
{
    public int damage;
    public float bulletTimeOfDeath;
    // Start is called before the first frame update
    void Start()
    {
        bulletTimeOfDeath = bulletTimeOfDeath + Time.time;
    }

    public void FixedUpdate()
    {
        if (bulletTimeOfDeath < Time.time)
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {

            collision.gameObject.GetComponent<PlayerScript>().TakeDamage(damage);
        }
    }
}
