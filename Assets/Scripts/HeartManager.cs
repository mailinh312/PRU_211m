using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
  
    public Image[] hearts;

    [SerializeField]
    public Image heart1, heart2, heart3;


    private static HeartManager instance;
    public static HeartManager Instance
    {
        get => instance;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    [SerializeField]
    protected float currentHeart;

    void Start()
    {
        this.currentHeart = 3;
        addHeart();
    }

    void Update()
    {
        hearts[(int)currentHeart].gameObject.SetActive(false);
    }

    public void minusHeart(GameObject obj)
    {
        this.currentHeart -= 1;

        if (this.currentHeart <= 0)
        {
            Destroy(obj);
        }
    }

    private void addHeart()
    {
        hearts = new Image[3];
        hearts[0] = heart1;
        hearts[1] = heart2;
        hearts[2] = heart3;

        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].gameObject.SetActive(true);
        }
    }
}
