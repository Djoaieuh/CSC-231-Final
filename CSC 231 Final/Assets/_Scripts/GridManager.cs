using System;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using Random = UnityEngine.Random;

public class GridManager : MonoBehaviour
{
    [SerializeField] GameObject bubblePrefab;

    [SerializeField] List<GameObject> commonBubbleTypes;
    public enum Rarity
    {
        common,
        rare,
        epic
    }

    Rarity rarity;


    void Start()
    {
        RefillGrid();
    }
    void Update()
    {

    }

    private void RefillGrid()
    {
        Vector2 position = new Vector2(1, 1);

        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject currentPos = transform.GetChild(i).gameObject;

            if (currentPos.transform.childCount == 0)
            {
                GameObject bubbleType = GenerateBubbleType();

                GameObject newBubble = Instantiate(bubbleType, currentPos.transform.position, Quaternion.identity, currentPos.transform);


                newBubble.GetComponent<BubbleScript>().SetPosition(position);

                position.x += 1;
                if (position.x > 4)
                {
                    position.x = 1;
                    position.y += 1;
                }
            }
        }
    }


    private GameObject GenerateBubbleType()
    {
        int rarityId = Random.Range(0, 101);

        if (rarityId <= 120)
        {
            rarity = Rarity.common;
        }
        else if (rarityId <= 90)
        {
            rarity = Rarity.rare;
        }
        else
        {
            rarity = Rarity.epic;
        }

        if (rarity == Rarity.common)
        {
            GameObject newBubbleType = commonBubbleTypes[Random.Range(0, commonBubbleTypes.Count)];

            return newBubbleType;

        }

        return null;

    }

}
