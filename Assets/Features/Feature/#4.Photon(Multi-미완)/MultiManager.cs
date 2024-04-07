using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using Photon.Pun;
using Photon.Realtime;

namespace Com.MyCompany.MyGame
{
    public class MultiManager : MonoBehaviourPunCallbacks
    {
        public static MultiManager Instance;

        public GameObject playerPrefab;

        private void Start()
        {
            Instance = this;

            if (PlayerManager.LocalPlayerInstance == null)
            {
                PhotonNetwork.Instantiate(this.playerPrefab.name, new Vector3(0f, 5f, 0f), Quaternion.identity, 0);
            }
        }

        #region Photon Callbacks

        public override void OnLeftRoom()
        {
            SceneManager.LoadScene(0);
        }

        public override void OnPlayerEnteredRoom(Player other)
        {
            Debug.Log($"OnPlayerEnteredRoom() {other.NickName}");

            if (PhotonNetwork.IsMasterClient)
            {
                Debug.Log($"OnPlayerEnteredRoom IsMasterClient {PhotonNetwork.IsMasterClient}");
                LoadArena();
            }
        }

        public override void OnPlayerLeftRoom(Player other)
        {
            Debug.Log($"OnPlayerLeftRoom() {other.NickName}");

            if (PhotonNetwork.IsMasterClient)
            {
                Debug.Log($"OnPlayerLeftRoom IsMasterClient {PhotonNetwork.IsMasterClient}");
                LoadArena();
            }
        }

        #endregion

        private void LoadArena()
        {
            if (!PhotonNetwork.IsMasterClient)
            {
                Debug.LogError("PhotonNetwork : Trying to load a level but we are not the master client");
                return;
            }

            Debug.Log($"PhotonNetwork : Loading Level : {PhotonNetwork.CurrentRoom.PlayerCount}");
            PhotonNetwork.LoadLevel("RoomFor" + PhotonNetwork.CurrentRoom.PlayerCount);
        }


        public void LeaveRoom()
        {
            PhotonNetwork.LeaveRoom();
        }
    }

}