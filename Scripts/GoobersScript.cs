using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoobersScript : MonoBehaviour
{
    public GameObject bullet;
    
    public GameObject player;
    public float speed;

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
        Movement();
        if (fireCooldown < Time.time)
        {
            Fire();
            fireCooldown = Time.time+ rateOfFire;

        }
    }

    void Fire()
    {

        GameObject bulletInstant = Instantiate(bullet, this.transform.position, Quaternion.identity);
        bulletInstant.GetComponent<BulletScript>().SetVelocity(this.transform.position, player.transform.position);
        bulletInstant = Instantiate(bullet, this.transform.position, Quaternion.identity);
        bulletInstant.GetComponent<BulletScript>().SetVelocity(this.transform.position, new Vector3 (player.transform.position.x + Random.Range(-1.0f, 1.0f), player.transform.position.y + Random.Range(-1.0f, 1.0f)));
        bulletInstant = Instantiate(bullet, this.transform.position, Quaternion.identity);
        bulletInstant.GetComponent<BulletScript>().SetVelocity(this.transform.position, new Vector3(player.transform.position.x - Random.Range(-1.0f, 1.0f), player.transform.position.y - Random.Range(-1.0f, 1.0f)));
    }

    void Movement()
    {
        
        Vector2 direction = new Vector2(player.transform.position.x - this.gameObject.transform.position.x, player.transform.position.y - this.gameObject.transform.position.y);
        
        this.gameObject.GetComponent<Rigidbody2D>().MovePosition(this.gameObject.GetComponent<Rigidbody2D>().position +
            direction.normalized * speed * Time.deltaTime);

    }
}
