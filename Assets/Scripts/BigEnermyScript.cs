using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

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

    public int maxHealth = 1000;
    public int currentHealth;

    public EnermyHealthBar healthBar;

    private Vector3 desPosition;

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
        desPosition = transform.position;
        desPosition.y = transform.position.y - 3;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        StartCoroutine(Shoot());
    }

    private void Movement()
    {
        transform.position = Vector3.Lerp(transform.position, desPosition, speed * Time.deltaTime);
    }


    private IEnumerator Shoot()
    {

        if (canShoot)
        {
            AudioManager.Instance.PlayShootingSFX();
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
            AudioManager.Instance.PlayHitByEnermySFX();
            HeartManager.Instance.minusHeart(collision.gameObject);
            Instantiate(hit_effect, transform.position, Quaternion.identity);
        }
        if (collision.tag == "Projectile")
        {
            currentHealth -= 1;
            healthBar.setHealth(currentHealth, gameObject);
        }
    }

    private void OnDestroy()
    {
        AudioManager.Instance.PlayDieSFX();
        AudioManager.Instance.PlayWinningSFX();
        ScoreManager.Instance.addScore(score);
        Instantiate(hit_effect, transform.position, Quaternion.identity);
        Level1ControllerScript.Instance.showNextLevelPanel();
    }
}
