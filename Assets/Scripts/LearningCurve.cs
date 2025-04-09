using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearningCurve : MonoBehaviour
{
    private int currentAge = 30;
    public int addedAge = 1;

    //chapter2
    public float pi = 3.14f;
    public string firstName = "Robin";
    public bool isActor = true;

    //chapter3
    public bool hasDungeonKey = true;
    public int currentGold = 42;
    public bool pureOfHeart = true;
    public bool hasSecretIncantation = false;
    public string rareItem = "Relic Stone";
    public string characterAction = "Attack";
    public int diceRoll = 7;

    //chapter5
    public int playerLives = 3;
    public Transform camTransform;
    public GameObject directionLight;
    public Transform lightTransform;
    
    // Start is called before the first frame update
    void Start()
    {
        /*
        if(hasDungeonKey)
        {
            Debug.Log("You possess the sacred key - enter.");
        }
        else
        {
            Debug.Log("You have not proven yourself yet.");
        }

        //chapter3
        Thievery();
        OpenTreasureChamber();
        PrintCharacterAction();
        RollDice();

        //chapter4
        FindPartyMember();
        Dictionary<string, int> itemInventory = new Dictionary<string, int>()
        {
            {"Potion", 5},
            {"Antidote", 7},
            {"Aspirin", 1}
        };
        foreach(KeyValuePair<string, int> kvp in itemInventory)
        {
            Debug.LogFormat("Item: {0} - {1}g", kvp.Key, kvp.Value);
        }
        HealthStatus();
        

        //chapter5
        Character hero = new Character();
        hero.PrintStatsInfo();
        Character hero1 = new Character("Agatha");
        hero1.PrintStatsInfo();
        Weapon huntingBow = new Weapon("Hunting Bow", 105);
        huntingBow.PrintWeaponStats();
        Character villain = hero;
        villain.name = "Villain";
        villain.PrintStatsInfo();
        hero.PrintStatsInfo();
        Weapon warBow = huntingBow;
        warBow.name = "War Bow";
        warBow.damage = 150;
        warBow.PrintWeaponStats();
        huntingBow.PrintWeaponStats();
        Paladin knight = new Paladin("Sir Lancelot", huntingBow);
        knight.PrintStatsInfo();
        camTransform = this.GetComponent<Transform>();
        Debug.Log(camTransform.localPosition);
        directionLight = GameObject.Find("Directional Light");
        lightTransform = directionLight.GetComponent<Transform>();
        Debug.Log(lightTransform.localPosition);
        */

        //chapter6
        //see ItemRotation.cs

        //chapter7

    }
    /// <summary>
    /// Computes a modified age integer
    /// </summary>
    

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void ComputeAge()
    {
        Debug.Log(currentAge + addedAge);
    }

    public int GenerateCharacter(string name, int level)
    {
        //Debug.LogFormat("Character: {0} - Level: {1}", name, level);

        return level += 5;
    }

    public void Thievery()
    {
        if(currentGold > 50)
        {
            Debug.Log("You're rolling in it!");
        }
        else if (currentGold < 15)
        {
            Debug.Log("Not much there to steal...");
        }
        else
        {
            Debug.Log("Looks like your purse is in the sweet spot.");
        }
    }

    public void OpenTreasureChamber()
    {
        if(pureOfHeart && rareItem == "Relic Stone")
        {
            if(!hasSecretIncantation)
            {
                Debug.Log("You have the spirit, but not the knowledge.");
            }
            else
            {
                Debug.Log("The treasure is yours, worthy hero!");
            }
        }
        else
        {
            Debug.Log("Come back when you have what it takes.");
        }
    }

    public void PrintCharacterAction()
    {
        switch(characterAction)
        {
            case "Heal":
                Debug.Log("Potion sent.");
                break;
            case "Attack":
                Debug.Log("To Arms!");
                break;
            default:
                Debug.Log("Shields up.");
                break;
        }
    }

    public void RollDice()
    {
        switch(diceRoll)
        {
            case 7:
            case 15:
                Debug.Log("Mediocre damage, not bad");
                break;
            case 20:
                Debug.Log("Critical Hit, the creature goes down!");
                break;
            default:
                Debug.Log("You completely missed and fell on your face.");
                break;
        }
    }

    public void FindPartyMember()
    {
        List<string> questPartyMembers = new List<string>()
        {
            "Grim the Barbarian",
            "Merlin the Wise",
            "Sterling the Knight"
        };

        foreach(string partyMember in questPartyMembers)
        {
            Debug.LogFormat("{0} - Here!", partyMember);
        }
    }

    public void HealthStatus()
    {
        while(playerLives > 0)
        {
            Debug.LogFormat("You have {0} lives left.", playerLives);
            playerLives--;
        }

        Debug.Log("You have died.");
    }
}
