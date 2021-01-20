using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    public int damage;
    public GameObject hitBox;

    private bool attacking = false;

    private float attackTimer = 0;
    public float attackCd = 0.2f;

    public Rigidbody2D playerRBody;

    public Vector3 dir;

    // Start is called before the first frame update
    void Awake()
    {
        hitBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!attacking)
        {
            var pos = Camera.main.WorldToScreenPoint(this.gameObject.transform.position);
            dir = Input.mousePosition - pos;
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            this.gameObject.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        if (Input.GetMouseButtonDown(0) && !attacking)
        {
            var pos = Camera.main.WorldToScreenPoint(this.gameObject.transform.position);
            dir = Input.mousePosition - pos;
            attacking = true;
            attackTimer = attackCd;
            hitBox.SetActive(true);
            

        }

        if (attacking)
        {
            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;

            }
            else
            {
                attacking = false;
                hitBox.SetActive(false);
            }
        }


    }
}
