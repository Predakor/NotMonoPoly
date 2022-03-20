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

    public static BoardManager instance;
    public UnityEvent onPlayerEnter;

    Player currentPLayer => playerManager.currentPlayer;

    void Awake()
    {
        if (instance) return;
        instance = this;
    }
    void Start()
    {
        if (tiles.Count > 0) return;

        int tilesCount = tileHolder.transform.childCount;
        for (int i = 0; i < tilesCount; i++)
        {
            GameObject currentTile = tileHolder.transform.GetChild(i).gameObject;
            if (currentTile.GetComponent<Tile>())
                tiles.Add(currentTile.GetComponent<Tile>());
        }

    }

    public void BuyTile()
    {
        Tile _tile = currentPLayer.currentTile;
        currentPLayer.BuyTile(_tile);
        _tile.BuyTile(currentPLayer);
    }

    [ContextMenu("Simulate a roll")]
    public void MoveSimulate()
    {
        roller.ThrowDices();
        Invoke("getResult", 2);
        EndTurn();
    }
    void getResult()
    {
        int rollResult = roller.GetRollResults();
        MovePlayer(rollResult);
    }
    public void MovePlayer(int amount)
    {
        Player player = playerManager.currentPlayer;

        int destination = player.position + amount;

        if (destination >= tiles.Count)
        {
            destination = (tiles.Count - (player.position + amount)) * -1;
            player.AddMoney(400);
        }

        player.position = destination;

        Tile destinationTile = tiles[destination];
        player.gameObject.transform.position = destinationTile.transform.position;

        //change this mess
        destinationTile.AddPlayer(player);
        destinationTile.UpdateTile();
        player.currentTile.RemovePlayer(player);
        player.currentTile = destinationTile;
        player.currentTile.UpdateTile();
    }

    void EndTurn() => playerManager.NextPlayer();
}