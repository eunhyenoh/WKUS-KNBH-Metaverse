using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class Manager_Bridge : MonoBehaviour
{
    public GameObject bridge_Pannel;
    public GameObject gameClear_Pannel;
    public GameObject gameOver_Pannel;

    
    public GameObject player;
    public PhotonView PV;

    private void Start()
    {
        //PV = GetComponent<PhotonView>();
    }
    // Update is called once per frame
    void Update()
    {
        Debug.LogWarning("현재 플레이어 위치 :" + player.transform.position.y);
        if (PV.IsMine)
        {
            if (player.transform.position.y <= -12)
            {
                bridge_Pannel.SetActive(true);

                if (player.transform.position.y >= -12)
                {
                    gameOver_Pannel.SetActive(false);
                }
                else
                {
                    gameOver_Pannel.SetActive(true);
                }
            }
        }
    }

    //돌아가기 버튼 함수 
    public void Back_Btn()
    {
        SceneManager.LoadScene(7);
        NewLauncher.Instance.player_Disconnect();
    }
}
