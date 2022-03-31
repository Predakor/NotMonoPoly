using UnityEngine;
using UnityEngine.UI;

using TMPro;


using Photon.Pun;
using Photon.Realtime;


using System.Collections;

public class PlayerProfileInputs : MonoBehaviour
{

    [SerializeField] TMP_InputField playerNameInput;
    const string playerNameKey = "PlayerName";

    void Awake()
    {
        if (playerNameInput) return;
        playerNameInput = GetComponentInChildren<TMP_InputField>();
    }

    void Start()
    {
        if (!playerNameInput) return;

        string defaultName = "Player";

        if (PlayerPrefs.HasKey(playerNameKey))
        {
            defaultName = PlayerPrefs.GetString(playerNameKey);
            playerNameInput.text = defaultName;
        }
        PhotonNetwork.NickName = defaultName;
    }

    public void SetPlayerName()
    {
        string value = playerNameInput.text;
        if (string.IsNullOrEmpty(value)) return;

        PhotonNetwork.NickName = value;
        PlayerPrefs.SetString(playerNameKey, value);
        Debug.Log(PhotonNetwork.NickName);
    }

}