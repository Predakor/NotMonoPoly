using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    [SerializeField] List<Tile> tiles;
    [SerializeField] GameObject tileHolder;
    [SerializeField] DiceRoller roller;
    [SerializeField] Player player;

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
        if (tiles.Count > 0) return;

        int tilesCount = tileHolder.transform.childCount;
        for (int i = 0; i < tilesCount; i++)
        {
            GameObject currentTile = tileHolder.transform.GetChild(i).gameObject;
            if (currentTile.GetComponent<Tile>())
                tiles.Add(currentTile.GetComponent<Tile>());

        }

    }

    [ContextMenu("Simulate a roll")]
    public void MoveSimulate()
    {
        int rollResult = roller.GetRollResults();
        MovePlayer(player, rollResult);
    }


    public void MovePlayer(Player player, int amount)
    {
        int destination = player.position + amount;

        if (destination > tiles.Count)
        {
            destination = (tiles.Count - (player.position + amount)) * -1;
        }
        player.position = destination;

        Transform destinationTile = tiles[destination].transform;
        player.gameObject.transform.position = destinationTile.position;
        Debug.Log($"You should be on tile {destination}");
    }
}