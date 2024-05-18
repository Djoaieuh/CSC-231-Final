using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BaseBubble2 : BubbleClass
{
    public override int GetScore(List <GameObject> bubbleChain, int mult)
    {
        int score = 20;

        for (int i = 0; i <= bubbleChain.Count; i++)
        {
            if (bubbleChain[i] == gameObject)
            {
                score = score + (15 * i);
                break;
            }
        }

        Debug.Log("Base Bubble 2");

        return (score * mult);
    }

}