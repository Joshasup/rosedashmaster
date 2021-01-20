using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashHitBoxScript : MonoBehaviour
{
    // Start is called before the first frame update

    public string dashName;
    public float hitBoxLength;
    public float hitBoxWidth;
    public float dashTimer;

    public BoxCollider2D hitbox;
    public Rigidbody2D rbody;
    public GameObject player;

    bool active = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        //var heading = player.transform.position - rbody.gameObject.transform.position;
        //Debug.Log(heading);
        //var distance = heading.magnitude;
        //var direction = heading / distance;
        //Debug.Log(direction);
        //Debug.Log((this.gameObject.transform.position + (direction * 10) ));
        //rbody.MovePosition(this.gameObject.transform.position + (direction * 10) * Time.deltaTime);
        if (dashTimer < Time.time && active == true)
        {
            active = false;
            hitbox.enabled = false;
        }
    }


    public void changeValues(string name, float length, float width, float timer)
    {
        dashName = name;
        hitBoxLength = length;
        hitBoxWidth = width;
        dashTimer = timer;

    }

    public void ActivateDash()

    {
        hitbox.enabled = true;
        active = true;
        dashTimer = Time.time + dashTimer;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            switch (dashName)
            {
                case "RegularDash":
                    col.gameObject.GetComponent<EnemyScript>().Damage(1);
                    break;
            }
        }

        if (col.gameObject.tag == "Orbs")
        {

            col.gameObject.GetComponent<DashOrbScript>().PickedUp();

        }
    }
}
