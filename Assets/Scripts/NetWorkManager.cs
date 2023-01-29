using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetWorkManager : MonoBehaviourPunCallbacks 
{

    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings();
    }


    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions { MaxPlayers = 3 }, null);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.Instantiate("Player", Vector3.zero, Quaternion.identity);
    }
}
