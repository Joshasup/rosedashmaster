using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashOrbScript : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject dashS;
    public GameObject player;
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player")
        {
            //player.GetComponent<PlayerMovement>().dash = dashS.GetComponent<DashScript>();
            Destroy(this.gameObject);
        }
    }

    public void PickedUp()
    {
        //player.GetComponent<PlayerMovement>().dash = dash.GetComponent<DashScript>();
        Destroy(this.gameObject);
    }
}
