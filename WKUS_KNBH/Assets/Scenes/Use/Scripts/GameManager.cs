using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

namespace Com.MyCompany.MyGame
{


    public class GameManager : MonoBehaviourPunCallbacks
    {
        #region Photon Callbacks

        public override void OnLeftRoom()
        {
           // base.OnLeftRoom();
            SceneManager.LoadScene(0);
        }
        #endregion

        #region Punlic Methods

        public void LeaveRoom()
        {
            PhotonNetwork.LeaveRoom();
        }
        #endregion

        #region Private Methods
        void LoadArena()
        {
            if (!PhotonNetwork.IsMasterClient)
            {
                Debug.LogError("PhotonNEtwork : Trying to Load a level but we are not the master Client");
            }
            Debug.LogFormat("PhotonNetwork: Loading LEvel : {0}", PhotonNetwork.CurrentRoom.PlayerCount);
            PhotonNetwork.LoadLevel("Roon for " + PhotonNetwork.CurrentRoom.PlayerCount);
        }

        #endregion

        #region Photon Callbacks

        public override void OnPlayerEnteredRoom(Player other)
        {
            // base.OnPlayerEnteredRoom(newPlayer);
            Debug.LogFormat("OnPlayerEnteredRoom() {0}", other.NickName);

            if (PhotonNetwork.IsMasterClient)
            {
                Debug.LogFormat("OnPlayerEnteredRoom IsMasterClient {0}", PhotonNetwork.IsMasterClient);

           LoadArena();
            }
        }

        public override void OnPlayerLeftRoom(Player other)
        {
            // base.OnPlayerLeftRoom(otherPlayer);
            Debug.LogFormat("OnPlayerLeftRoom() {0}", other.NickName);

            if (PhotonNetwork.IsMasterClient)
            {
                Debug.LogFormat("OnPlayerLeftLoom IsMasterClient {0}", PhotonNetwork.IsMasterClient);

                LoadArena();
            }
        }
        #endregion
    }

}