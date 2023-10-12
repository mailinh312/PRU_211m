using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SpannerScript : MonoBehaviour
{
    [SerializeField] 
    private GameObject enemy;

    private BoxCollider2D box;

    private int count;

    // Start is called before the first frame update
    void Start()
    {
        box = GetComponent<BoxCollider2D>();
        StartCoroutine(GenernateEnermy());
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator GenernateEnermy()
    {
        yield return new WaitForSeconds(Random.Range(1f, 3f));

        float minX = -box.bounds.size.x / 2f;
        float maxX = box.bounds.size.x / 2f;
        if (count <= 30)
        {
            Vector3 temp = transform.position;
            temp.x = Random.Range(minX, maxX);
            Instantiate(enemy, temp, Quaternion.identity);
            StartCoroutine(GenernateEnermy());
        }
        else
        {
            Level1ControllerScript.Instance.showNextLevelPanel();
        }
        count += 1;
    }
}
