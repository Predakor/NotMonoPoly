using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;
    [SerializeField] Transform playerSpawnPoint;


    void Start()
    {
        PhotonNetwork.Instantiate(playerPrefab.name, playerSpawnPoint.position, Quaternion.identity);
    }
}