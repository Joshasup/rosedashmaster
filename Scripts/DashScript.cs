using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashScript : MonoBehaviour
{
    // Start is called before the first frame update

    public string dashName;
    public float dashDistance;
    public float dashTimer;
    public float dashLength;
    public float dashWidth;

    public LayerMask enemyLayer;
    public LayerMask orbLayer;
    RaycastHit2D[] enemiesHit, orbsHit;


    void Start()
    {
        
    }

    public void useDash(Rigidbody2D playerRBody, Vector2 movement, GameObject player, GameObject DashHitBox)
    {
        Vector2 origin = playerRBody.gameObject.transform.position;
        switch (dashName)
        {
            case "RegularDash":

                DashHitBox.GetComponent<DashHitBoxScript>().changeValues(dashName, dashLength, dashWidth, dashTimer);
                DashHitBox.GetComponent<DashHitBoxScript>().ActivateDash();
                
                
                

               
                break;

            case "IceDash":
                //freeze
                DashHitBox.GetComponent<DashHitBoxScript>().ActivateDash();
               
                DashHitBox.GetComponent<DashHitBoxScript>().changeValues(dashName, dashLength, dashWidth, dashTimer);
                playerRBody.MovePosition(playerRBody.position + ((Vector2)movement.normalized * dashDistance));
                

                // Reset Dash to Regular
                
                //
                

                break;

            case "FireDash":
                Debug.Log("Shoot Fire");
                playerRBody.MovePosition(playerRBody.position + ((Vector2)movement.normalized * dashDistance));
                break;

            default:
                break;
        }
    }


    void DamageEnemyInDash(Vector2 origin, Vector2 movement)
    {
        enemiesHit = Physics2D.CircleCastAll(origin, 3f, movement.normalized * dashDistance, enemyLayer);

        if (enemiesHit != null)
        {
            //deal one damage to enemy
        }

    }

    void PickUpOrbsInDash(Vector2 origin, Vector2 movement)
    {
        orbsHit = Physics2D.CircleCastAll(origin, 3f, movement.normalized * dashDistance, orbLayer);
        if (orbsHit != null)
        {
            foreach (RaycastHit2D orb in orbsHit)
            {
                if (orb.collider.gameObject.GetComponent<DashOrbScript>() != null)
                {
                    orb.collider.gameObject.GetComponent<DashOrbScript>().PickedUp();
                }

                //Picks up the orb
                //if hit multiple orb, replace the latest orb
            }
        }

    }
    void FixedUpdate()
    {

    }

    
    
    // Update is called once per frame


        // IRRELEVANT CODE BELOW 
    public IEnumerator Dash(Rigidbody2D playerRBody, Vector2 movement)
    {
        Vector2 target = (Vector2)(movement.normalized * dashDistance);
        while (!Mathf.Approximately(((Vector2)playerRBody.gameObject.transform.position - target).sqrMagnitude, 0))
        {
            playerRBody.gameObject.transform.position = Vector2.MoveTowards(playerRBody.gameObject.transform.position, target, dashDistance * Time.deltaTime);
            Debug.Log(playerRBody.gameObject.transform.position);
            yield return null;
        }
    }
}
