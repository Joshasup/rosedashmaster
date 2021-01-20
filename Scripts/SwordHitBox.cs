using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHitBox : MonoBehaviour
{
    // Start is called before the first frame update

    public SwordScript sword;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            col.GetComponent<EnemyScript>().Damage(sword.damage);
            col.GetComponent<EnemyScript>().KnockBack(3, -(Vector2)sword.dir);
        }

    }
}
