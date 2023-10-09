using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    public float speed;
    private Rigidbody2D myBody;

    private float minX, maxX, minY, maxY;

    [SerializeField]
    private GameObject projectile;

    private bool canShoot = true;


    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();

        Vector3 bound = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height), 0f);
        minX = -bound.x * 2.5f - 0.5f; maxX = bound.x * 2.5f + 0.5f;
        minY = -bound.y * 4.5f; maxY = bound.y * 4.5f;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Bound();
        StartCoroutine(Shoot());
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
                Vector3 temp = transform.position;
                temp.y += 0.6f;
                Instantiate(projectile, temp, Quaternion.identity);
                yield return new WaitForSeconds(0.2f);
                canShoot = true;
            }
        }
    }

    private void OnDestroy()
    {
        Level1ControllerScript.Instance.showGameOverPanel();
    }
}
