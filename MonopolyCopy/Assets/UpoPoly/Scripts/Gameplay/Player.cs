using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] Tile tile;
    [SerializeField] new string name;
    [SerializeField] int money = 1000;

    public int position = 0;


    void Start()
    {

    }

    void Update()
    {

    }

    public void updateMoney(int amount)
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