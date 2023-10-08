using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyScript : MonoBehaviour
{
    public float speed;
    private Rigidbody2D myBody;

    [SerializeField]
    private GameObject projectile;

    private bool canShoot = true;

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        StartCoroutine(Shoot());
    }

    private void Movement()
    { 
        myBody.velocity = new Vector2(0, -speed);
    }


    private IEnumerator Shoot()
    {
       
            if (canShoot)
            {
                canShoot = false;
                Vector3 temp = transform.position;
                temp.y -= 0.6f;
                Instantiate(projectile, temp, Quaternion.identity);
                yield return new WaitForSeconds(5f);
                canShoot = true;
            }
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Plane")
        {
            Destroy(collision.gameObject);
            Level1ControllerScript.instance.showGameOverPanel();
        }
    }
}
