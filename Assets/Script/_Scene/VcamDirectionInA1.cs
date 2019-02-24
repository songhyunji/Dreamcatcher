using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VcamDirectionInA1 : MonoBehaviour
{
    Cinemachine.CinemachineVirtualCamera vcam;
    public bool ColliderwithEntrance; // 문에 닿으면 연출 수행 : 문에 충돌했는지 얻어옴
    public bool FirstPerformance = true; // 연출을 수행했는지

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
        //StartCoroutine(WaitForSeconds()); // 2초 동안 기다림
        //        Destroy(vcam);

        //vcam.Priority = 11; // 우선순위 바뀜

        //Destroy(this.gameObject);
        //Debug.Log("vcam 파괴");

        if (FirstPerformance)
            if (ColliderwithEntrance)
            {
                vcam = GameObject.Find("Camera").transform.GetChild(1).GetComponent<Cinemachine.CinemachineVirtualCamera>();
				target = GameObject.Find("Background").transform.GetChild(4).transform;

				if (subCamera.transform.position == target.position) // 서브 카메라와 타겟의 위치가 같다면 타겟을 비춤
				{
					mainCamrea.SetActive(true);
					subCamera.SetActive(false);

					vcam.Follow = GameObject.Find("Background").transform.GetChild(4);
					//            vcam.LookAt = GameObject.Find("Background").transform.GetChild(4);

					Debug.Log(GameObject.Find("Background").transform.GetChild(4).name);
					StartCoroutine(WaitForSeconds()); // 5초 동안 기다림

					//                vcam.Follow = GameObject.Find("TestPlayer(Clone)").transform;
					//                Debug.Log("follow 오브젝트 전환");

					//                ColliderwithEntrance = false;
					FirstPerformance = false;
				}
				else // 서브 카메라와 타겟의 위치가 다르다면 서브 카메라가 타겟의 위치로 이동 (메인 카메라 끄고, 서브 카메라로 이동)
				{
					mainCamrea.SetActive(false); 
					subCamera.SetActive(true);

					subCamera.transform.position = Vector3.MoveTowards(subCamera.transform.position, target.position, speed); // https://docs.unity3d.com/kr/530/ScriptReference/Vector3.MoveTowards.html 참고
				}
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
}
