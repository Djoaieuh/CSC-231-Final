using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : BubbleClass
{
    public override int GetScore(List<GameObject> bubbleChain, string preference, string dislike)
    {
        if (CompareType(dislike))
        {
            return -50;
        }

        int score = 30;

        foreach (GameObject bubble in bubbleChain)
        {
            if (CompareType(bubble.tag))
            {
                score = score + 30;
            }
        }

        if (CompareType(preference))
        {
            GameManager.instance.SetCurrentChainMult(2);
        }
        
        return score;
    }
}