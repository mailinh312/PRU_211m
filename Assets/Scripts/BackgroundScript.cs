using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{
    public float scrollSpeed;
    private Material mat;
    private Vector2 offset = Vector2.zero; //(0, 0)

    // Start is called before the first frame update
    void Start()
    {
        float worldHeight = Camera.main.orthographicSize * 2;
        float worldWidth = worldHeight * Screen.width/Screen.height;
        transform.localScale = new Vector3(worldWidth, worldHeight, 0f);

        offset = mat.GetTextureOffset("_MainTex");
    }

    // Update is called once per frame
    void Update()
    {
        offset.y += scrollSpeed * Time.deltaTime;
        mat.SetTextureOffset("_MainTex", offset);
    }

    private void Awake()
    {
        mat = GetComponent<Renderer>().material;
    }
}
