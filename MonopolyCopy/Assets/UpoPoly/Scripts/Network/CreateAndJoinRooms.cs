using UnityEngine;
using Photon.Pun;
using TMPro;
using Photon.Realtime;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{

    [SerializeField] TMP_InputField createInput;
    [SerializeField] TMP_InputField joinInput;

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom("Test", new RoomOptions { MaxPlayers = 4 });
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinInput.text);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log("Cant Connnect To Room");
        base.OnJoinRoomFailed(returnCode, message);
    }

}