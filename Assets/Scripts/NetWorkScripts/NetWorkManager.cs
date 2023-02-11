using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetWorkManager : MonoBehaviourPunCallbacks 
{
    [SerializeField]
    private byte m_MaxPlayer = 8;

    private RoomOptions roomOptions = new RoomOptions();
    

    private string gamever = "1";

    private void Start()
    {
        roomOptions.MaxPlayers = m_MaxPlayer;
    }

    public override void OnConnectedToMaster() //���� ��Ʈ��ũ�� �����ϸ� ���� ���� �ݹ�Ǵ� �Լ�
    {
        Debug.Log("Connected to MasterServer!");
    }

    public override void OnJoinedRoom() //�뿡 ����� �ݹ�Ǵ� �Լ�
    {
        Debug.Log("Welcome this room!");
    }

    public void connect()
    {
        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            PhotonNetwork.GameVersion = gamever;
            PhotonNetwork.ConnectUsingSettings();
        }
    }


    public override void OnJoinRandomFailed(short returnCode, string message) //������ ���� ���н� �ݹ�Ǵ� �Լ�
    {
        Debug.Log("You can't join random room. Create a room forcibly.");
        PhotonNetwork.CreateRoom("null", roomOptions);
    }
}
