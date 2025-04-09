using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using CustomExtensions;
using System.Linq;

public class GameBehavior : MonoBehaviour, IManager
{
    private string _state;
    public string State
    {
        get { return _state; }
        set { _state = value; }
    }
    public int maxItems = 4;
    public TMP_Text healthText;
    public TMP_Text itemText;
    public TMP_Text progressText;
    public Button winButton;
    public Button lossButton;
    public Stack<Loot> lootStack = new Stack<Loot>();

    private int _itemsCollected = 0;
    public int Items
    {
        get
        {
            return _itemsCollected;
        }
        set
        {
            _itemsCollected = value;
            itemText.text = "Items Collected: " + Items;
            if (_itemsCollected >= maxItems)
            {
                winButton.gameObject.SetActive(true);
                UpdateScene("You've found all the items!");
            }
            else
            {
                progressText.text = "Items Collected: " + _itemsCollected + " / " + maxItems;
            }
        }
    }

    private int _playerHP = 10;
    public int HP
    {
        get
        {
            return _playerHP;
        }
        set
        {
            _playerHP = value;
            healthText.text = "Health: " + HP;
            
            if (_playerHP <= 0)
            {
                lossButton.gameObject.SetActive(true);
                UpdateScene("You want another life with that?");
            }
            else
            {
                progressText.text = "Ouch... that's gotta hurt.";
            }

            Debug.LogFormat("Health: {0}", _playerHP);
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        itemText.text += _itemsCollected;
        healthText.text += _playerHP;
        Initialize();
    }

 
    public void Initialize()
    {
        _state = "Game Manager Initialized.";
        _state.FancyDebug();
        Debug.Log(_state);

        lootStack.Push(new Loot("Sword of Doom", 5));
        lootStack.Push(new Loot("HP Boost", 1));
        lootStack.Push(new Loot("Golden Key", 3));
        lootStack.Push(new Loot("Pair of Winged Boots", 2));
        lootStack.Push(new Loot("Mythril Bracers", 4));
        FilterLoot();
    }

    public void RestartScene()
    {
        Utilities.RestartLevel(0);
    }
    public void UpdateScene(string updatedText)
    {
        progressText.text = updatedText;
        Time.timeScale = 0;
    }

    public void PrintLootReport()
    {
        var currentItem = lootStack.Pop();
        var nextItem = lootStack.Peek();

        Debug.LogFormat("You got a {0}! You've got a good chance of finding a {1} next!", currentItem.itemName, nextItem.itemName);
        Debug.LogFormat("There are {0} random loot items waiting for you!", lootStack.Count);
    }

    public void FilterLoot()
    {
        var rareLoot = from item in lootStack
                       where item.rarity >= 3
                       orderby item.rarity
                       select item;

        foreach (var item in rareLoot)
        {
            Debug.LogFormat("Rare item: {0}!", item.itemName);
        }
    }

    public bool LootPredicate(Loot loot)
    {
           return loot.rarity >= 3;
    }
}
