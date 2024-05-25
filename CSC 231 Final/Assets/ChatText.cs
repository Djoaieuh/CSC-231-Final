using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChatText : MonoBehaviour
{
    TMP_Text chat;
    int ConvoNumber;
    void Start()
    {
        chat = GetComponent<TMP_Text>();    
    }

    public string ConversationLine(int number)
    {
        switch(number)
        {
           case 0:
           return "hi";
           case 1:
           return "hello";
        }
        return chat.text;
    }

    public void Talk()
    {
        chat.text = ConversationLine(Random.Range(0, 2));
    }
}
