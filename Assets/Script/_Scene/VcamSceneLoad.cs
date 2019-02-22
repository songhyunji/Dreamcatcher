using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VcamSceneLoad : MonoBehaviour {

    Cinemachine.CinemachineVirtualCamera vcam;

//    string currentMap; // 현재 맵 이름

	void Start () {
        vcam = GameObject.Find("Camera").transform.GetChild(1).GetComponent<Cinemachine.CinemachineVirtualCamera>();
        vcam.Follow = GameObject.Find("TestPlayer(Clone)").transform;
    }

    void Update()
    {
        
    }
}
