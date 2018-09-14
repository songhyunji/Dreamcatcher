using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class LoadScene : MonoBehaviour {

    public string sceneName;
    public int sceneNum;
    public CinemachineVirtualCamera vcam;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Touch Load Scene Collider");
            SceneManager.LoadScene(sceneName + sceneNum);
        }
    }
}
