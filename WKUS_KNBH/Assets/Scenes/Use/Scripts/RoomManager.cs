using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using System.IO;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public static RoomManager Instance ;

    void Awake()
        {
            if (Instance)  
            {
                Destroy(gameObject);
                return;
            }
     
        DontDestroyOnLoad(gameObject);  //씬이 바뀌어도 해당 게임오브젝트는 파괴하지 않고 남았이다.  데이터를 넘어가게 하는 것이다. (정보를 넘어가게 하는 것이다.) 

        Instance = this;
    }
 


  
    public override void OnEnable()
    {
        base.OnEnable();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public override void OnDisable()
    {
        base.OnDisable();
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
    
        if (scene.buildIndex == 2)
        {
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerManager"), Vector3.zero, Quaternion.identity);
            Destroy(gameObject);
        }
        if (scene.buildIndex == 3)
        {
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerManager"), Vector3.zero, Quaternion.identity);
            Destroy(gameObject);
        }
        if (scene.buildIndex == 4)
        {
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerManager"), Vector3.zero, Quaternion.identity);
            Destroy(gameObject);
        }
        if (scene.buildIndex == 5)
        {
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerManager"), Vector3.zero, Quaternion.identity);
            Destroy(gameObject);
        }
        if (scene.buildIndex == 6)
        {
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerManager"), Vector3.zero, Quaternion.identity);
            Destroy(gameObject);
        }
        if (scene.buildIndex == 9)
        {
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerManager"), Vector3.zero, Quaternion.identity);
            Destroy(gameObject);
        }

    }
    
}
