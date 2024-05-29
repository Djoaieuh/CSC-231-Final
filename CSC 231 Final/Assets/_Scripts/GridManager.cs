using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GridManager : MonoBehaviour
{
    [SerializeField] GameObject bubblePrefab;

    [SerializeField] List<GameObject> commonBubbleTypes;

    void Start()
    {

    }
    void Update()
    {

    }

    public void RefillBubble(GameObject parent)
    {
        Vector2 position = new Vector2(1, 1);

        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject currentPos = transform.GetChild(i).gameObject;

            if (parent == currentPos && currentPos.transform.childCount == 0)
            {
                GameObject bubbleType = GenerateBubbleType();

                GameObject newBubble = Instantiate(bubbleType, currentPos.transform.position, Quaternion.identity, currentPos.transform);


                newBubble.GetComponent<BubbleScript>().SetPosition(position);
            }

            position.x += 1;
            if (position.x > 4)
            {
                position.x = 1;
                position.y += 1;
            }
        }
    }

    public void ResetGrid()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).gameObject.transform.childCount == 0)
            {
                RefillBubble(transform.GetChild(i).gameObject);
            }
            else
            {
                transform.GetChild(i).gameObject.transform.GetChild(0).GetComponent<BubbleScript>().Disappear();
            }

        }
    }


    private GameObject GenerateBubbleType()
    {
        GameObject newBubbleType = commonBubbleTypes[Random.Range(0, commonBubbleTypes.Count)];

        return newBubbleType;
    }

}
