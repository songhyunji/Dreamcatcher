﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class LoadScene_drop : MonoBehaviour {

    public string sceneName;
    public int sceneNum;
    public GameObject player;
    public Player_subslope playerScript;

    private Vector3 playerPos;

    void Start()
    {
        player = GameObject.Find("TestPlayer(Clone)");
        playerScript = GameObject.Find("TestPlayer(Clone)").GetComponent<Player_subslope>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
			player.transform.position = new Vector2(120, 9);
            //Debug.Log("Touch Load Scene Collider");
            SceneManager.LoadScene(sceneName + sceneNum);

            PlayerPrefs.SetFloat("posX", player.transform.position.x);
            PlayerPrefs.SetFloat("posY", player.transform.position.y);
            PlayerPrefs.SetString("SaveStage", sceneName + sceneNum);
            //Debug.Log("저장");

            //Debug.Log("posX");
            //Debug.Log(PlayerPrefs.GetFloat("posX"));
            //Debug.Log("posY");
            //Debug.Log(PlayerPrefs.GetFloat("posY"));
            //Debug.Log("Scene Name");
            //Debug.Log(PlayerPrefs.GetString("SaveStage"));


        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerScript.SearchObject();
        }
    }
}