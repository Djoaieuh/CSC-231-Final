using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class GirlGenerator : MonoBehaviour
{

    [SerializeField] List<Sprite> sprites;


    [SerializeField] List<string> bubbleTypes;

    string currentPreference;

    string previousPreference;

    string currentDislike;

    string previousDislike;

    void Start()
    {
        currentPreference = "Chocolate";

        currentDislike = "Hand Gesture";
    }
    void Update()
    {

    }

    public void GenerateNewGirl()
    {

        previousPreference = currentPreference;
        previousDislike = currentDislike;

        currentPreference = "";
        currentDislike = "";

        while (currentPreference == "")
        {
            string newPref = bubbleTypes[Random.Range(0, bubbleTypes.Count)];

            Debug.Log(newPref);

            if (newPref != previousPreference)
            {
                currentPreference = newPref;

                Debug.Log(currentPreference);
            }
        }

        while (currentDislike == "")
        {
            string newDislike = bubbleTypes[Random.Range(0, bubbleTypes.Count)];

            if (newDislike != previousDislike && newDislike != currentPreference)
            {
                currentDislike = newDislike;
            }
        }

    }

    public string GetPreference()
    {
        return currentPreference;
    }

    public string GetDislike()
    {
        return currentDislike;
    }

}
