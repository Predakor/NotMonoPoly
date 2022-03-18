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


    public void AddPlayer(Player player)
    {
        players.Add(player);
    }
    public void RemovePlayer(Player player)
    {
        players.Remove(player);
    }

    public void ChangeOwner(Player player)
    {
        owner = player;
        UpdateTile();
    }

    public void AddHouse(GameObject house, int amount = 1)
    {
        for (int i = 0; i < amount; i++)
            houses.Add(house);
        UpdateTile();
    }

    public void SellHouse(int amount = 1)
    {
        if (amount > houses.Count)
            amount = 0;
        houses.RemoveAt(houses.Count - amount);
        UpdateTile();
    }

    public void UpdateTile()
    {
        Vector3 offset = new Vector3(0, .2f, 0);
        if (players.Count > 1)
        {
            for (int i = 0; i < players.Count; i++)
                players[i].transform.position = transform.position + (offset * i) + (Vector3.up * .1f);

        }
    }
}