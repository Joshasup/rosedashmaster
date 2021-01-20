using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedZoneScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int damage;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.GetComponent<PlayerScript>().TakeDamage(damage);
        }
    }
}
