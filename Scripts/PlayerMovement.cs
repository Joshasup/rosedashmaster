using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public int dashCharges;
    public int maxDashCharges;
    public float dashCooldown;
    float dashTimer;
    public Slider dashBar;
    public Text dashCounter;
    bool dashOnCooldown;
    public float speed;
    public Rigidbody2D playerRBody;
    public Camera cam;
    public string dash;

    public float dashDistance;

    public GameObject dashEndPoint, dashAnchor, dashRing;

    Vector3 mousePos;
    Vector3 movement;

    Vector2 initialMouseOnScreen, mouseOnScreen;
    bool dashOnce = false;

    public LineRenderer line;
    public LayerMask enemyLayer, wallLayer;
    // Start is called before the first frame update
    void Start()
    {
        
        line.startWidth = 0.5f;
        

    }

    // Update is called once per frame



    void FixedUpdate()
    {
        if (dashOnce == false)
        {
            Movement();
        }

        if (dashCharges > maxDashCharges)
        {
            dashCharges = maxDashCharges;
            dashTimer = Time.time;
        }

        if (dashCharges == maxDashCharges && (dashTimer - Time.time) / dashCooldown < 1)
        {
            dashTimer = Time.time;
        }

        if (dashCharges < maxDashCharges && dashOnCooldown == false)
        {
            dashTimer = Time.time + dashCooldown;
            dashOnCooldown = true;
        }

        if (dashTimer < Time.time && dashOnCooldown == true)
        {
            dashTimer += dashCooldown;
            dashCharges += 1;
        }

        if (dashCharges == maxDashCharges)
        {
            dashOnCooldown = false;
            dashTimer = Time.time;
        }
        
        dashBar.value = (dashTimer - Time.time) / dashCooldown;
        dashCounter.text = dashCharges.ToString() ;
    
    }
    void Update()
    {

        if (Input.GetAxisRaw("Shift") > 0 && dashOnce == false && dashCharges > 0)
        {
            Debug.Log("test");
            PreDashSlowDown();
            dashOnce = true;
        }
        if (dashOnce == true)
        {
            DashEndPointMoving();
        }
        if (Input.GetAxisRaw("Shift") == 0 && dashOnce == true)
        {

            Dashing();
            dashOnce = false;
        }

    }

    void Movement()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        playerRBody.MovePosition(playerRBody.position + (movement.normalized * speed) * Time.deltaTime / Time.timeScale);
    }

    void PreDashSlowDown()
    {
        Time.timeScale = 0.1f;
        Debug.Log("Slow down");
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        movement = mousePos - transform.position;
        
        Vector2 direction = new Vector2(mousePos.x - dashAnchor.transform.position.x, mousePos.y - dashAnchor.transform.position.y);
        dashAnchor.transform.up = direction;
        dashRing.SetActive(true);
    }

    void DashEndPointMoving() 
    {
        
        
        if (Vector3.Distance(this.transform.position, dashEndPoint.transform.position) < 6f)
        {
            
            dashEndPoint.transform.Translate(new Vector3(0f, 0.1f, 0f));
        }
        mouseOnScreen = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = new Vector2(mouseOnScreen.x - dashAnchor.transform.position.x, mouseOnScreen.y - dashAnchor.transform.position.y);
        dashAnchor.transform.up = direction;
        line.positionCount = 2;
        line.SetPosition(0, this.transform.position);
        line.SetPosition(1, dashEndPoint.transform.position);

    }


    void Dashing()
    {
        dashCharges -= 1;
        dashRing.SetActive(false);
        line.positionCount = 0;
        RaycastHit2D[] dashRay = Physics2D.CircleCastAll(this.transform.position, 1f, 
            new Vector2(dashEndPoint.transform.position.x- this.transform.position.x, 
            dashEndPoint.transform.position.y - this.transform.position.y), 
            Vector3.Distance(dashEndPoint.transform.position, this.transform.position), enemyLayer);
        foreach (RaycastHit2D col in dashRay)
        {

            if (col.collider.gameObject.tag.Equals("Wall"))
            {

                break;
            }

            if (col.collider.gameObject.GetComponent<EnemyScript>() != null)
            {
                col.collider.gameObject.GetComponent<EnemyScript>().GotHit();
            }

        }
        
        //this.transform.position = dashEndPoint.transform.position;
        Vector2 direction = new Vector2(dashEndPoint.transform.position.x - this.transform.position.x, dashEndPoint.transform.position.y - dashAnchor.transform.position.y);
        Vector3 diff = dashEndPoint.transform.position - this.transform.position;
        RaycastHit2D h = Physics2D.Raycast(this.transform.position, diff, diff.magnitude, wallLayer);
        if (h == true)
        {
            this.transform.position = new Vector3
                (h.point.x, 
                h.point.y);
        }
        else
        {
            this.transform.position = dashEndPoint.transform.position;
        }
        dashEndPoint.transform.position = this.transform.position;
        dashAnchor.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
        Time.timeScale = 1f;
        //float moveHorizontal = this.gameObject.transform.position.x;
        //float moveVertical = this.gameObject.transform.position.y;

        //Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        //mousePos.z = 0;

        //Vector2 movement = mousePos - transform.position;


        //RaycastHit2D dashRay = Physics2D.Raycast(transform.position, movement.normalized, 10f);

        //dash.useDash(playerRBody, movement);

    }

    public void IncreaseDashCharges( int amount)
    {

        dashCharges += amount;
    }
    public void SpecialDash()
    { 
        
    
    }
}