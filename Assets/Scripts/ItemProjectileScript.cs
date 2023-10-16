using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemProjectileScript : MonoBehaviour
{

    public float speed;
    private Rigidbody2D myBody;

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

    }

    private void Movement()
    {
        myBody.velocity = new Vector2(0f, -speed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Plane")
        {
           Destroy(gameObject);
        }
    }
}
