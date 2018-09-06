using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OntheDeadTrap : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Trap") // player가 trap에 닿았을 때
                                            //if(other.isTrigger == true)
        {
            Debug.Log("함정 걸림"); // -> 사망처리 이벤트  
            Destroy(other.gameObject); // 충돌 일어난 오브젝트 파괴

            SceneManager.LoadScene("AfterDead"); // 사망씬으로 이동
        }

    }
}
