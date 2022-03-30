using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BoardManager : MonoBehaviour
{
    [SerializeField] List<Tile> tiles;
    [SerializeField] GameObject tileHolder;
    [SerializeField] DiceRoller roller;
    [SerializeField] PlayersManager playerManager;
    [SerializeField] CardManager cardManager;

    public static BoardManager instance;


    Player currentPlayer => playerManager.CurrentPlayer;
    public PlayersManager Players { get => playerManager; }
    public List<Tile> Tiles { get => tiles; }

    void Awake()
    {
        if (instance) return;
        instance = this;
    }

    void Start()
    {
        if (Tiles.Count > 0) return;

        int tilesCount = tileHolder.transform.childCount;
        for (int i = 0; i < tilesCount; i++)
        {
            GameObject currentTile = tileHolder.transform.GetChild(i).gameObject;
            if (currentTile.GetComponent<Tile>())
                Tiles.Add(currentTile.GetComponent<Tile>());
        }
    }

    public void GetBuyCard(Tile tile) => cardManager.ShowBuyCard(tile);
    public void GetDetailsCard(Tile tile) => cardManager.ShowDetailsCard(tile);

    public void BuyTile()
    {
        Tile tile = currentPlayer.currentTile;
        currentPlayer.BuyTile(tile);
        tile.BuyTile(currentPlayer);
    }

    [ContextMenu("Simulate a roll")]
    public void MoveSimulate()
    {
        roller.ThrowDices();
        Invoke("getResult", 2);
    }
    void getResult()
    {
        int rollResult = roller.GetRollResults();
        MovePlayer(rollResult);
    }
    public void MovePlayer(int amount)
    {
        Player player = playerManager.CurrentPlayer;

        int destination = player.position + amount;

        if (destination >= Tiles.Count)
        {
            destination = (Tiles.Count - (player.position + amount)) * -1;
            player.AddMoney(400);
        }

        player.position = destination;

        Tile destinationTile = Tiles[destination];
        player.gameObject.transform.position = destinationTile.transform.position;

        //change this mess
        destinationTile.OnPlayerEntry(player);
        player.currentTile.OnPlayerExit(player);
        player.currentTile = destinationTile;
    }

    void EndTurn() => playerManager.NextPlayer();
}