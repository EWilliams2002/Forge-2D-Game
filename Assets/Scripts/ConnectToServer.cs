using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    public string gameModesScene;

    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        print("Connected to server");
    }

    public override void OnConnectedToMaster()
    {
        // This block of code runs once one has successfully 
        // connected to the server
        PhotonNetwork.JoinLobby();
        print("joined lobby");
        
    }

    public override void OnJoinedLobby()
    {
        SceneManager.LoadScene(gameModesScene);
    }
}
