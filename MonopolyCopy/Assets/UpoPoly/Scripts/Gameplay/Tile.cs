using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    #region Variables
    [SerializeField] Player owner;
    [SerializeField] List<Player> players = new List<Player>();
    [SerializeField] List<GameObject> houses = new List<GameObject>();
    [SerializeField] new string name = "New Tile";
    [SerializeField] int basePrice = 1000;
    [SerializeField] int value = 1000;
    #endregion

    void Start()
    {

    }

    void Update()
    {

    }


    public void ChangeOwner(Player player)
    {
        owner = player;
        updateTile();
    }

    public void AddHouse(GameObject house, int amount = 1)
    {
        for (int i = 0; i < amount; i++)
            houses.Add(house);
        updateTile();
    }

    public void SellHouse(int amount = 1)
    {
        if (amount > houses.Count)
            amount = 0;
        houses.RemoveAt(houses.Count - amount);
        updateTile();
    }

    private void updateTile()
    {
        throw new NotImplementedException();
    }
}