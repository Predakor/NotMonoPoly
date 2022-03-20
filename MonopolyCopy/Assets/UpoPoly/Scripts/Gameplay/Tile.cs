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
    [SerializeField] int basePrice = 500;
    public int value { get; private set; }

    #endregion

    void Start()
    {

    }

    void Update()
    {

    }



    public void OnPlayerEntry()
    {

    }
    public void OnPlayerExit()
    {

    }

    public void BuyTile(Player player)
    {
        owner = player;
    }

    public void AddPlayer(Player player)
    {
        players.Add(player);
        if (owner == null)
            ShowTileCard(true);
        else if (owner == player)
            return;
        else
            player.AddMoney(-value);

    }

    private void ShowTileCard(bool isOwner)
    {
        BoardManager.instance.onPlayerEnter.Invoke();
    }

    public void RemovePlayer(Player player)
    {
        players.Remove(player);
    }

    public void ChangeOwner(Player player)
    {
        owner = player;
        UpdatePlayerPositions();
    }

    public void AddHouse(GameObject house, int amount = 1)
    {
        for (int i = 0; i < amount; i++)
            houses.Add(house);
        UpdatePlayerPositions();
    }

    public void SellHouse(int amount = 1)
    {
        if (amount > houses.Count)
            amount = 0;
        houses.RemoveAt(houses.Count - amount);
        UpdatePlayerPositions();
    }

    public void UpdateTile()
    {
        UpdatePlayerPositions();
        UpdateHouses();
    }
    void UpdatePlayerPositions()
    {
        Vector3 offset = new Vector3(0, .2f, 0);
        if (players.Count > 1)
        {
            for (int i = 0; i < players.Count; i++)
                players[i].transform.position = transform.position + (offset * i);

        }
    }
    void UpdateHouses()
    {
        value = basePrice + (300 * houses.Count);
    }
}