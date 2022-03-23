using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Unity.Netcode;

public class Player : NetworkBehaviour
{

    [SerializeField] new string name;
    [SerializeField] int money = 1000;
    [SerializeField] List<Tile> ownedTiles;
    [SerializeField] GameObject model;
    [SerializeField] TextMeshProUGUI moneyDisplay;
    [SerializeField] TextMeshProUGUI nameDisplay;
    public Tile currentTile;
    public int position = 0;


    void Start()
    {
        if (!currentTile)
            Debug.Log("set current tiles");
        UpdateUI();
    }

    void Update()
    {
        transform.position = Position.Value;
    }

    public void AddMoney(int amount)
    {
        money += amount;
        if (money <= 0)
            bankrupt(this);
        UpdateUI();
    }

    void bankrupt(Player player)
    {
        Debug.Log("You're broke as fuck bro");
        name += "bankrupt";
    }

    public void BuyTile(Tile tile)
    {
        if (tile.Value > money) return;
        AddMoney(-tile.Value);
        ownedTiles.Add(tile);
    }

    public void SellTile(Tile tile)
    {
        ownedTiles.Remove(tile);
        AddMoney(tile.Value);
    }

    void UpdateUI()
    {
        moneyDisplay.text = $"{money}$";
        nameDisplay.text = name;
    }
    public NetworkVariable<Vector3> Position = new NetworkVariable<Vector3>();

    public override void OnNetworkSpawn()
    {
        if (IsOwner)
        {
            Move();
        }
    }

    public void Move()
    {
        if (NetworkManager.Singleton.IsServer)
        {
            var randomPosition = GetRandomPositionOnPlane();
            transform.position = randomPosition;
            Position.Value = randomPosition;
        }
        else
        {
            SubmitPositionRequestServerRpc();
        }
    }

    [ServerRpc]
    void SubmitPositionRequestServerRpc(ServerRpcParams rpcParams = default)
    {
        Position.Value = GetRandomPositionOnPlane();
    }

    static Vector3 GetRandomPositionOnPlane()
    {
        return new Vector3(UnityEngine.Random.Range(-3f, 3f), 1f, UnityEngine.Random.Range(-3f, 3f));
    }

}