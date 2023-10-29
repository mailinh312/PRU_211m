using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpannerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy, bigEnermy, item;

    private BoxCollider2D box;

    private int count;

    // Start is called before the first frame update
    void Start()
    {
        box = GetComponent<BoxCollider2D>();
        StartCoroutine(GenernateEnermy());
        StartCoroutine(GenernateItem());
        count = 0;
    }
    private void Update()
    {
        if(count == 15)
        {
            bigEnermy.SetActive(true);
        }
    }

    private IEnumerator GenernateEnermy()
    {

        yield return new WaitForSeconds(Random.Range(1f, 3f));

        float minX = -box.bounds.size.x / 2f;
        float maxX = box.bounds.size.x / 2f;

        Vector3 temp = transform.position;
        temp.x = Random.Range(minX, maxX);
        Instantiate(enemy, temp, Quaternion.identity);
        StartCoroutine(GenernateEnermy());

        count += 1;
    }

    private IEnumerator GenernateItem()
    {

        yield return new WaitForSeconds(Random.Range(10f, 15f));

        float minX = -box.bounds.size.x / 2f;
        float maxX = box.bounds.size.x / 2f;

        Vector3 temp = transform.position;
        temp.x = Random.Range(minX, maxX);
        Instantiate(item, temp, Quaternion.identity);
        StartCoroutine(GenernateItem());
    }
}
