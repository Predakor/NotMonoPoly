using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersManager : MonoBehaviour
{

    [SerializeField] List<Player> players;

    public Player currentPlayer { get; private set; }
    private int currentIndex;

    void Start()
    {
        if (currentPlayer) return;
        currentIndex = 0;
        currentPlayer = players[currentIndex];
    }

    public void NextPlayer()
    {
        currentIndex++;
        if (currentIndex > 3)
            currentIndex = 0;
        currentPlayer = players[currentIndex];
    }

    public void AddPlayer(Player player)
    {
        if (players.Count > 4) return;
        players.Add(player);

    }
    public void GeneratePlayers()
    {
        foreach (Player player in players)
        {
            Instantiate(player, transform.position, transform.rotation);
        }
    }

}