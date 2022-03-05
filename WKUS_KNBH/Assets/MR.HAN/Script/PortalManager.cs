using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class PortalManager : MonoBehaviourPunCallbacks
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Flower")
        {
            PhotonNetwork.LoadLevel(4);
        }
        if(other.tag == "Bridge")
        {
          //  PhotonNetwork.AutomaticallySyncScene = false;
            PhotonNetwork.LoadLevel(3);
         //   Destroy(gameObject);
        }
    }
}
