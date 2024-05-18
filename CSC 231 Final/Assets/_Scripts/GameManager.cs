using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    int maxConnections;
    int currentMult;
    int chainMult;

    int score;
    private void Awake()
    {
        instance = this;
    }

    public List<GameObject> bubbleChain;

    void Start()
    {
        maxConnections = 4;
        currentMult = 1;
        chainMult = 1;

        score = 0;
    }
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            ExitChain();
        }

        if (Input.GetMouseButtonDown(1))
        {
            ClearChain();
        }

    }

    public void AddToChain(GameObject currentBubble)
    {
        if (!bubbleChain.Contains(currentBubble) && bubbleChain.Count < maxConnections)
        {
            bubbleChain.Add(currentBubble);
            currentBubble.GetComponent<BubbleScript>().Select();

        }
    }

    public void ExitChain()
    {
        if (bubbleChain.Count > 2)
        {
            CalculateScore();
        }

        ClearChain();
    }


    void CalculateScore()
    {
        for (int i = 0; i < bubbleChain.Count; i++)
        {
            score = score + bubbleChain[i].GetComponent<BubbleClass>().GetScore(bubbleChain, currentMult * chainMult);

            Debug.Log(score);
        }

        for (int i = 0; i < bubbleChain.Count; i++)
        {
            Destroy(bubbleChain[i]);
        }

        ClearChain();
    }

    public bool IsChainEmpty()
    {
        if (bubbleChain.Count == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ClearChain()
    {
        for (int i = 0; i < bubbleChain.Count; i++)
        {
            GameObject currentbubble = bubbleChain[i];

            currentbubble.GetComponent<BubbleScript>().Deselect();
        }

        bubbleChain.Clear();
    }

    public List<GameObject> GetChain()
    {
        return bubbleChain;
    }

    public void SetMult(int mult)
    {
        currentMult = mult;
    }

    public void SetChainMult(int mult)
    {
        chainMult = chainMult * mult;
    }

}
