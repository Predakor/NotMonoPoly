using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] Tile currentTile;
    [SerializeField] new string name;
    [SerializeField] int money = 1000;
    [SerializeField] List<Tile> ownedTiles;
    [SerializeField] GameObject model;

    public int position = 0;

    public Tile CurrentTile { get => currentTile; set => currentTile = value; }

    void Start()
    {
        if (CurrentTile) return;
        Debug.Log("set current tiles");
    }

    void Update()
    {

    }

    public void AddMoney(int amount)
    {
        money += amount;
        if (money > 0) return;
        bankrupt(this);
    }

    void bankrupt(Player player)
    {
        Debug.Log("You're broke as fuck bro");
    }
}