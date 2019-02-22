using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VcamSceneLoad2 : MonoBehaviour
{
    Cinemachine.CinemachineVirtualCamera vcam;

    // Start is called before the first frame update
    void Start()
    {
        vcam = GameObject.Find("Camera").transform.GetChild(2).GetComponent<Cinemachine.CinemachineVirtualCamera>();
        vcam.Follow = GameObject.Find("Background").transform.GetChild(4);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 10000; i++)
            Debug.Log("잠시 후에");

        //        Destroy(vcam);

        vcam.Priority = 11; // 우선순위 바뀜

        Debug.Log("vcam 파괴");

    }
}
