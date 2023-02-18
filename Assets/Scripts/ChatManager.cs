using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
 
public class ChatManager : MonoBehaviourPunCallbacks
{
    public GameObject m_Content;
    public TMP_InputField m_inputField;

    public bool isChatting;
 
    PhotonView photonview;
    GameObject m_ContentText;
 
    string userName;
 
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        m_ContentText = m_Content.transform.GetChild(0).gameObject;
        photonview = GetComponent<PhotonView>();
    }
 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) // 엔터를 누르면 채팅창 활성화/비활성화
        {
            m_inputField.Select();
        }

        if(m_inputField.isFocused == true)
            isChatting = true;
        else
            isChatting = false;
    }
 
    public override void OnJoinedRoom()
    {
        userName = PhotonNetwork.LocalPlayer.NickName;
        AddChatMessage(userName + " 님이 입장했습니다.");
    }
 
    public void OnEndEditEvent() // 채팅 입력 함수 (엔터)
    {
        if (Input.GetKeyDown(KeyCode.Return) && m_inputField.text != "")
        {
            string strMessage = userName + " : " + m_inputField.text;
            photonview.RPC("RPC_Chat", RpcTarget.All, strMessage);
            m_inputField.text = "";
        }
    }

    public void EnterChat() // 채팅 입력 함수 (버튼)
    {
        if(m_inputField.text != "")
        {
            string strMessage = userName + " : " + m_inputField.text;
            photonview.RPC("RPC_Chat", RpcTarget.All, strMessage);
            m_inputField.text = "";
        }
    }
 
    void AddChatMessage(string message) // 채팅 출력 함수
    {
        GameObject goText = Instantiate(m_ContentText, m_Content.transform);
        goText.GetComponent<TextMeshProUGUI>().text = message;
    }
 
    [PunRPC]
    void RPC_Chat(string message)
    {
        AddChatMessage(message);
    }
}