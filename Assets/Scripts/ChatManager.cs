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
 
    string m_strUserName;
 
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        m_ContentText = m_Content.transform.GetChild(0).gameObject;
        photonview = GetComponent<PhotonView>();
    }
 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && m_inputField.isFocused == false) // 채팅 상태가 아닐때 엔터를 누르면 채팅창 활성화
        {
            m_inputField.ActivateInputField();
        }

        if(m_inputField.isFocused == true)
            isChatting = true;
        else
            isChatting = false;
    }

    public override void OnConnectedToMaster()
    {
        RoomOptions options = new RoomOptions();
        options.MaxPlayers = 5;
 
        int nRandomKey = Random.Range(0, 100);
 
        m_strUserName = "user" + nRandomKey;
 
        PhotonNetwork.LocalPlayer.NickName = m_strUserName;
        PhotonNetwork.JoinOrCreateRoom("Room1", options, null);
    }
 
    public override void OnJoinedRoom()
    {
        AddChatMessage("connect user : " + PhotonNetwork.LocalPlayer.NickName);
    }
 
    public void OnEndEditEvent()
    {
        if (Input.GetKeyDown(KeyCode.Return) && m_inputField.text != "")
        {
            string strMessage = m_strUserName + " : " + m_inputField.text;
 
            photonview.RPC("RPC_Chat", RpcTarget.All, strMessage);
            m_inputField.text = "";
        }
    }
 
    void AddChatMessage(string message) // 채팅 입력
    {
        /*GameObject goText = Instantiate(m_ContentText, m_Content.transform);
 
        goText.GetComponent<TextMeshProUGUI>().text = message;
        m_Content.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;*/

        GameObject goText = Instantiate(m_ContentText, m_Content.transform);
        goText.GetComponent<TextMeshProUGUI>().text = message;
    
        RectTransform rectTransform = goText.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, rectTransform.anchoredPosition.y - (rectTransform.sizeDelta.y * m_Content.transform.childCount));
    
        m_Content.GetComponent<RectTransform>().sizeDelta = new Vector2(m_Content.GetComponent<RectTransform>().sizeDelta.x, m_Content.GetComponent<RectTransform>().sizeDelta.y + rectTransform.sizeDelta.y);
    }
 
    [PunRPC]
    void RPC_Chat(string message)
    {
        AddChatMessage(message);
    }
 
}