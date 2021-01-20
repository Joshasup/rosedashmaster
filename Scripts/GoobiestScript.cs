using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoobiestScript : MonoBehaviour
{
    public GameObject wall;
    public GameObject player;
    public float speed;

    public float rateOfFire;
    float fireCooldown;

    public float rateOfChangingShield;
    float shieldCooldown;
    bool shieldUp = true;

    // Start is called before the first frame update
    void Start()
    {
        fireCooldown = Time.time;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
        if (fireCooldown < Time.time)
        {
            Fire();
            fireCooldown = Time.time + rateOfFire;

        }
    }

    // Update is called once per frame
    void Fire()
    {

    }

    void Movement()
    {

        Vector2 direction = new Vector2(player.transform.position.x - this.gameObject.transform.position.x, player.transform.position.y - this.gameObject.transform.position.y);

        this.gameObject.GetComponent<Rigidbody2D>().MovePosition(this.gameObject.GetComponent<Rigidbody2D>().position +
            direction.normalized * speed * Time.deltaTime);

        if (shieldCooldown < Time.time )
        {
            
            shieldCooldown = Time.time + 1f;
            shieldUp = !(shieldUp);
        }

        if (shieldUp)
            wall.transform.up = -direction;
    }
}
