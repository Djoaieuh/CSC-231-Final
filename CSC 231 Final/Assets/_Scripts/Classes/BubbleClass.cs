using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BubbleClass : MonoBehaviour
{
    public abstract int GetScore(List<GameObject> chainBubble, string p, string d);

    public bool CompareType(string t)
    {
        Debug.Log(t);

        Debug.Log(gameObject.tag);

        if (gameObject.CompareTag(t))
        {
            return true;
        }
        else
        {
            return false;
        }
    }


}
