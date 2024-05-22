using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flirt : BubbleClass
{
    public override int GetScore(List<GameObject> bubbleChain, string preference, string dislike)
    {
        if (CompareType(dislike))
        {
            return -50;
        }

        int score = 25;

        int randEffect = Random.Range(0, 4);

        switch (randEffect)
        {
            case 0:
                GameManager.instance.AddTime(10);
                break;
            case 1:
                score = score + 50;
                break;
            case 2:
                GameManager.instance.SetNextChainMult(2);
                break;
            case 3:
                GameManager.instance.SetNextChainMult(2);
                break;
            case 4:
                GameManager.instance.SetMult(4);
                break;
        }


        if (CompareType(preference))
        {
            GameManager.instance.SetCurrentChainMult(2);
        }
        
        

        return score;
    }
}