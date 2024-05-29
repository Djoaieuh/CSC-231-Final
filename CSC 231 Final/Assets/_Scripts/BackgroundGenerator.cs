using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundGenerator : MonoBehaviour
{
    [SerializeField]
    List<Sprite> Background;

    SpriteRenderer SpriteRenderer;

    private void Awake()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }


    void Start()
    {
        
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
