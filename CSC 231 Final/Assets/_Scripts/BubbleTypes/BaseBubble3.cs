using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class BaseBubble3 : BubbleClass
{
    public override int GetScore(List <GameObject> bubbleChain, int mult)
    {
        int score = 0;

        for (int i = 0; i > bubbleChain.Count; i++)
        {
            if (bubbleChain[i] == gameObject)
            {
                GameObject prevBubble = bubbleChain[i - 1];

                score = prevBubble.GetComponent<BubbleClass>().GetScore(bubbleChain, 1);

                break;
            }
        }


        Debug.Log("Base Bubble 3");

        return (score * mult);
    }

}