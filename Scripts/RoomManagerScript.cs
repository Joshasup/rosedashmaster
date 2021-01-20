using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int enemyAmount;
    public GameObject exitDoor;
    public TimeKeeperScript timekeeper;
    bool oneTimeCheck = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (enemyAmount <= 0)
        {
            exitDoor.GetComponent<SpriteRenderer>().color = Color.blue;
            exitDoor.GetComponent<BoxCollider2D>().isTrigger = true;
            if (this.gameObject.name == "Room5" && oneTimeCheck == true)
            {

                timekeeper.TrackEndTime();
                timekeeper.CalcTime();
                timekeeper.CompareHighScore();
                Debug.Log(timekeeper.finalTime);
                Debug.Log(timekeeper.highScore);
                oneTimeCheck = false;
                timekeeper.WipeOut();
                
            }
        }
    }

    public void decreaseEnemyAmount(int amount)
    {

        enemyAmount -= amount;
    }
}
