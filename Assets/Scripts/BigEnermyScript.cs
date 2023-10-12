using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BigEnermyScript : MonoBehaviour
{
    public float speed;
    private Rigidbody2D myBody;

    [SerializeField]
    private GameObject projectile;

    private bool canShoot = true;

    [SerializeField]
    private float score = 10;

    public GameObject hit_effect;

    public int maxHealth = 100;
    public int currentHealth;

    public EnermyHealthBar healthBar;

    private Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        StartCoroutine(Shoot());
    }

    private void Movement()
    {

        if (Vector3.Distance(startPosition, this.transform.position) == 2)
        {
            myBody.velocity = new Vector2(0, 0);
        }
        else
        {
            myBody.velocity = new Vector2(0, -speed);
        }
    }


    private IEnumerator Shoot()
    {

        if (canShoot)
        {
            canShoot = false;
            Vector3 temp1 = transform.position;
            temp1.x -= 0.2f;
            temp1.y -= 0.6f;

            Vector3 temp2 = transform.position;
            temp2.y -= 0.6f;

            Vector3 temp3 = transform.position;
            temp3.x += 0.2f;
            temp3.y -= 0.6f;

            if (this.projectile != null)
            {
                Instantiate(this.projectile, temp1, Quaternion.identity);
                Instantiate(this.projectile, temp2, Quaternion.identity);
                Instantiate(this.projectile, temp3, Quaternion.identity);
            }
            yield return new WaitForSeconds(5f);
            canShoot = true;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Plane")
        {
            HeartManager.Instance.minusHeart(collision.gameObject);
            Instantiate(hit_effect, transform.position, Quaternion.identity);
        }
        if (collision.tag == "Projectile")
        {
            currentHealth -= 5;
            healthBar.setHealth(currentHealth, gameObject);
        }
    }

    private void OnDestroy()
    {
        ScoreManager.Instance.addScore(score);
        Instantiate(hit_effect, transform.position, Quaternion.identity);
        Level1ControllerScript.Instance.showNextLevelPanel();
    }
}
