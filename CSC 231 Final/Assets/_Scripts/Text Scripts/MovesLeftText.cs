using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TMivesLeftText : MonoBehaviour
{
    TMP_Text moves;

    void Start()
    {
        moves = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        moves.text = GameManager.instance.GetMoves().ToString();
    }
}
