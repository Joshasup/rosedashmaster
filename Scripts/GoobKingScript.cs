using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoobKingScript : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject goobKing, player, crystals, crystalOne, crystalTwo, chargingLaser, laser, bullet, goobs;
    public Rigidbody2D gkRbody;
    public GameObject redblocks;
    public BoxCollider2D goobKingBoxCollider;
    public float speed;
    int phase = 1;
    public char phase1 = 'a';
    int hp = 3;

    float crystalTimer;
    void Start()
    {
        goobKing.GetComponent<SpriteRenderer>().color = Color.red;
        crystalTimer = Time.time + 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (phase == 1)
        {
            FirstPhase();
        }

        if (phase == 2)
        {

            StartCoroutine(MoveGKing2(new Vector3(50.8f, 193.8f, 0f)));
            goobKingBoxCollider.enabled = true;
            goobKing.GetComponent<SpriteRenderer>().color = Color.yellow;
            redblocks.SetActive(true);

        }
    }

    void FirstPhase()
    {
        if (phase1 == 'a')
        {
            if (crystalTimer > Time.time)
            {
                Vector2 directionOne = new Vector2(player.transform.position.x - crystalOne.transform.position.x, player.transform.position.y - crystalOne.transform.position.y);
                Vector2 directionTwo = new Vector2(player.transform.position.x - crystalTwo.transform.position.x, player.transform.position.y - crystalTwo.transform.position.y);

                crystalOne.transform.up = -directionOne;
                crystalTwo.transform.up = -directionTwo;

            }

            if (crystalTimer < Time.time)
            {

                StartCoroutine(FireBothCrystals());
                phase1 = 'b';
            }
        }

        if (phase1 == 'b')
        {
            StartCoroutine(MoveGKing(new Vector3(50f, 182f, 0f)));
            
        }

        if (phase1 == 'c')
        {
            
            crystals.transform.position = new Vector3(49.5f, 181f);
            
            Vector3 temp = transform.rotation.eulerAngles;
            temp.z = 140f;
            crystals.transform.rotation = Quaternion.Euler(temp);
            Vector3 temp2 = transform.rotation.eulerAngles;
            temp2.z = -40f;
            crystalOne.transform.rotation = Quaternion.Euler(temp2);
            crystalTwo.transform.rotation = Quaternion.Euler(temp2);
            

            phase1 = 'd';
        }
        if (phase1 == 'd')
        {
            goobKingBoxCollider.enabled = true;
            goobKing.GetComponent<SpriteRenderer>().color = Color.yellow;
            crystalOne.GetComponent<CrystalScript>().ActivatePhaseD();
            crystalTwo.GetComponent<CrystalScript>().ActivatePhaseD();
            if (this.GetComponent<EnemyScript>().m_CurrentHealth <= 2)
            { 
                phase1 = 'e';
                goobKingBoxCollider.enabled = false;
                goobKing.GetComponent<SpriteRenderer>().color = Color.red;
            }
        }

        if (phase1 == 'e')
        {
            StartCoroutine(MoveGKing2(new Vector3(91f, 205f, 0f)));
            phase1 = 'f';

        }
        if (phase1 == 'f')
        {
            this.GetComponent<EnemyScript>().m_CurrentHealth = 2;
            crystals.transform.position = new Vector3(98f, 212.5f);
            Vector3 temp = transform.rotation.eulerAngles;
            temp.z = 140f;
            crystals.transform.rotation = Quaternion.Euler(temp);
            phase1 = 'g';
        }

        if (phase1 == 'g')
        {
            goobKingBoxCollider.enabled = true;
            goobKing.GetComponent<SpriteRenderer>().color = Color.yellow;
            crystalOne.GetComponent<CrystalScript>().phaseD = false;
            crystalTwo.GetComponent<CrystalScript>().phaseD = false;

            crystalOne.GetComponent<CrystalScript>().phaseG = true;
            crystalTwo.GetComponent<CrystalScript>().phaseG = true;
            if (this.GetComponent<EnemyScript>().m_CurrentHealth <= 1)
            {
                phase = 2;
                goobKingBoxCollider.enabled = false;
                goobKing.GetComponent<SpriteRenderer>().color = Color.red;
            }
        }
    }

    private IEnumerator FireBothCrystals()
    {
        yield return new WaitForSeconds(0.2f);
        crystalOne.GetComponent<CrystalScript>().FireCannons();
        crystalTwo.GetComponent<CrystalScript>().FireCannons();
        
    }

    private IEnumerator MoveGKing(Vector3 target)
    {
        float t = 0;
        Vector3 start = this.transform.position;
        
        while (t <= 1)
        {
            t += Time.fixedDeltaTime / speed;
            gkRbody.MovePosition(Vector3.Lerp(start, target, t));

            yield return null;
        }
        phase1 = 'c';


    }

    private IEnumerator MoveGKing2(Vector3 target)
    {
        float t = 0;
        Vector3 start = this.transform.position;

        while (t <= 1)
        {
            t += Time.fixedDeltaTime / (speed * 2f);
            gkRbody.MovePosition(Vector3.Lerp(start, target, t));

            yield return null;
        }
        


    }
}
