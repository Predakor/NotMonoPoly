using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    [SerializeField] List<Tile> tiles;
    [SerializeField] GameObject tileHolder;
    [SerializeField] DiceRoller roller;
    [SerializeField] PlayersManager players;

    void Awake()
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
    void Start()
    {


    }

    void EndTurn()
    {
        players.NextPlayer();
    }

    [ContextMenu("Simulate a roll")]
    public void MoveSimulate()
    {
        int rollResult = roller.GetRollResults();
        MovePlayer(rollResult);
        EndTurn();
    }

    public void MovePlayer(int amount)
    {
        Player player = players.currentPlayer;

        int destination = player.position + amount;

        if (destination >= tiles.Count)
        {
            destination = (tiles.Count - (player.position + amount)) * -1;
        }
        player.position = destination;
        player.AddMoney(400);

        Tile destinationTile = tiles[destination];
        player.gameObject.transform.position = destinationTile.transform.position;

        //change this mess
        destinationTile.AddPlayer(player);
        destinationTile.UpdateTile();
        player.CurrentTile.RemovePlayer(player);
        player.CurrentTile.UpdateTile();

    }
}