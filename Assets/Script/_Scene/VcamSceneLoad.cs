using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VcamSceneLoad : MonoBehaviour {

    Cinemachine.CinemachineVirtualCamera vcam;

	void Start () {
        vcam = GameObject.Find("Camera").transform.GetChild(1).GetComponent<Cinemachine.CinemachineVirtualCamera>();
        vcam.Follow = GameObject.Find("TestPlayer(Clone)").transform;
    }
}
