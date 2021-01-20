using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementScript : MonoBehaviour
{
    public float enemySpeed;
    public GameObject Player;

    public Rigidbody2D enemyRBody;

    int maxDist = 15; // Maximum distance you want the enemy to be. 
    int minDist = 3; // Minimum distance you want the enemy to be.
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        enemyMovement();
    }

    void enemyMovement() {
       // Follows the PLAYER.




        // Keeps the position of the player as a 2D Vector.
        Vector2 playerPosition = (Vector2) Player.transform.position;
                                                                        // Distance returns the absolute distance of two Vector2's.
        if (Vector2.Distance(this.transform.position, playerPosition) >= minDist && Vector2.Distance(this.transform.position, playerPosition) <= maxDist)
        {    
            // Move towards only returns a NEW Vector2. 
            // Creates a Vector2 that moves from the enemy's posiiton, to the player's position, by enemySpeed per time lasped.
            Vector2 copy = Vector2.MoveTowards(enemyRBody.position, playerPosition, enemySpeed * Time.deltaTime);

            // Moves the enemy to the new position.
            enemyRBody.MovePosition(copy);
        }

        // If distance / in view / no collision
        // Shoot here

 
        if (Vector2.Distance(this.transform.position, playerPosition) <= minDist) {
            // Strafe here 
        }


        

}
    }
