using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public Rigidbody2D bulletRbody;
    public string bulletName;
    public float bulletVelocity; // The speed and direction of which the bullet is moving.
    public float bulletTimeOfDeath; // Might need to change type
    public Vector3 direction;
    public int damage;



    // Start is called before the first frame update
    void Start()
    {
        bulletTimeOfDeath = bulletTimeOfDeath + Time.time;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (direction != null)
        {
            bulletRbody.MovePosition(bulletRbody.position + (Vector2)direction.normalized * bulletVelocity * Time.deltaTime);
        }

        if (bulletTimeOfDeath < Time.time)
        {
            Destroy(this.gameObject);
        }
    }

    public void SetVelocity(Vector3 enemyPos, Vector3 playerPos)
    {

        direction = new Vector3(playerPos.x - enemyPos.x, playerPos.y - enemyPos.y);

    }
    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.name == "Player") {
            col.gameObject.GetComponent<PlayerScript>().TakeDamage(damage);
            Destroy(this.gameObject);
        }
        else
        {
          
        }

    }

    
}
