using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enermy2Script : MonoBehaviour
{
    public float speed;
    private Rigidbody2D myBody;

    [SerializeField]
    private GameObject projectile;

    private bool canShoot = true;

    [SerializeField]
    private float score = 2;

    public GameObject hit_effect;

    public int numOfAttack;

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        numOfAttack = 0;
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
            if (this.projectile != null)
            {
                Instantiate(this.projectile, temp, Quaternion.identity);
            }
            yield return new WaitForSeconds(5f);
            canShoot = true;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Plane")
        {
            AudioManager.Instance.PlayHitByEnermySFX();
            HeartManager.Instance.minusHeart(collision.gameObject);
            Instantiate(hit_effect, transform.position, Quaternion.identity);
        }
        if (collision.tag == "Projectile")
        {
            numOfAttack += 1;
            if (numOfAttack >= 2)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnDestroy()
    {
        AudioManager.Instance.PlayDieSFX();
        ScoreManager.Instance.addScore(score);
        Instantiate(hit_effect, transform.position, Quaternion.identity);
    }
}
