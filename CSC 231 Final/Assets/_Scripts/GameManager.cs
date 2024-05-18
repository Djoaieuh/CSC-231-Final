using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    int maxConnections;
    private void Awake()
    {
        instance = this;
    }

    public List<GameObject> bubbleChain;

    void Start()
    {
        maxConnections = 4;
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

}
