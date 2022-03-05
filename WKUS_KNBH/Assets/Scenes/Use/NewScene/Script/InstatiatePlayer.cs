using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;
public class InstatiatePlayer : MonoBehaviour
{
    [SerializeField] private GameObject PLayerPrefab = null;
    public Vector3 Player_Spawn_Position;
    public bool Use_Custom_Spawn_Position = false;

    [Header("어디씬인지 입력하세요.")]
    public int whatScene;
    void Start()
    {
        // 2:프라임 3:프라임안 4:강당 5:브릿지 6: 플라워 추후에 함수로 변경 
        switch (whatScene)
        {
            case 2:
                //PhotonNetwork.Instantiate(Path.Combine("PrimePrefabs", "BusinessPlayer"), Player_Spawn_Position, Quaternion.identity);
                Random_Pirme(RandomPick.Instance.random);
                break;
            case 3:
                //PhotonNetwork.Instantiate(Path.Combine("PrimeInPrefabs", "BusinessPlayer_PrimeIn"), Player_Spawn_Position, Quaternion.identity);
                Random_PirmeIn(RandomPick.Instance.random);
                break;
            case 4:
                //PhotonNetwork.Instantiate(Path.Combine("HallPrefabs", "BusinessPlayer_PrimeIn"), Player_Spawn_Position, Quaternion.identity);
                Random_PirmeIn(RandomPick.Instance.random);
                break;
            case 5:
                //PhotonNetwork.Instantiate(Path.Combine("BridgePrefabs", "BusinessPlayer_Bridge"), Player_Spawn_Position, Quaternion.identity);
                Random_Bridge(RandomPick.Instance.random);
                break;
            /* case 6:
                 PhotonNetwork.Instantiate(Path.Combine("PrimeInPrefabs", "BusinessPlayer_PrimeIn"), Player_Spawn_Position, Quaternion.identity);
                 break;
            */
            default:
                break;
        }
        //Player_Spawn_Position = new Vector3(0f, 110f, 0f);
        //PhotonNetwork.Instantiate(Path.Combine("PrimePrefabs", "BusinessPlayer"), Player_Spawn_Position, Quaternion.identity);
    }

    // 프라임 갈때
    public void Random_Pirme(int i)
    {
        //i = RandomPick.Instance.random;
        if (i == 0)
        {
            PhotonNetwork.Instantiate(Path.Combine("PrimePrefabs", "BusinessPlayer"), Player_Spawn_Position, Quaternion.identity);
        }
        else if (i == 1)
        {
            PhotonNetwork.Instantiate(Path.Combine("PrimePrefabs", "FarmerManPlayer"), Player_Spawn_Position, Quaternion.identity);
        }
        else if (i == 2)
        {
            PhotonNetwork.Instantiate(Path.Combine("PrimePrefabs", "FarmerWomanPlayer"), Player_Spawn_Position, Quaternion.identity);
        }
        else if (i == 3)
        {
            PhotonNetwork.Instantiate(Path.Combine("PrimePrefabs", "GrilPlayer"), Player_Spawn_Position, Quaternion.identity);
        }
    }
    //컨퍼런스, 강당 들어갈때
    public void Random_PirmeIn(int i)
    {     
        if (i == 0)
        {
            PhotonNetwork.Instantiate(Path.Combine("PrimeInPrefabs", "BusinessPlayer_PrimeIn"), Player_Spawn_Position, Quaternion.identity);
        }
        else if (i == 1)
        {
            PhotonNetwork.Instantiate(Path.Combine("PrimeInPrefabs", "FarmerManPlayer_PrimeIn"), Player_Spawn_Position, Quaternion.identity);
        }
        else if (i == 2)
        {
            PhotonNetwork.Instantiate(Path.Combine("PrimeInPrefabs", "FarmerWomanPlayer_PrimeIn"), Player_Spawn_Position, Quaternion.identity);
        }
        else if (i == 3)
        {
            PhotonNetwork.Instantiate(Path.Combine("PrimeInPrefabs", "GrilPlayer_PrimeIn"), Player_Spawn_Position, Quaternion.identity);
        }
    }
    //브릿지 들어갈때 
    public void Random_Bridge(int i)
    {
        if (i == 0)
        {
            PhotonNetwork.Instantiate(Path.Combine("BridgePrefabs", "BusinessPlayer_Bridge"), Player_Spawn_Position, Quaternion.identity);
        }
        else if (i == 1)
        {
            PhotonNetwork.Instantiate(Path.Combine("BridgePrefabs", "FarmerManPlayer_Bridge"), Player_Spawn_Position, Quaternion.identity);
        }
        else if (i == 2)
        {
            PhotonNetwork.Instantiate(Path.Combine("BridgePrefabs", "FarmerWomanPlayer_Bridge"), Player_Spawn_Position, Quaternion.identity);
        }
        else if (i == 3)
        {
            PhotonNetwork.Instantiate(Path.Combine("BridgePrefabs", "GrilPlayer_Bridge"), Player_Spawn_Position, Quaternion.identity);
        }
    }
}
