using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BubbleClass : MonoBehaviour
{
    public abstract int GetScore(List<GameObject> chainBubble, int mult);

    public bool CalculatePref(string pref)
    {
        if (gameObject.GetType().ToString() == pref)
        {
            Debug.Log("Same Class");

            return true;
        }
        else
        {
            Debug.Log("Diff Class");

            return false;
        }
    }

}
