using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ComportamientoGame : MonoBehaviour
{

    private int _itemsCollected = 0;
    private int _playerHP = 10;

    public int MaxItems = 4;
    public TMP_Text TextHealth;
    public TMP_Text TextItem;
    public TMP_Text Texto;


     void Start()
    {
        TextItem.text += _itemsCollected;
        TextHealth.text += _playerHP;
    }

    public int Items
    {

        get { return _itemsCollected; }

        set
        {
            _itemsCollected = value;
            Debug.LogFormat("Items: {0}", _itemsCollected);
            TextItem.text = "Items Collected: " + Items;
            
            if (_itemsCollected >= MaxItems)
            {
                Texto.text = "You've found all the items!";
            }
            else
            {
                Texto.text = "Item found, only " + (MaxItems - _itemsCollected)
                + " more!";
            }

        }
    }

    public int HP
    {
        get { return _playerHP; }
        set
        {
            _playerHP = value;
            Debug.LogFormat("Lives: {0}", _playerHP);
            TextHealth.text = "Player Health: " + HP;
            Debug.LogFormat("Lives: {0}", _playerHP);

        }
    }

}
