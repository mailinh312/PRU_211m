using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BloodManager : MonoBehaviour
{
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
    protected float currentBlood;

    [SerializeField]
    protected TextMeshProUGUI bloodTxt;

    void Start()
    {
        this.currentBlood = 3;
    }

    void Update()
    {
        bloodTxt.text = currentBlood + "";
    }

    public void minusBlood(GameObject obj)
    {
        this.currentBlood  -= 1;
        if(this.currentBlood <= 0)
        {
            Destroy(obj);
        }
    }
}
