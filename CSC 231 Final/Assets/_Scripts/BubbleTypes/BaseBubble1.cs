using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class BaseBubble1 : BubbleClass
{
    public override int GetScore(List<GameObject> bubbleChain, int mult)
    {
        int score = 25;

        if (bubbleChain[bubbleChain.Count - 1] == gameObject)
        {
            score = score * 4;
        }

        Debug.Log("Base Bubble 1");

        return (score * mult);
    }
}