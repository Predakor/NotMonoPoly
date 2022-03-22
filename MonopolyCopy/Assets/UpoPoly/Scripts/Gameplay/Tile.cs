using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    #region Variables
    [SerializeField] new string name = "New Tile";
    [SerializeField] Player owner = null;
    [SerializeField] List<Player> playersOnTile;
    [SerializeField] List<GameObject> houses;
    [SerializeField] int basePrice = 500;
    int value = 0;
    public bool isForSale = true;
    #endregion

    public string Name { get => name; private set => name = value; }
    public Player Owner { get => owner; private set => owner = value; }
    public int Upgrades { get => houses.Count; }
    public int BasePrice { get => basePrice; private set => basePrice = value; }
    public int Value { get => value; private set => this.value = value; }


    void Start()
    {
        if (value != 0) return;
        value = basePrice;
    }

    public void OnPlayerEntry(Player player)
    {
        playersOnTile.Add(player);
        if (Owner == null)
            ShowSaleCard();
        else if (Owner == player)
            return;
        else
            player.AddMoney(-Value);
        //update other player UI too

        UpdatePlayerPositions();
    }
    public void OnPlayerExit(Player player)
    {
        playersOnTile.Remove(player);
    }

    public void BuyTile(Player player)
    {
        Owner = player;
        isForSale = false;
        UpdateTile();
    }

    private void ShowSaleCard()
    {
        BoardManager.instance.GetBuyCard(this);
    }

    public void BuyHouse(GameObject house, int amount = 1)
    {
        for (int i = 0; i < amount; i++)
            houses.Add(house);
        UpdateHouses();
    }
    public void SellHouse(int amount = 1)
    {
        if (amount > houses.Count)
            amount = houses.Count;
        houses.RemoveAt(houses.Count);
        UpdateHouses();
    }

    public void UpdateTile()
    {
        UpdatePlayerPositions();
        UpdateHouses();
    }




    void UpdatePlayerPositions()
    {
        Vector3 offset = new Vector3(0, .2f, 0);
        for (int i = 0; i < playersOnTile.Count; i++)
            playersOnTile[i].transform.position = transform.position + (offset * i);
    }

    void UpdateHouses()
    {
        value = BasePrice + (300 * houses.Count);
    }
}