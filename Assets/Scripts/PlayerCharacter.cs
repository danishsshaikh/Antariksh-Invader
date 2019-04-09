using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public float movementSpeed;
    public MapLimits Limits;
    public GameObject bullet;
    public Transform pos1;
    public Transform posL;
    public Transform posR;
    public float shotpower;
    public AudioClip shotSound;
    AudioSource audioS;
    int power;
    
    void Start()
    {
        power = 1;
        audioS = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        Movement();
        Shooting();
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, Limits.minimumX, Limits.maximumX), Mathf.Clamp(transform.position.y, Limits.minimumY, Limits.maximumY), 0.0f);
    }
    
    void Movement()
    {
        if(Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.right * -movementSpeed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * movementSpeed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.up * -movementSpeed * Time.deltaTime);
        }

    }
     
    void Shooting()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            audioS.PlayOneShot(shotSound);
            switch(power)
            {
                case 1:
                    {
                        GameObject newBullet = Instantiate(bullet, pos1.position, transform.rotation);
                        newBullet.GetComponent<Rigidbody>().velocity = Vector3.up * shotpower;
                    }break;
                case 2:
                    {
                        GameObject bullet1 = Instantiate(bullet, posL.position, transform.rotation);
                        bullet1.GetComponent<Rigidbody>().velocity = Vector3.up * shotpower;
                        GameObject bullet2 = Instantiate(bullet, posR.position, transform.rotation);
                        bullet2.GetComponent<Rigidbody>().velocity = Vector3.up * shotpower;
                    }break;
                case 3:
                    {
                        GameObject bullet1 = Instantiate(bullet, posL.position, transform.rotation);
                        bullet1.GetComponent<Rigidbody>().velocity = Vector3.up * shotpower;
                        GameObject bullet2 = Instantiate(bullet, posR.position, transform.rotation);
                        bullet2.GetComponent<Rigidbody>().velocity = Vector3.up * shotpower;
                        GameObject bullet3 = Instantiate(bullet, pos1.position, transform.rotation);
                        bullet3.GetComponent<Rigidbody>().velocity = Vector3.up * shotpower;
                    }
                    break;
                default:
                    {
                        GameObject newBullet = Instantiate(bullet, pos1.position, transform.rotation);
                        newBullet.GetComponent<Rigidbody>().velocity = Vector3.up * shotpower;
                    }
                    break;
         
            }
            
        }

    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "powerUp")
        {
            if (power < 3)
                power++;
            Destroy(col.gameObject);
        }
        if(col.gameObject.tag == "powerDown")
        {
            if(power > 1)
                power--;
            Destroy(col.gameObject);
        }
    }
}
