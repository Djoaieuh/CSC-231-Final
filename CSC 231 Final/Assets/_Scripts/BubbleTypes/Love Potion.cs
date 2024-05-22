using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LovePotion : BubbleClass
{
    public override int GetScore(List<GameObject> bubbleChain, string preference, string dislike)
    {
        if (CompareType(dislike))
        {
            return -50;
        }

        int score = 20;

        score = score + 250 * (100 - (GameManager.instance.GetTimer() / 30) * 100);

        if (CompareType(preference))
        {
            GameManager.instance.SetCurrentChainMult(2);
        }
        
        

        return score;
    }
}