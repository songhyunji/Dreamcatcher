using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rune : MonoBehaviour
{
    public GameObject player;
    public GameObject lightParticle;

    public bool isTouch = false;

    public Sprite Runeoff, Runeon; // 룬 꺼짐, 룬 켜짐
    public SpriteRenderer Runeimg;
    public bool RuneSwitch = true;

	public string saveName;

	private AudioSource _audioSource;
	private GameObject bgm;
	private AudioSource bgmAudioSource;

	// 만약 플레이어가 룬의 위치와 같을 때
	// 플레이어가 인터랙트 버튼을 누르면 룬 불빛이 켜짐 -> 꺼짐
	// 켜져 있을 때에는 주변으로 빛이 나온당 (이펙트)
	// 꺼지면 빛도 꺼진당

	// Start is called before the first frame update
	void Start()
    {
		_audioSource = GetComponent<AudioSource>();
		bgm = GameObject.Find("BackgroundSound");
		bgmAudioSource = bgm.GetComponent<AudioSource>();

		player = GameObject.Find("TestPlayer");
		// 전 스테이지에서 넘어오는 플레이어 오브젝트 찾기

		if (PlayerPrefs.HasKey(saveName))
		{
			LoadData();
		}
	}

    // Update is called once per frame
    void Update()
    {

    }

    // 인터랙션 버튼을 누르면
    public void PressInteractBtn()
    {
        if (isTouch == true)
        {
            Debug.Log("인터랙션 버튼 누름");

            if (RuneSwitch) // 룬이 켜져 있음
            {
				_audioSource.Play();
				for (float i = 0; i <= 1; i += 0.001f)
				{
					bgmAudioSource.volume = i;
				}
				Runeimg.sprite = Runeoff;
                RuneSwitch = false;
                Debug.Log("룬 꺼짐");
				SaveData();
				// 포인트 라이트도 끄기 lightParticle.SetActive(false); → Destroy(lightParticle); , 코드 위치 이동
			}
            else // 룬이 꺼져 있음 -> 룬이 다시 켜지지 않음
            {
                //Runeimg.sprite = Runeon;
                //RuneSwitch = true;
                //Debug.Log("룬 켜짐");
            }

        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        // 룬이 플레이어와 닿았을 때
        if (other.CompareTag("Player"))
        {
            Debug.Log("룬과 충돌");

            isTouch = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        // 룬이 플레이어와 닿았을 때
        if (other.CompareTag("Player"))
        {
            Debug.Log("룬과 충돌 안 함");

            isTouch = false;
        }
    }

	public void SaveData()
	{
		Destroy(lightParticle);

		PlayerPrefs.SetString(saveName, "destroy");
	}

	public void LoadData()
	{
		var data = PlayerPrefs.GetString(saveName);

		if(data == "destroy")
		{
			Destroy(lightParticle);
		}
	}

}