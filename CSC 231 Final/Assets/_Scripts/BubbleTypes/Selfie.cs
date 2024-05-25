using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Selfie : BubbleClass
{
    public override int GetScore(List <GameObject> bubbleChain, string preference, string dislike)
    {
        if (CompareType(dislike))
        {
            return -50;
        }

        int score = 0;

        for (int i = 0; i <= bubbleChain.Count; i++)
        {
            if (bubbleChain[i] == gameObject)
            {
                Debug.Log("Found itself");

                GameObject prevBubble = bubbleChain[i - 1];

                score = prevBubble.GetComponent<BubbleClass>().GetScore(bubbleChain, preference, dislike);

                break;
            }
        }

        if (CompareType(preference))
        {
            GameManager.instance.SetCurrentChainMult(2);
        }

        Debug.Log(score);

        return score;
    }

}