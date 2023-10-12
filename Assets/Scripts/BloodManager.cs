using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BloodManager : MonoBehaviour
{
    public Image[] hearts;

    [SerializeField]
    public Image heart1, heart2, heart3;


    private static BloodManager instance;
    public static BloodManager Instance
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
        
    }

    public void minusHeart(GameObject obj)
    {
        this.currentHeart  -= 1;
        for(int i = 0; i< currentHeart; i++)
        {
            hearts[i].gameObject.SetActive(true);
        }
        if(this.currentHeart <= 0)
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
    }
}
