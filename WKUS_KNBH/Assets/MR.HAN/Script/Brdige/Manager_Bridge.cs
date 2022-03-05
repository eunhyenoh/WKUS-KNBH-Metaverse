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
        Debug.LogWarning("���� �÷��̾� ��ġ :" + player.transform.position.y);
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

    //���ư��� ��ư �Լ� 
    public void Back_Btn()
    {
        SceneManager.LoadScene(7);
        NewLauncher.Instance.player_Disconnect();
    }
}
