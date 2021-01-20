using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerScript : MonoBehaviour
{
    // Start is called before the first frame update

       
    public float health;
    public float maxHealth;

    public Slider hpBar;
    public SceneManagerScript sManager;

    void Awake()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

        //updates the health bar by changing the slider percentage based on current hp divided by max hp
        hpBar.value = health / maxHealth;

        //if player dies then game over
        if (health <= 0)
        {
            ResetRoom();
        }
    }

    public void ResetHP()
    {
        health = maxHealth;
    }
    public void TakeDamage(int damage)
    {
        health = health - damage;
    }

    public void ResetRoom()
    {
        SceneManager.LoadScene("end death");
        
    }
}
