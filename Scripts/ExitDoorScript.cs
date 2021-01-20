using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDoorScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 newLocation;
    public GameObject nextRoom;
    

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            if (this.gameObject.name == "FinalExitDoor")
            {
                SceneManager.LoadScene("CONGRATS");
            }
            else
            {
                other.gameObject.transform.position = newLocation;
                nextRoom.SetActive(true);
            }
        }
    }
}
