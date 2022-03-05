using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    public GameObject sunLight;
    public GameObject lampLight;
    public GameObject lampLight2;
    public GameObject lampLight3;
    public GameObject lampLight4;
    public GameObject lampLight5;
    public GameObject lampLight6;
    public GameObject lampLight7;
    public GameObject lampLight8;
    public GameObject lampLight9;
    public GameObject lampLight10;
    public GameObject lampLight11;
    public GameObject lampLight12;
    public GameObject lampLight13;
    public GameObject lampLight14;
    public GameObject lampLight15;
    public GameObject lampLight16;
    public GameObject lampLight17;
    public GameObject lampLight18;
    public GameObject lampLight19;
    public GameObject lampLight20;
    public GameObject lampLight21;
    public GameObject lampLight22;
    public GameObject lampLight23;
    public GameObject lampLight24;
    public GameObject lampLight25, lampLight26, lampLight27, lampLight28, lampLight29, lampLight30, lampLight31, lampLight32, lampLight33, lampLight34, lampLight35, lampLight36, lampLight37,
        lampLight38, lampLight39, lampLight40, lampLight41, lampLight42, lampLight43, lampLight44, lampLight45, lampLight46, lampLight47, lampLight48, lampLight49,lampLight50, lampLight51, lampLight52, lampLight53, lampLight54, lampLight55
        , lampLight56, lampLight57, lampLight58, lampLight59, lampLight60, lampLight61, lampLight62, lampLight63, lampLight64, lampLight65, lampLight66, lampLight67, lampLight68, lampLight69, lampLight70, lampLight71, lampLight72,
        lampLight73, lampLight74, lampLight75, lampLight76, lampLight77, lampLight78, lampLight79, lampLight80, lampLight81, lampLight82, lampLight83, lampLight84, lampLight85, lampLight86, lampLight87, lampLight88, lampLight89, lampLight90,
        lampLight91, lampLight92, lampLight93, lampLight94, lampLight95, lampLight96, lampLight97, lampLight98, lampLight99, lampLight100, lampLight101, lampLight102, lampLight103, lampLight104, lampLight105, lampLight106, lampLight107, lampLight108, lampLight109, lampLight110,
        lampLight111, lampLight112, lampLight113, lampLight114, lampLight115, lampLight116, lampLight117, lampLight118, lampLight119, lampLight120, lampLight121, lampLight122, lampLight123, lampLight124, lampLight125, lampLight126, lampLight127, lampLight128, lampLight129,
        lampLight130, lampLight131, lampLight132, lampLight133, lampLight134, lampLight135, lampLight136, lampLight137,
        lampLight138, lampLight139, lampLight140, lampLight141, lampLight142, lampLight143, lampLight144, lampLight145, lampLight146, lampLight147, lampLight148, lampLight149, lampLight150, lampLight151, lampLight152, lampLight153, lampLight154, lampLight155
        , lampLight156, lampLight157, lampLight158, lampLight159, lampLight160, lampLight161, lampLight162, lampLight163, lampLight164, lampLight165, lampLight166, lampLight167, lampLight168, lampLight169, lampLight170, lampLight171, lampLight172,
        lampLight173, lampLight174, lampLight175, lampLight176, lampLight177, lampLight178, lampLight179, lampLight180, lampLight181, lampLight182;
    /*   private void Start()
       {
         //  GameObject obj = GameObject.FindWithTag("PointLight");
           lampLight = GameObject.FindWithTag("PointLight");
           Debug.Log("오브젝트를 찾았습니다");
       }*/

    void Update()
    {
        Debug.Log(sunLight.GetComponent<Transform>().rotation.eulerAngles.x);
        if (sunLight.GetComponent<Transform>().rotation.eulerAngles.x > 250)
        {
            lampLight.GetComponent<Light>().enabled = true;
            lampLight2.GetComponent<Light>().enabled = true;
            lampLight3.GetComponent<Light>().enabled = true;
            lampLight4.GetComponent<Light>().enabled = true;
            lampLight5.GetComponent<Light>().enabled = true;
            lampLight6.GetComponent<Light>().enabled = true;
            lampLight7.GetComponent<Light>().enabled = true;
            lampLight8.GetComponent<Light>().enabled = true;
            lampLight9.GetComponent<Light>().enabled = true;
            lampLight10.GetComponent<Light>().enabled = true;
            lampLight11.GetComponent<Light>().enabled = true;
            lampLight12.GetComponent<Light>().enabled = true;
            lampLight13.GetComponent<Light>().enabled = true;
            lampLight14.GetComponent<Light>().enabled = true;
            lampLight15.GetComponent<Light>().enabled = true;
            lampLight16.GetComponent<Light>().enabled = true;
            lampLight17.GetComponent<Light>().enabled = true;
            lampLight18.GetComponent<Light>().enabled = true;
            lampLight19.GetComponent<Light>().enabled = true;
            lampLight20.GetComponent<Light>().enabled = true;
            lampLight21.GetComponent<Light>().enabled = true;
            lampLight22.GetComponent<Light>().enabled = true;
            lampLight23.GetComponent<Light>().enabled = true;
            lampLight24.GetComponent<Light>().enabled = true;
            lampLight25.GetComponent<Light>().enabled = true;
            lampLight26.GetComponent<Light>().enabled = true;
            lampLight27.GetComponent<Light>().enabled = true;
            lampLight28.GetComponent<Light>().enabled = true;
            lampLight29.GetComponent<Light>().enabled = true;
            lampLight30.GetComponent<Light>().enabled = true;
            lampLight31.GetComponent<Light>().enabled = true;
            lampLight32.GetComponent<Light>().enabled = true;
            lampLight33.GetComponent<Light>().enabled = true;
            lampLight34.GetComponent<Light>().enabled = true;
            lampLight35.GetComponent<Light>().enabled = true;
            lampLight36.GetComponent<Light>().enabled = true;
            lampLight37.GetComponent<Light>().enabled = true;
            lampLight38.GetComponent<Light>().enabled = true;
            lampLight39.GetComponent<Light>().enabled = true;
            lampLight40.GetComponent<Light>().enabled = true;
            lampLight41.GetComponent<Light>().enabled = true;
            lampLight42.GetComponent<Light>().enabled = true;
            lampLight43.GetComponent<Light>().enabled = true;
            lampLight44.GetComponent<Light>().enabled = true;
            lampLight45.GetComponent<Light>().enabled = true;
            lampLight46.GetComponent<Light>().enabled = true; lampLight47.GetComponent<Light>().enabled = true;
            lampLight48.GetComponent<Light>().enabled = true; lampLight49.GetComponent<Light>().enabled = true; lampLight50.GetComponent<Light>().enabled = true;
            lampLight51.GetComponent<Light>().enabled = true; lampLight52.GetComponent<Light>().enabled = true; lampLight53.GetComponent<Light>().enabled = true;
            lampLight54.GetComponent<Light>().enabled = true; lampLight55.GetComponent<Light>().enabled = true; lampLight56.GetComponent<Light>().enabled = true;
            lampLight57.GetComponent<Light>().enabled = true; lampLight58.GetComponent<Light>().enabled = true; lampLight59.GetComponent<Light>().enabled = true; lampLight60.GetComponent<Light>().enabled = true; lampLight61.GetComponent<Light>().enabled = true;
            lampLight62.GetComponent<Light>().enabled = true; lampLight63.GetComponent<Light>().enabled = true; lampLight64.GetComponent<Light>().enabled = true; lampLight65.GetComponent<Light>().enabled = true; lampLight66.GetComponent<Light>().enabled = true;
            lampLight67.GetComponent<Light>().enabled = true; lampLight69.GetComponent<Light>().enabled = true; lampLight70.GetComponent<Light>().enabled = true; lampLight71.GetComponent<Light>().enabled = true; lampLight72.GetComponent<Light>().enabled = true;
            lampLight73.GetComponent<Light>().enabled = true; lampLight74.GetComponent<Light>().enabled = true; lampLight75.GetComponent<Light>().enabled = true; lampLight76.GetComponent<Light>().enabled = true; lampLight77.GetComponent<Light>().enabled = true;
            lampLight78.GetComponent<Light>().enabled = true; lampLight79.GetComponent<Light>().enabled = true; lampLight80.GetComponent<Light>().enabled = true; lampLight81.GetComponent<Light>().enabled = true; lampLight82.GetComponent<Light>().enabled = true;
            lampLight83.GetComponent<Light>().enabled = true; lampLight84.GetComponent<Light>().enabled = true; lampLight85.GetComponent<Light>().enabled = true; lampLight86.GetComponent<Light>().enabled = true; lampLight87.GetComponent<Light>().enabled = true;
            lampLight88.GetComponent<Light>().enabled = true; lampLight89.GetComponent<Light>().enabled = true; lampLight90.GetComponent<Light>().enabled = true; lampLight91.GetComponent<Light>().enabled = true; lampLight92.GetComponent<Light>().enabled = true;
            lampLight93.GetComponent<Light>().enabled = true; lampLight94.GetComponent<Light>().enabled = true; lampLight95.GetComponent<Light>().enabled = true; lampLight96.GetComponent<Light>().enabled = true; lampLight97.GetComponent<Light>().enabled = true;
            lampLight98.GetComponent<Light>().enabled = true; lampLight99.GetComponent<Light>().enabled = true; lampLight100.GetComponent<Light>().enabled = true; lampLight101.GetComponent<Light>().enabled = true; lampLight102.GetComponent<Light>().enabled = true;
            lampLight103.GetComponent<Light>().enabled = true; lampLight104.GetComponent<Light>().enabled = true; lampLight105.GetComponent<Light>().enabled = true; lampLight106.GetComponent<Light>().enabled = true; lampLight107.GetComponent<Light>().enabled = true; lampLight108.GetComponent<Light>().enabled = true;
            lampLight109.GetComponent<Light>().enabled = true; lampLight110.GetComponent<Light>().enabled = true; lampLight111.GetComponent<Light>().enabled = true; lampLight112.GetComponent<Light>().enabled = true; lampLight113.GetComponent<Light>().enabled = true; lampLight114.GetComponent<Light>().enabled = true;
            lampLight115.GetComponent<Light>().enabled = true; lampLight116.GetComponent<Light>().enabled = true; lampLight117.GetComponent<Light>().enabled = true; lampLight118.GetComponent<Light>().enabled = true; lampLight119.GetComponent<Light>().enabled = true; lampLight120.GetComponent<Light>().enabled = true;
            lampLight121.GetComponent<Light>().enabled = true; lampLight122.GetComponent<Light>().enabled = true; lampLight123.GetComponent<Light>().enabled = true; lampLight124.GetComponent<Light>().enabled = true; lampLight125.GetComponent<Light>().enabled = true; lampLight126.GetComponent<Light>().enabled = true;
            lampLight127.GetComponent<Light>().enabled = true; lampLight128.GetComponent<Light>().enabled = true; lampLight129.GetComponent<Light>().enabled = true; lampLight130.GetComponent<Light>().enabled = true; lampLight131.GetComponent<Light>().enabled = true; lampLight132.GetComponent<Light>().enabled = true;
            lampLight133.GetComponent<Light>().enabled = true; lampLight134.GetComponent<Light>().enabled = true; lampLight135.GetComponent<Light>().enabled = true; lampLight136.GetComponent<Light>().enabled = true; lampLight137.GetComponent<Light>().enabled = true; lampLight138.GetComponent<Light>().enabled = true;
            lampLight139.GetComponent<Light>().enabled = true; lampLight140.GetComponent<Light>().enabled = true; lampLight141.GetComponent<Light>().enabled = true; lampLight142.GetComponent<Light>().enabled = true; lampLight143.GetComponent<Light>().enabled = true; lampLight144.GetComponent<Light>().enabled = true;
            lampLight145.GetComponent<Light>().enabled = true; lampLight146.GetComponent<Light>().enabled = true; lampLight147.GetComponent<Light>().enabled = true; lampLight148.GetComponent<Light>().enabled = true; lampLight149.GetComponent<Light>().enabled = true; lampLight150.GetComponent<Light>().enabled = true;
            lampLight151.GetComponent<Light>().enabled = true; lampLight152.GetComponent<Light>().enabled = true; lampLight153.GetComponent<Light>().enabled = true; lampLight154.GetComponent<Light>().enabled = true; lampLight155.GetComponent<Light>().enabled = true; lampLight156.GetComponent<Light>().enabled = true;
            lampLight157.GetComponent<Light>().enabled = true; lampLight158.GetComponent<Light>().enabled = true; lampLight159.GetComponent<Light>().enabled = true; lampLight160.GetComponent<Light>().enabled = true; lampLight161.GetComponent<Light>().enabled = true; lampLight162.GetComponent<Light>().enabled = true;
            lampLight163.GetComponent<Light>().enabled = true; lampLight164.GetComponent<Light>().enabled = true; lampLight165.GetComponent<Light>().enabled = true; lampLight166.GetComponent<Light>().enabled = true; lampLight167.GetComponent<Light>().enabled = true; lampLight168.GetComponent<Light>().enabled = true;
            lampLight169.GetComponent<Light>().enabled = true; lampLight170.GetComponent<Light>().enabled = true; lampLight171.GetComponent<Light>().enabled = true; lampLight172.GetComponent<Light>().enabled = true; lampLight173.GetComponent<Light>().enabled = true; lampLight174.GetComponent<Light>().enabled = true;
            lampLight175.GetComponent<Light>().enabled = true; lampLight176.GetComponent<Light>().enabled = true; lampLight177.GetComponent<Light>().enabled = true; lampLight178.GetComponent<Light>().enabled = true; lampLight179.GetComponent<Light>().enabled = true; lampLight180.GetComponent<Light>().enabled = true;
            lampLight181.GetComponent<Light>().enabled = true; lampLight182.GetComponent<Light>().enabled = true; 
        }

        else
        {
            lampLight.GetComponent<Light>().enabled = false;
            lampLight2.GetComponent<Light>().enabled = false;
            lampLight3.GetComponent<Light>().enabled = false;
            lampLight4.GetComponent<Light>().enabled = false;
            lampLight5.GetComponent<Light>().enabled = false;
            lampLight6.GetComponent<Light>().enabled = false;
            lampLight7.GetComponent<Light>().enabled = false;
            lampLight8.GetComponent<Light>().enabled = false;
            lampLight9.GetComponent<Light>().enabled = false;
            lampLight10.GetComponent<Light>().enabled = false;
            lampLight11.GetComponent<Light>().enabled = false;
            lampLight12.GetComponent<Light>().enabled = false;
            lampLight13.GetComponent<Light>().enabled = false;
            lampLight14.GetComponent<Light>().enabled = false;
            lampLight15.GetComponent<Light>().enabled = false;
            lampLight16.GetComponent<Light>().enabled = false;
            lampLight17.GetComponent<Light>().enabled = false;
            lampLight18.GetComponent<Light>().enabled = false;
            lampLight19.GetComponent<Light>().enabled = false;
            lampLight20.GetComponent<Light>().enabled = false;
            lampLight21.GetComponent<Light>().enabled = false;
            lampLight22.GetComponent<Light>().enabled = false;
            lampLight23.GetComponent<Light>().enabled = false;
            lampLight24.GetComponent<Light>().enabled = false;
            lampLight25.GetComponent<Light>().enabled = false;
            lampLight26.GetComponent<Light>().enabled = false;
            lampLight27.GetComponent<Light>().enabled = false;
            lampLight28.GetComponent<Light>().enabled = false;
            lampLight29.GetComponent<Light>().enabled = false;
            lampLight30.GetComponent<Light>().enabled = false;
            lampLight31.GetComponent<Light>().enabled = false;
            lampLight32.GetComponent<Light>().enabled = false;
            lampLight33.GetComponent<Light>().enabled = false;
            lampLight34.GetComponent<Light>().enabled = false;
            lampLight35.GetComponent<Light>().enabled = false;
            lampLight36.GetComponent<Light>().enabled = false;
            lampLight37.GetComponent<Light>().enabled = false;
            lampLight38.GetComponent<Light>().enabled = false;
            lampLight39.GetComponent<Light>().enabled = false;
            lampLight40.GetComponent<Light>().enabled = false;
            lampLight41.GetComponent<Light>().enabled = false;
            lampLight42.GetComponent<Light>().enabled = false;
            lampLight43.GetComponent<Light>().enabled = false;
            lampLight44.GetComponent<Light>().enabled = false;
            lampLight45.GetComponent<Light>().enabled = false;
            lampLight46.GetComponent<Light>().enabled = false; lampLight47.GetComponent<Light>().enabled = false;
            lampLight48.GetComponent<Light>().enabled = false; lampLight49.GetComponent<Light>().enabled = false; lampLight50.GetComponent<Light>().enabled = false;
            lampLight51.GetComponent<Light>().enabled = false; lampLight52.GetComponent<Light>().enabled = false; lampLight53.GetComponent<Light>().enabled = false;
            lampLight54.GetComponent<Light>().enabled = false; lampLight55.GetComponent<Light>().enabled = false; lampLight56.GetComponent<Light>().enabled = false;
            lampLight57.GetComponent<Light>().enabled = false; lampLight58.GetComponent<Light>().enabled = false; lampLight59.GetComponent<Light>().enabled = false; lampLight60.GetComponent<Light>().enabled = false; lampLight61.GetComponent<Light>().enabled = false;
            lampLight62.GetComponent<Light>().enabled = false; lampLight63.GetComponent<Light>().enabled = false; lampLight64.GetComponent<Light>().enabled = false; lampLight65.GetComponent<Light>().enabled = false; lampLight66.GetComponent<Light>().enabled = false;
            lampLight67.GetComponent<Light>().enabled = false; lampLight69.GetComponent<Light>().enabled = false; lampLight70.GetComponent<Light>().enabled = false; lampLight71.GetComponent<Light>().enabled = false; lampLight72.GetComponent<Light>().enabled = false;
            lampLight78.GetComponent<Light>().enabled = false; lampLight79.GetComponent<Light>().enabled = false; lampLight80.GetComponent<Light>().enabled = false; lampLight81.GetComponent<Light>().enabled = false; lampLight82.GetComponent<Light>().enabled = false;
            lampLight83.GetComponent<Light>().enabled = false; lampLight84.GetComponent<Light>().enabled = false; lampLight85.GetComponent<Light>().enabled = false; lampLight86.GetComponent<Light>().enabled = false; lampLight87.GetComponent<Light>().enabled = false;
            lampLight88.GetComponent<Light>().enabled = false; lampLight89.GetComponent<Light>().enabled = false; lampLight90.GetComponent<Light>().enabled = false; lampLight91.GetComponent<Light>().enabled = false; lampLight92.GetComponent<Light>().enabled = false;
            lampLight93.GetComponent<Light>().enabled = false; lampLight94.GetComponent<Light>().enabled = false; lampLight95.GetComponent<Light>().enabled = false; lampLight96.GetComponent<Light>().enabled = false; lampLight97.GetComponent<Light>().enabled = false;
            lampLight98.GetComponent<Light>().enabled = false; lampLight99.GetComponent<Light>().enabled = false; lampLight100.GetComponent<Light>().enabled = false; lampLight101.GetComponent<Light>().enabled = false; lampLight102.GetComponent<Light>().enabled = false;
            lampLight103.GetComponent<Light>().enabled = false; lampLight104.GetComponent<Light>().enabled = false; lampLight105.GetComponent<Light>().enabled = false; lampLight106.GetComponent<Light>().enabled = false; lampLight107.GetComponent<Light>().enabled = false; lampLight108.GetComponent<Light>().enabled = false;
            lampLight109.GetComponent<Light>().enabled = false; lampLight110.GetComponent<Light>().enabled = false; lampLight111.GetComponent<Light>().enabled = false; lampLight112.GetComponent<Light>().enabled = false; lampLight113.GetComponent<Light>().enabled = false; lampLight114.GetComponent<Light>().enabled = false;
            lampLight115.GetComponent<Light>().enabled = false; lampLight116.GetComponent<Light>().enabled = false; lampLight117.GetComponent<Light>().enabled = false; lampLight118.GetComponent<Light>().enabled = false; lampLight119.GetComponent<Light>().enabled = false; lampLight120.GetComponent<Light>().enabled = false;
            lampLight121.GetComponent<Light>().enabled = false; lampLight122.GetComponent<Light>().enabled = false; lampLight123.GetComponent<Light>().enabled = false; lampLight124.GetComponent<Light>().enabled = false; lampLight125.GetComponent<Light>().enabled = false; lampLight126.GetComponent<Light>().enabled = false;
            lampLight127.GetComponent<Light>().enabled = false; lampLight128.GetComponent<Light>().enabled = false; lampLight129.GetComponent<Light>().enabled = false; lampLight130.GetComponent<Light>().enabled = false; lampLight131.GetComponent<Light>().enabled = false; lampLight132.GetComponent<Light>().enabled = false;
            lampLight133.GetComponent<Light>().enabled = false; lampLight134.GetComponent<Light>().enabled = false; lampLight135.GetComponent<Light>().enabled = false; lampLight136.GetComponent<Light>().enabled = false; lampLight137.GetComponent<Light>().enabled = false; lampLight138.GetComponent<Light>().enabled = false;
            lampLight139.GetComponent<Light>().enabled = false; lampLight140.GetComponent<Light>().enabled = false; lampLight141.GetComponent<Light>().enabled = false; lampLight142.GetComponent<Light>().enabled = false; lampLight143.GetComponent<Light>().enabled = false; lampLight144.GetComponent<Light>().enabled = false;
            lampLight145.GetComponent<Light>().enabled = false; lampLight146.GetComponent<Light>().enabled = false; lampLight147.GetComponent<Light>().enabled = false; lampLight148.GetComponent<Light>().enabled = false; lampLight149.GetComponent<Light>().enabled = false; lampLight150.GetComponent<Light>().enabled = false;
            lampLight151.GetComponent<Light>().enabled = false; lampLight152.GetComponent<Light>().enabled = false; lampLight153.GetComponent<Light>().enabled = false; lampLight154.GetComponent<Light>().enabled = false; lampLight155.GetComponent<Light>().enabled = false; lampLight156.GetComponent<Light>().enabled = false;
            lampLight157.GetComponent<Light>().enabled = false; lampLight158.GetComponent<Light>().enabled = false; lampLight159.GetComponent<Light>().enabled = false; lampLight160.GetComponent<Light>().enabled = false; lampLight161.GetComponent<Light>().enabled = false; lampLight162.GetComponent<Light>().enabled = false;
            lampLight163.GetComponent<Light>().enabled = false; lampLight164.GetComponent<Light>().enabled = false; lampLight165.GetComponent<Light>().enabled = false; lampLight166.GetComponent<Light>().enabled = false; lampLight167.GetComponent<Light>().enabled = false; lampLight168.GetComponent<Light>().enabled = false;
            lampLight169.GetComponent<Light>().enabled = false; lampLight170.GetComponent<Light>().enabled = false; lampLight171.GetComponent<Light>().enabled = false; lampLight172.GetComponent<Light>().enabled = false; lampLight173.GetComponent<Light>().enabled = false; lampLight174.GetComponent<Light>().enabled = false;
            lampLight175.GetComponent<Light>().enabled = false; lampLight176.GetComponent<Light>().enabled = false; lampLight177.GetComponent<Light>().enabled = false; lampLight178.GetComponent<Light>().enabled = false; lampLight179.GetComponent<Light>().enabled = false; lampLight180.GetComponent<Light>().enabled = false;
            lampLight181.GetComponent<Light>().enabled = false; lampLight182.GetComponent<Light>().enabled = false;
        }
    }
}
