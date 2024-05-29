using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MultiplierText : MonoBehaviour
{
    TMP_Text multiplier;

    void Start()
    {
        multiplier = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        multiplier.text = GameManager.instance.GetMultiplier().ToString();
    }
}