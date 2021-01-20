using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalScript : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject laser, bullet, goob, goodbullet;
    public bool phaseD = false;
    public bool phaseG = false;
    public float fireRate;
    float fireTimer;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (phaseD)
        {

            if (fireTimer > Time.time)
            {
                Debug.Log("test");
            }
            Debug.Log(fireTimer);
            Debug.Log(Time.time);
            if (fireTimer < Time.time)
            {
                
                FireBarragePhaseD();
                fireTimer = Time.time + fireRate;

            }
        }

        if (phaseG)
        {


            if (fireTimer < Time.time)
            {

                FireBarragePhaseG();
                fireTimer = Time.time + fireRate;

            }

        }
    }

    public void FireCannons()
    {
        Quaternion rot = this.transform.rotation;
        GameObject laserObj = Instantiate(laser, new Vector3(0f,0f), rot, this.transform);
        laserObj.transform.localPosition = new Vector3(0f, -1f);
    }
    public void ActivatePhaseD()
    {
        phaseD = true;
        
    }
    public void FireBarragePhaseD()
    {
        int rand = Random.Range(1, 6);
        switch (rand)
        {
            case 1:
                Vector3 temp = transform.rotation.eulerAngles;

                Quaternion rot = Quaternion.Euler(temp);
                GameObject bullet1 = Instantiate(goodbullet, this.gameObject.transform.position, rot);
                bullet1.GetComponent<GoodBulletScript>().direction = new Vector3(1f, 1f);

                temp = transform.rotation.eulerAngles;
                temp.z = temp.z - 2.5f;
                rot = Quaternion.Euler(temp);
                GameObject bullet2 = Instantiate(bullet, this.gameObject.transform.position, rot);
                bullet2.GetComponent<BulletScript>().direction = new Vector3(1.5f, 1f);

                temp = transform.rotation.eulerAngles;
                temp.z = temp.z + 2.5f;
                rot = Quaternion.Euler(temp);
                GameObject bullet3 = Instantiate(bullet, this.gameObject.transform.position, rot);
                bullet3.GetComponent<BulletScript>().direction = new Vector3(0.5f, 1f);

                temp = transform.rotation.eulerAngles;
                temp.z = temp.z - 5f;
                rot = Quaternion.Euler(temp);
                GameObject bullet4 = Instantiate(bullet, this.gameObject.transform.position, rot);
                bullet4.GetComponent<BulletScript>().direction = new Vector3(1f, 1.5f);

                temp = transform.rotation.eulerAngles;
                temp.z = temp.z + 5f;
                rot = Quaternion.Euler(temp);
                GameObject bullet5 = Instantiate(bullet, this.gameObject.transform.position, rot);
                bullet5.GetComponent<BulletScript>().direction = new Vector3(1f, 0.5f);
                break;
            case 2:
                temp = transform.rotation.eulerAngles;

                rot = Quaternion.Euler(temp);
                bullet1 = Instantiate(bullet, this.gameObject.transform.position, rot);
                bullet1.GetComponent<BulletScript>().direction = new Vector3(1f, 1f);

                temp = transform.rotation.eulerAngles;
                temp.z = temp.z - 2.5f;
                rot = Quaternion.Euler(temp);
                bullet2 = Instantiate(goodbullet, this.gameObject.transform.position, rot);
                bullet2.GetComponent<GoodBulletScript>().direction = new Vector3(1.5f, 1f);

                temp = transform.rotation.eulerAngles;
                temp.z = temp.z + 2.5f;
                rot = Quaternion.Euler(temp);
                bullet3 = Instantiate(bullet, this.gameObject.transform.position, rot);
                bullet3.GetComponent<BulletScript>().direction = new Vector3(0.5f, 1f);

                temp = transform.rotation.eulerAngles;
                temp.z = temp.z - 5f;
                rot = Quaternion.Euler(temp);
                bullet4 = Instantiate(bullet, this.gameObject.transform.position, rot);
                bullet4.GetComponent<BulletScript>().direction = new Vector3(1f, 1.5f);

                temp = transform.rotation.eulerAngles;
                temp.z = temp.z + 5f;
                rot = Quaternion.Euler(temp);
                bullet5 = Instantiate(bullet, this.gameObject.transform.position, rot);
                bullet5.GetComponent<BulletScript>().direction = new Vector3(1f, 0.5f);
                break;
            case 3:
                temp = transform.rotation.eulerAngles;

                rot = Quaternion.Euler(temp);
                bullet1 = Instantiate(bullet, this.gameObject.transform.position, rot);
                bullet1.GetComponent<BulletScript>().direction = new Vector3(1f, 1f);

                temp = transform.rotation.eulerAngles;
                temp.z = temp.z - 2.5f;
                rot = Quaternion.Euler(temp);
                bullet2 = Instantiate(bullet, this.gameObject.transform.position, rot);
                bullet2.GetComponent<BulletScript>().direction = new Vector3(1.5f, 1f);

                temp = transform.rotation.eulerAngles;
                temp.z = temp.z + 2.5f;
                rot = Quaternion.Euler(temp);
                bullet3 = Instantiate(goodbullet, this.gameObject.transform.position, rot);
                bullet3.GetComponent<GoodBulletScript>().direction = new Vector3(0.5f, 1f);

                temp = transform.rotation.eulerAngles;
                temp.z = temp.z - 5f;
                rot = Quaternion.Euler(temp);
                bullet4 = Instantiate(bullet, this.gameObject.transform.position, rot);
                bullet4.GetComponent<BulletScript>().direction = new Vector3(1f, 1.5f);

                temp = transform.rotation.eulerAngles;
                temp.z = temp.z + 5f;
                rot = Quaternion.Euler(temp);
                bullet5 = Instantiate(bullet, this.gameObject.transform.position, rot);
                bullet5.GetComponent<BulletScript>().direction = new Vector3(1f, 0.5f);
                break;
            case 4:
                temp = transform.rotation.eulerAngles;

                rot = Quaternion.Euler(temp);
                bullet1 = Instantiate(bullet, this.gameObject.transform.position, rot);
                bullet1.GetComponent<BulletScript>().direction = new Vector3(1f, 1f);

                temp = transform.rotation.eulerAngles;
                temp.z = temp.z - 2.5f;
                rot = Quaternion.Euler(temp);
                bullet2 = Instantiate(bullet, this.gameObject.transform.position, rot);
                bullet2.GetComponent<BulletScript>().direction = new Vector3(1.5f, 1f);

                temp = transform.rotation.eulerAngles;
                temp.z = temp.z + 2.5f;
                rot = Quaternion.Euler(temp);
                bullet3 = Instantiate(bullet, this.gameObject.transform.position, rot);
                bullet3.GetComponent<BulletScript>().direction = new Vector3(0.5f, 1f);

                temp = transform.rotation.eulerAngles;
                temp.z = temp.z - 5f;
                rot = Quaternion.Euler(temp);
                bullet4 = Instantiate(goodbullet, this.gameObject.transform.position, rot);
                bullet4.GetComponent<GoodBulletScript>().direction = new Vector3(1f, 1.5f);

                temp = transform.rotation.eulerAngles;
                temp.z = temp.z + 5f;
                rot = Quaternion.Euler(temp);
                bullet5 = Instantiate(bullet, this.gameObject.transform.position, rot);
                bullet5.GetComponent<BulletScript>().direction = new Vector3(1f, 0.5f);
                break;
            case 5:
                temp = transform.rotation.eulerAngles;

                rot = Quaternion.Euler(temp);
                bullet1 = Instantiate(bullet, this.gameObject.transform.position, rot);
                bullet1.GetComponent<BulletScript>().direction = new Vector3(1f, 1f);

                temp = transform.rotation.eulerAngles;
                temp.z = temp.z - 2.5f;
                rot = Quaternion.Euler(temp);
                bullet2 = Instantiate(bullet, this.gameObject.transform.position, rot);
                bullet2.GetComponent<BulletScript>().direction = new Vector3(1.5f, 1f);

                temp = transform.rotation.eulerAngles;
                temp.z = temp.z + 2.5f;
                rot = Quaternion.Euler(temp);
               bullet3 = Instantiate(bullet, this.gameObject.transform.position, rot);
                bullet3.GetComponent<BulletScript>().direction = new Vector3(0.5f, 1f);

                temp = transform.rotation.eulerAngles;
                temp.z = temp.z - 5f;
                rot = Quaternion.Euler(temp);
                bullet4 = Instantiate(bullet, this.gameObject.transform.position, rot);
                bullet4.GetComponent<BulletScript>().direction = new Vector3(1f, 1.5f);

                temp = transform.rotation.eulerAngles;
                temp.z = temp.z + 5f;
                rot = Quaternion.Euler(temp);
                bullet5 = Instantiate(goodbullet, this.gameObject.transform.position, rot);
                bullet5.GetComponent<GoodBulletScript>().direction = new Vector3(1f, 0.5f);
                break;
        }
        

    }

    public void FireBarragePhaseG()
    {
        int rand = Random.Range(1, 6);
        switch (rand)
        {
            case 1:
                Vector3 temp = transform.rotation.eulerAngles;

                Quaternion rot = Quaternion.Euler(temp);
                GameObject bullet1 = Instantiate(goodbullet, this.gameObject.transform.position, rot);
                bullet1.GetComponent<GoodBulletScript>().direction = new Vector3(-1f, -1f);

                temp = transform.rotation.eulerAngles;
                temp.z = temp.z - 2.5f;
                rot = Quaternion.Euler(temp);
                GameObject bullet2 = Instantiate(bullet, this.gameObject.transform.position, rot);
                bullet2.GetComponent<BulletScript>().direction = new Vector3(-1.5f, -1f);

                temp = transform.rotation.eulerAngles;
                temp.z = temp.z + 2.5f;
                rot = Quaternion.Euler(temp);
                GameObject bullet3 = Instantiate(bullet, this.gameObject.transform.position, rot);
                bullet3.GetComponent<BulletScript>().direction = new Vector3(-0.5f, -1f);

                temp = transform.rotation.eulerAngles;
                temp.z = temp.z - 5f;
                rot = Quaternion.Euler(temp);
                GameObject bullet4 = Instantiate(bullet, this.gameObject.transform.position, rot);
                bullet4.GetComponent<BulletScript>().direction = new Vector3(-1f, -1.5f);

                temp = transform.rotation.eulerAngles;
                temp.z = temp.z + 5f;
                rot = Quaternion.Euler(temp);
                GameObject bullet5 = Instantiate(bullet, this.gameObject.transform.position, rot);
                bullet5.GetComponent<BulletScript>().direction = new Vector3(-1f, -0.5f);
                break;
            case 2:
                temp = transform.rotation.eulerAngles;

                rot = Quaternion.Euler(temp);
                bullet1 = Instantiate(bullet, this.gameObject.transform.position, rot);
                bullet1.GetComponent<BulletScript>().direction = new Vector3(-1f, -1f);

                temp = transform.rotation.eulerAngles;
                temp.z = temp.z - 2.5f;
                rot = Quaternion.Euler(temp);
                bullet2 = Instantiate(goodbullet, this.gameObject.transform.position, rot);
                bullet2.GetComponent<GoodBulletScript>().direction = new Vector3(-1.5f, -1f);

                temp = transform.rotation.eulerAngles;
                temp.z = temp.z + 2.5f;
                rot = Quaternion.Euler(temp);
                bullet3 = Instantiate(bullet, this.gameObject.transform.position, rot);
                bullet3.GetComponent<BulletScript>().direction = new Vector3(-0.5f, -1f);

                temp = transform.rotation.eulerAngles;
                temp.z = temp.z - 5f;
                rot = Quaternion.Euler(temp);
                bullet4 = Instantiate(bullet, this.gameObject.transform.position, rot);
                bullet4.GetComponent<BulletScript>().direction = new Vector3(-1f, -1.5f);

                temp = transform.rotation.eulerAngles;
                temp.z = temp.z + 5f;
                rot = Quaternion.Euler(temp);
                bullet5 = Instantiate(bullet, this.gameObject.transform.position, rot);
                bullet5.GetComponent<BulletScript>().direction = new Vector3(-1f, -0.5f);
                break;
            case 3:
                temp = transform.rotation.eulerAngles;

                rot = Quaternion.Euler(temp);
                bullet1 = Instantiate(bullet, this.gameObject.transform.position, rot);
                bullet1.GetComponent<BulletScript>().direction = new Vector3(-1f, -1f);

                temp = transform.rotation.eulerAngles;
                temp.z = temp.z - 2.5f;
                rot = Quaternion.Euler(temp);
                bullet2 = Instantiate(bullet, this.gameObject.transform.position, rot);
                bullet2.GetComponent<BulletScript>().direction = new Vector3(-1.5f, -1f);

                temp = transform.rotation.eulerAngles;
                temp.z = temp.z + 2.5f;
                rot = Quaternion.Euler(temp);
                bullet3 = Instantiate(goodbullet, this.gameObject.transform.position, rot);
                bullet3.GetComponent<GoodBulletScript>().direction = new Vector3(-0.5f, -1f);

                temp = transform.rotation.eulerAngles;
                temp.z = temp.z - 5f;
                rot = Quaternion.Euler(temp);
                bullet4 = Instantiate(bullet, this.gameObject.transform.position, rot);
                bullet4.GetComponent<BulletScript>().direction = new Vector3(-1f, -1.5f);

                temp = transform.rotation.eulerAngles;
                temp.z = temp.z + 5f;
                rot = Quaternion.Euler(temp);
                bullet5 = Instantiate(bullet, this.gameObject.transform.position, rot);
                bullet5.GetComponent<BulletScript>().direction = new Vector3(-1f, -0.5f);
                break;
            case 4:
                temp = transform.rotation.eulerAngles;

                rot = Quaternion.Euler(temp);
                bullet1 = Instantiate(bullet, this.gameObject.transform.position, rot);
                bullet1.GetComponent<BulletScript>().direction = new Vector3(-1f, -1f);

                temp = transform.rotation.eulerAngles;
                temp.z = temp.z - 2.5f;
                rot = Quaternion.Euler(temp);
                bullet2 = Instantiate(bullet, this.gameObject.transform.position, rot);
                bullet2.GetComponent<BulletScript>().direction = new Vector3(-1.5f, -1f);

                temp = transform.rotation.eulerAngles;
                temp.z = temp.z + 2.5f;
                rot = Quaternion.Euler(temp);
                bullet3 = Instantiate(bullet, this.gameObject.transform.position, rot);
                bullet3.GetComponent<BulletScript>().direction = new Vector3(-0.5f, -1f);

                temp = transform.rotation.eulerAngles;
                temp.z = temp.z - 5f;
                rot = Quaternion.Euler(temp);
                bullet4 = Instantiate(goodbullet, this.gameObject.transform.position, rot);
                bullet4.GetComponent<GoodBulletScript>().direction = new Vector3(-1f, -1.5f);

                temp = transform.rotation.eulerAngles;
                temp.z = temp.z + 5f;
                rot = Quaternion.Euler(temp);
                bullet5 = Instantiate(bullet, this.gameObject.transform.position, rot);
                bullet5.GetComponent<BulletScript>().direction = new Vector3(-1f, -0.5f);
                break;
            case 5:
                temp = transform.rotation.eulerAngles;

                rot = Quaternion.Euler(temp);
                bullet1 = Instantiate(bullet, this.gameObject.transform.position, rot);
                bullet1.GetComponent<BulletScript>().direction = new Vector3(-1f, -1f);

                temp = transform.rotation.eulerAngles;
                temp.z = temp.z - 2.5f;
                rot = Quaternion.Euler(temp);
                bullet2 = Instantiate(bullet, this.gameObject.transform.position, rot);
                bullet2.GetComponent<BulletScript>().direction = new Vector3(-1.5f, -1f);

                temp = transform.rotation.eulerAngles;
                temp.z = temp.z + 2.5f;
                rot = Quaternion.Euler(temp);
                bullet3 = Instantiate(bullet, this.gameObject.transform.position, rot);
                bullet3.GetComponent<BulletScript>().direction = new Vector3(-0.5f, -1f);

                temp = transform.rotation.eulerAngles;
                temp.z = temp.z - 5f;
                rot = Quaternion.Euler(temp);
                bullet4 = Instantiate(bullet, this.gameObject.transform.position, rot);
                bullet4.GetComponent<BulletScript>().direction = new Vector3(-1f, -1.5f);

                temp = transform.rotation.eulerAngles;
                temp.z = temp.z + 5f;
                rot = Quaternion.Euler(temp);
                bullet5 = Instantiate(goodbullet, this.gameObject.transform.position, rot);
                bullet5.GetComponent<GoodBulletScript>().direction = new Vector3(-1f, -0.5f);
                break;
        }


    }
}
