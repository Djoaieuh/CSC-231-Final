using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] GameObject bubblePrefab;

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
                GameObject newBubble = Instantiate(bubblePrefab, currentPos.transform.position, Quaternion.identity, currentPos.transform);

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


}
