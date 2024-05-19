using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBubble : BubbleClass
{
    public override int GetScore(List<GameObject> bubbleChain, int mult)
    {
        int score = 50;


        Debug.Log("Base Bubble");

        return (score * mult);
    }
}