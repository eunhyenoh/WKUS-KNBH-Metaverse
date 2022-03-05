using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public GameObject ThePlayer;
    public float PlaceX;
    public float PlaceZ;

    void Start()
    {
        PlaceX = Random.Range(-10, -5);
        PlaceZ = Random.Range(-10, -5);
        ThePlayer.transform.position = new Vector3(PlaceX, 1, PlaceZ);
    }


}
