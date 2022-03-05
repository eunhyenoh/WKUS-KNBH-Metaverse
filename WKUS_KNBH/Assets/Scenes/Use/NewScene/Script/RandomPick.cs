using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPick : MonoBehaviour
{
    public int random;

    public static RandomPick Instance;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        random = Random.Range(0, 3);    //0~3까지 랜덤 캐릭터 변수 추출 
        Debug.Log("랜덤 값:" + random);
    }
}
