using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneScript : MonoBehaviour
{
    public float speed;
    private Rigidbody2D myBody;

    private float minX, maxX, minY, maxY;

    [SerializeField]
    private GameObject projectile;

    private bool canShoot = true;

    public GameObject hit_effect;

    public float timer = 0f;

    public bool getItem = false;

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        Vector3 bound = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height), 0f);
        minX = -bound.x * 2.5f - 0.2f; maxX = bound.x * 2.5f + 0.2f;
        minY = -bound.y * 4.5f; maxY = bound.y * 4.5f;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Bound();
        StartCoroutine(Shoot());
        if(getItem == true)
        {
            timer += Time.deltaTime;
        }
    }

    private void Movement()
    {
        float xAxist = Input.GetAxisRaw("Horizontal") * speed;
        float yAxist = Input.GetAxisRaw("Vertical") * speed;
        myBody.velocity = new Vector2(xAxist, yAxist);
    }

    private void Bound()
    {
        Vector3 temp = transform.position;

        if (temp.x < minX)
        {
            temp.x = minX;
        }
        else if (temp.x > maxX)
        {
            temp.x = maxX;
        }

        if (temp.y < minY)
        {
            temp.y = minY;
        }
        else if (temp.y > maxY)
        {
            temp.y = maxY;
        }

        transform.position = temp;
    }

    private IEnumerator Shoot()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (canShoot)
            {
                canShoot = false;
                
                if (getItem == true)
                {
                    
                    if (timer < 5f)
                    {
                        Vector3 temp1 = transform.position;
                        Vector3 temp2 = transform.position;
                        temp1.x -= 0.05f;
                        temp1.y += 0.6f;

                        temp2.x += 0.05f;
                        temp2.y += 0.6f;


                        if (this.projectile != null)
                        {
                            Instantiate(this.projectile, temp1, Quaternion.identity);
                            Instantiate(this.projectile, temp2, Quaternion.identity);
                        }
                    }
                    else
                    {
                        getItem = false;
                        timer = 0f;
                    }
                }

                else
                {
                    Vector3 temp = transform.position;
                    temp.y += 0.6f;

                    if (this.projectile != null)
                    {
                        Instantiate(this.projectile, temp, Quaternion.identity);
                    }
                }

                yield return new WaitForSeconds(0.2f);
                canShoot = true;
            }
        }
    }

    private void OnDestroy()
    {
        Level1ControllerScript.Instance.showGameOverPanel();
        Instantiate(hit_effect, transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "ItemProjectile")
        {
            getItem = true;
        }
    }
}
