using System;
using System.Collections.Generic;
using UnityEditorInternal;
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

    public void RefillGrid()
    {
        Debug.Log("Grid Refill");

        Vector2 position = new Vector2(1, 1);

        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject currentPos = transform.GetChild(i).gameObject;

            if (currentPos.transform.childCount == 0)
            {

                Debug.Log("No Child Found");

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


    private GameObject GenerateBubbleType()
    {
        GameObject newBubbleType = commonBubbleTypes[Random.Range(0, commonBubbleTypes.Count)];

        return newBubbleType;
    }

}
