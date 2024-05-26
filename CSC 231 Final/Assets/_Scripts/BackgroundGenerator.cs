using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundGenerator : MonoBehaviour
{
    [SerializeField]
    List<Sprite> Background;

    SpriteRenderer SpriteRenderer;
    void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        GenerateBackground();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GenerateBackground()
    {
        
        SpriteRenderer.sprite = Background[Random.Range(0,Background.Count)];
    }
}
