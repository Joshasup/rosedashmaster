using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goob_EnemyAttack : MonoBehaviour
{

    public GameObject bullet;
    public GameObject player;

    public float rateOfFire;
    float fireCooldown;

    // Start is called before the first frame update
    void Start()
    {
        fireCooldown = Time.time;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (fireCooldown < Time.time)
        {
            Fire();
            fireCooldown = Time.time + rateOfFire;

        }
    }

    void Fire()
    {

        GameObject bulletInstant = Instantiate(bullet, this.transform.position, Quaternion.identity);
        bulletInstant.GetComponent<BulletScript>().SetVelocity(this.transform.position, player.transform.position);
    }
}
