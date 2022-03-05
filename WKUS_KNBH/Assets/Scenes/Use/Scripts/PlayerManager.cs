using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public PhotonView PV;

    public static PlayerManager Instance;

    // GameObject controller;

    void Awake()
    {
        Instance = this;
        PV = GetComponent<PhotonView>();
    }


    void Start()
    {
        if (PV.IsMine)
        {
            CreateController();
        }


        void CreateController()
        {
            Transform spawnpoint = SpawnManager.Instance.GetSpawnpoint();

            if (SceneManager.GetActiveScene().name == "4. Bridge")
            {
                if (Select_Character.number == 1)
                {
                    PhotonNetwork.Instantiate(Path.Combine("BridgePrefabs", "Cat_Player"), spawnpoint.position, spawnpoint.rotation);
                }
                else if (Select_Character.number == 2)
                {
                    PhotonNetwork.Instantiate(Path.Combine("BridgePrefabs", "Deer_Player"), spawnpoint.position, spawnpoint.rotation);
                }
                else if (Select_Character.number == 3)
                {
                    PhotonNetwork.Instantiate(Path.Combine("BridgePrefabs", "Dog_Player"), spawnpoint.position, spawnpoint.rotation);
                }
                else if (Select_Character.number == 4)
                {
                    PhotonNetwork.Instantiate(Path.Combine("BridgePrefabs", "Fox_Player"), spawnpoint.position, spawnpoint.rotation);
                }
                else if (Select_Character.number == 5)
                {
                    PhotonNetwork.Instantiate(Path.Combine("BridgePrefabs", "Panda_Player"), spawnpoint.position, spawnpoint.rotation);
                }
                else if (Select_Character.number == 6)
                {
                    PhotonNetwork.Instantiate(Path.Combine("BridgePrefabs", "Pig_Player"), spawnpoint.position, spawnpoint.rotation);
                }
                else
                {
                    PhotonNetwork.Instantiate(Path.Combine("BridgePrefabs", "Bear_Player"), spawnpoint.position, spawnpoint.rotation);
                }
                //PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerController_Bridge"), spawnpoint.position, spawnpoint.rotation);
            }
            else if (SceneManager.GetActiveScene().name == "5. Flower")
            {
                if (Select_Character.number == 1)
                {
                    PhotonNetwork.Instantiate(Path.Combine("FlowerPrefabs", "Cat_Player"), spawnpoint.position, spawnpoint.rotation);
                }
                else if (Select_Character.number == 2)
                {
                    PhotonNetwork.Instantiate(Path.Combine("FlowerPrefabs", "Deer_Player"), spawnpoint.position, spawnpoint.rotation);
                }
                else if (Select_Character.number == 3)
                {
                    PhotonNetwork.Instantiate(Path.Combine("FlowerPrefabs", "Dog_Player"), spawnpoint.position, spawnpoint.rotation);
                }
                else if (Select_Character.number == 4)
                {
                    PhotonNetwork.Instantiate(Path.Combine("FlowerPrefabs", "Fox_Player"), spawnpoint.position, spawnpoint.rotation);
                }
                else if (Select_Character.number == 5)
                {
                    PhotonNetwork.Instantiate(Path.Combine("FlowerPrefabs", "Panda_Player"), spawnpoint.position, spawnpoint.rotation);
                }
                else if (Select_Character.number == 6)
                {
                    PhotonNetwork.Instantiate(Path.Combine("FlowerPrefabs", "Pig_Player"), spawnpoint.position, spawnpoint.rotation);
                }
                else
                {
                    PhotonNetwork.Instantiate(Path.Combine("FlowerPrefabs", "Bear_Player"), spawnpoint.position, spawnpoint.rotation);
                }
            }
            else
            {
                //Select_Character.Instance.Character_Select();
                if (Select_Character.number == 1)
                {
                    PhotonNetwork.Instantiate(Path.Combine("PrimePrefabs", "Cat_Player"), spawnpoint.position, spawnpoint.rotation);
                }
                else if (Select_Character.number == 2)
                {
                    PhotonNetwork.Instantiate(Path.Combine("PrimePrefabs", "Deer_Player"), spawnpoint.position, spawnpoint.rotation);
                }
                else if(Select_Character.number==3)
                {
                    PhotonNetwork.Instantiate(Path.Combine("PrimePrefabs", "Dog_Player"), spawnpoint.position, spawnpoint.rotation);
                }
                else if(Select_Character.number==4)
                {
                    PhotonNetwork.Instantiate(Path.Combine("PrimePrefabs", "Fox_Player"), spawnpoint.position, spawnpoint.rotation);
                }
                else if(Select_Character.number==5)
                {
                    PhotonNetwork.Instantiate(Path.Combine("PrimePrefabs", "Panda_Player"), spawnpoint.position, spawnpoint.rotation);
                }
                else if(Select_Character.number==6)
                {
                    PhotonNetwork.Instantiate(Path.Combine("PrimePrefabs", "Pig_Player"), spawnpoint.position, spawnpoint.rotation);
                }
                else
                {
                    PhotonNetwork.Instantiate(Path.Combine("PrimePrefabs", "Bear_Player"), spawnpoint.position, spawnpoint.rotation);
                }
                //PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerController 1"), spawnpoint.position, spawnpoint.rotation);  -> 기존 인힛테이트               
            }
            //     PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Cube"), Vector3.zero, Quaternion.identity); Debug.Log("instantiated Player controller");
        } 
    }
    public void PrimeCharacter()
    {

    }
}
