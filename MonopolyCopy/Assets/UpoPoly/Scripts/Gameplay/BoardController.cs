using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    [SerializeField] List<Tile> tiles;
    [SerializeField] GameObject tileHolder;

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

    void Update()
    {

    }
}