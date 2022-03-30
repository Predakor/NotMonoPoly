using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] new string name;
    [SerializeField] int money = 1000;
    [SerializeField] List<Tile> ownedTiles;
    [SerializeField] GameObject model;
    [SerializeField] TextMeshProUGUI moneyDisplay;
    [SerializeField] TextMeshProUGUI nameDisplay;
    public Tile currentTile;
    public int position = 0;


    void Start()
    {
        if (!currentTile)
            Debug.Log("set current tiles");
        UpdateUI();
    }

    void Update()
    {
    }

    public void AddMoney(int amount)
    {
        money += amount;
        if (money <= 0)
            bankrupt(this);
        UpdateUI();
    }

    void bankrupt(Player player)
    {
        Debug.Log("You're broke as fuck bro");
        name += "bankrupt";
    }

    public void BuyTile(Tile tile)
    {
        if (tile.Value > money) return;
        AddMoney(-tile.Value);
        ownedTiles.Add(tile);
    }

    public void SellTile(Tile tile)
    {
        ownedTiles.Remove(tile);
        AddMoney(tile.Value);
    }

    void UpdateUI()
    {
        moneyDisplay.text = $"{money}$";
        nameDisplay.text = name;
    }
}