using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UIElements;

public class GirlGenerator : MonoBehaviour
{

    public List<HairColor> hairColors = new List<HairColor>();

    public List<EyeColor> eyeColors = new List<EyeColor>();

    public List<Sprite> BaseBodies;

    public List<Sprite> Clothes;

    public List<Sprite> Accessories;

    public List<Sprite> BubbleSprites;

    [SerializeField] GameObject Girl;

    [SerializeField] List<string> bubbleTypes;

    [SerializeField] GameObject Preference, Dislike;

    SpriteRenderer pref, dislike;

    string currentPreference;

    string previousPreference;

    string currentDislike;

    string previousDislike;

    void Start()
    {
        currentPreference = "Chocolate";

        currentDislike = "Hand Gesture";

        pref = Preference.GetComponent<SpriteRenderer>();

        dislike = Dislike.GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            GenerateNewGirl();
        }
    }

    public void GenerateNewGirl()
    {

        previousPreference = currentPreference;
        previousDislike = currentDislike;

        currentPreference = "";
        currentDislike = "";

        while (currentPreference == "")
        {
            int newPrefID = Random.Range(0, bubbleTypes.Count);

            string newPref = bubbleTypes[newPrefID];

            if (newPref != previousPreference)
            {
                currentPreference = newPref;
                Preference.GetComponent<SpriteRenderer>().sprite = BubbleSprites[newPrefID];
            }
        }

        while (currentDislike == "")
        {
            int newDislikeID = Random.Range(0, bubbleTypes.Count);

            string newDislike = bubbleTypes[newDislikeID];

            if (newDislike != previousDislike && newDislike != currentPreference)
            {
                currentDislike = newDislike;

                Dislike.GetComponent<SpriteRenderer>().sprite = BubbleSprites[newDislikeID];
            }
        }

        Debug.Log(currentPreference);
        Debug.Log(currentDislike);


        GenerateSprite();
    }

    public string GetPreference()
    {
        return currentPreference;
    }

    public string GetDislike()
    {
        return currentDislike;
    }

    void GenerateSprite()
    {
        Girl.GetComponent<GirlScript>().SetBody(BaseBodies);

        int Color = Random.Range(0, hairColors.Count);

        int HairType = Random.Range(0, hairColors[Color].hairTypes.Count);

        int eyeColor = Random.Range(0, eyeColors.Count);

        if (HairType % 2 == 1)
        {
            HairType = HairType - 1;
        }

        Girl.GetComponent<GirlScript>().SetHair(hairColors[Color].hairTypes[HairType]);

        Girl.GetComponent<GirlScript>().SetBackHair(hairColors[Color].hairTypes[HairType + 1]);

        Girl.GetComponent<GirlScript>().SetClothes(Clothes[Random.Range(0, Clothes.Count)]);

        Girl.GetComponent<GirlScript>().SetEyes(eyeColors[eyeColor].eyeExpressions);

        int accessoryID = Random.Range(0, Accessories.Count);

        if (accessoryID != Accessories.Count + 1)
        {
            Girl.GetComponent<GirlScript>().SetAccessory(Accessories[accessoryID]);
        }
    }

}
