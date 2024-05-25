using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Serenade : BubbleClass
{
    public override int GetScore(List<GameObject> bubbleChain, string preference, string dislike)
    {
        if (CompareType(dislike))
        {
            return -50;
        }

        int score = 35;

        if (bubbleChain[bubbleChain.Count - 1] == gameObject)
        {
            Debug.Log("Found itself");

            score = score * 4;
        }

        if (CompareType(preference))
        {
            GameManager.instance.SetCurrentChainMult(2);
        }

        Debug.Log(score);

        return score;
    }
}