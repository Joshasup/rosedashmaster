using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public string enemyName;
    [SerializeField]
    public float m_MaxHealth = 100;
    public float m_CurrentHealth;
    public Rigidbody2D enemyRbody;
    public int enemyWorth;
    public RoomManagerScript room;
    public int dashChargesPrize; //amount of how much dash charges player get

    

    public bool knockbackBool = false;
    public int knockbackDuration = 0;

    public GameObject player;
    private Vector2 velocity;
    private void Awake()
    {
        m_CurrentHealth = m_MaxHealth;
        if  (enemyName == "goodBullet")
        {
            player = GameObject.FindGameObjectWithTag("Player");
            room = GameObject.FindGameObjectWithTag("Room4").GetComponent<RoomManagerScript>();
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (Deadenemy())
        {
            Destroy(this.gameObject);
        }

        if (knockbackBool == true)
        {
            enemyRbody.MovePosition(enemyRbody.position + ((velocity * 5) * Time.fixedDeltaTime));
            knockbackDuration++;

            if (knockbackDuration > 30)
            {
                knockbackDuration = 0;
                knockbackBool = false;
            }
            
            
        }
    }

    public void Damage(float damage)
    {
        m_CurrentHealth -= damage;
        
    }
    public void GotHit()
    {
        
        player.GetComponent<PlayerMovement>().IncreaseDashCharges(dashChargesPrize);
        
        m_CurrentHealth -= 1;
        if (m_CurrentHealth <= 0) 
        {
            room.decreaseEnemyAmount(enemyWorth);
            Destroy(this.gameObject);    
        }


    }
    public void KnockBack (float distance, Vector2 playerLoc)
    {
        var heading = (Vector2)this.gameObject.transform.position - playerLoc;
        velocity = heading.normalized * 3;
        knockbackBool = true;
    }
    public bool Deadenemy() { return m_CurrentHealth <= 0; }
}
