using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyProjectileScript : MonoBehaviour
{
    public float speed;
    private Rigidbody2D myBody;

    public GameObject shoot_effect;
    public GameObject hit_effect;

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();

        GameObject obj = (GameObject)Instantiate(shoot_effect, transform.position - new Vector3(0, 0, 5), Quaternion.identity); //Spawn muzzle flash

        Destroy(gameObject, 5f); //Bullet will despawn after 5 seconds
    }

    // Update is called once per frame
    void Update()
    {
        myBody.velocity = new Vector2(0f, -speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Plane")
        {
            BloodManager.Instance.minusBlood(collision.gameObject);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag != "Enermy" && collision.gameObject.tag != "Projectile" && collision.gameObject.tag != "Spawner")
        {
            Instantiate(hit_effect, transform.position, Quaternion.identity);
            Destroy(gameObject, 10f);
        }

    }
}
