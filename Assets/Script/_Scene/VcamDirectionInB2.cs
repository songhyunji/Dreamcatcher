using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VcamDirectionInB2 : MonoBehaviour
{
    Cinemachine.CinemachineVirtualCamera vcam;
    public bool FirstPerformance = true; // 연출을 수행했는지 -> 수행 전 true 수행 후 false

    public Transform target;
    public float speed = 5;
    public GameObject mainCamrea;
    public GameObject subCamera;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (FirstPerformance)
        {
            vcam = GameObject.Find("Camera").transform.GetChild(1).GetComponent<Cinemachine.CinemachineVirtualCamera>();
            target = GameObject.Find("wolf").transform;

            if (subCamera.transform.position == target.position) // 서브 카메라와 타겟의 위치가 같다면
            {
                mainCamrea.SetActive(true); // 메인 카메라 액티브
                subCamera.SetActive(false); // 서브 카메라 비활성화

                StartCoroutine(WaitForSeconds2());
//                StartCoroutine(WaitForSeconds()); // 3초 동안 기다림
                                                  //                vcam.Follow = GameObject.Find("wolf").transform;
            }
            //            vcam.LookAt = GameObject.Find("Background").transform.GetChild(4);


            //                vcam.Follow = GameObject.Find("TestPlayer(Clone)").transform;
            //                Debug.Log("follow 오브젝트 전환");

            //                ColliderwithEntrance = false;
            FirstPerformance = false;


        } else
        {
            mainCamrea.SetActive(false);
            subCamera.SetActive(true);

            subCamera.transform.position = Vector3.MoveTowards(subCamera.transform.position, target.position, speed);
        }
    }

    IEnumerator WaitForSeconds()
    {
        Debug.Log("기다림");

        yield return new WaitForSeconds(3); // https://docs.unity3d.com/ScriptReference/WaitForSeconds.html 참고 (해당 라인 밑으로 2초 후에 실행)

        Debug.Log("흠냐,..");

        vcam.Follow = GameObject.Find("TestPlayer(Clone)").transform;

        //        vcam.Priority = 11; // 우선순위 바뀜

        //        Destroy(this.gameObject); // vcam 파괴

        //        Debug.Log("코루틴 - vcam파괴");
    }

    IEnumerator WaitForSeconds2()
    {
        Debug.Log("기다림");

        yield return new WaitForSeconds(2); // https://docs.unity3d.com/ScriptReference/WaitForSeconds.html 참고 (해당 라인 밑으로 2초 후에 실행)

        vcam.Follow = GameObject.Find("wolf").transform;
        StartCoroutine(WaitForSeconds()); // 3초 동안 기다림

        //        vcam.Priority = 11; // 우선순위 바뀜

        //        Destroy(this.gameObject); // vcam 파괴

        //        Debug.Log("코루틴 - vcam파괴");
    }

}
