using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlScript : MonoBehaviour
{
    SpriteRenderer Body;
    SpriteRenderer Hair;
    SpriteRenderer Clothes;
    SpriteRenderer BackHair;
    SpriteRenderer Eyes;
    SpriteRenderer Accessory;

    List<Sprite> expressions;

    void Start()
    {
        Body = gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>();
        Eyes = gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>();
        Hair = gameObject.transform.GetChild(2).GetComponent<SpriteRenderer>();
        Clothes = gameObject.transform.GetChild(3).GetComponent<SpriteRenderer>();
        BackHair = gameObject.transform.GetChild(4).GetComponent<SpriteRenderer>();
        Accessory = gameObject.transform.GetChild(5).GetComponent<SpriteRenderer>();
    }


    void Update()
    {

    }

    public void SetBody(List<Sprite> bodies)
    {
        Body.sprite = bodies[0];
    }

    public void SetHair(Sprite hair)
    {
        Hair.sprite = hair;
    }

    public void SetClothes(Sprite clothes)
    {
        Clothes.sprite = clothes;
    }

    public void SetBackHair(Sprite backhair)
    {
        BackHair.sprite = backhair;
    }

    public void SetEyes(List<Sprite> eyes)
    {
        expressions = eyes;

        Eyes.sprite = expressions[0];
    }

    public void SetAccessory(Sprite accessory)
    {
        Accessory.sprite = accessory;
    }

    public void SetExpression(int expIndex)
    {
        Debug.Log("Function Called");

        Eyes.sprite = expressions[expIndex];
    }
}
