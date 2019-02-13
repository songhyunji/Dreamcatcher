using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Cinemachine;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class Player_subslope : MonoBehaviour {

	public GameObject testCollider;

    public bool isLeft;
	public bool isJumping = false;
	public bool isGround = false;
	public bool onLadder = false;
	public bool onFoothold = false;
	public bool touchedHeavyFoolhold = false;
	public bool hasKey = false;
	public bool isDie = false;
	public float dir;
	public float jumpDir;
	public float speed;
	public float jumpspeed;
	public Vector2 startPos;			
	public Vector2 direction;

	public Animator animator;
	public Rigidbody2D rb2D;
	public Image img;
	public Text text1;
	public Text text2;
	public GameObject fade;
	public GameObject fadeText1;
	public GameObject fadeText2;
	
	private float playerposX;
    private float playerposY;
    private string loadSceneName = "";
	private ContactPoint2D[] contactPoint = new ContactPoint2D[16];

	private AudioSource _audioSource;
	public AudioClip[] _audio = new AudioClip[5];
	private AudioClip _audioClip;
	private float targetTime = 0;

	void Awake () 
	{
		DontDestroyOnLoad(this);
		
		if (FindObjectsOfType(GetType()).Length > 1)
		{
			Destroy(gameObject);
		}
	}

	void Start() {
		
        animator = GetComponent<Animator>();
		rb2D = GetComponent<Rigidbody2D>();
		_audioSource = GetComponent<AudioSource>();
	}

	void FixedUpdate()
	{
		if (onLadder)
		{
			animator.SetBool("isOnLadder", true);
			Climb();
		}
		else
		{
			Walk();
		}
		
		if (isGround)
		{
			animator.SetBool(("isJumping"), false);
			animator.SetBool("isOnLadder", false);
			animator.SetBool("isClimbing", false);
		}

		if (isDie)
		{
			targetTime += Time.deltaTime;

			if (Input.touchCount > 0 || targetTime>=5) // 자동 재시작 시간 현재 5초
			{
				transform.position = new Vector3(playerposX, playerposY);
				SceneManager.LoadScene(loadSceneName);

			}
		}
	}
	
	private void OnCollisionEnter2D(Collision2D other)
     {
        if(other.collider.CompareTag("DeathGround"))
        {
			Debug.Log("die");
            Die();
        }
     }

	public void Walk()
	{
		if (Input.touchCount > 0)
		{
			Touch touch = Input.GetTouch(0);

			if (touch.position.x <= Screen.width / 2)
			{
				if (touch.phase == TouchPhase.Began)
				{
					startPos = touch.position;
				}
				else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
				{
					if (!_audioSource.isPlaying)
					{
						int index = Random.Range(0, _audio.Length);
						_audioClip = _audio[index];
						_audioSource.clip = _audioClip;
						_audioSource.Play();
					}
					direction = touch.position - startPos;
					if (direction.x > 0)
					{
						animator.SetBool("isWalking", true);
						transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
						dir = 1;
                        isLeft = false;

                    }
					else if (direction.x < 0)
					{
						animator.SetBool("isWalking", true);
						transform.localScale = new Vector3(-1.5f, 1.5f, 1.5f);
						dir = -1;
                        isLeft = true;
					}
						
					transform.Translate(dir * Vector3.right * speed * Time.deltaTime);
				}
				else if (touch.phase == TouchPhase.Ended)
				{
					dir = 0;
					animator.SetBool("isWalking", false);
				}
			}
			else
			{
				animator.SetBool("isWalking", false);
            }
		}
		else
		{
			animator.SetBool("isWalking", false);
        }
	}

	public void Climb()
	{
		if (Input.touchCount > 0)
		{
			Touch touch = Input.GetTouch(0);

			if (touch.position.x <= Screen.width / 2)
			{
				if (touch.phase == TouchPhase.Began)
				{
					startPos = touch.position;
				}
				else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
				{
					direction = touch.position - startPos;
					if (direction.y > 0)
					{
						animator.SetBool("isClimbing", true);
						dir = 1;
						transform.Translate(dir * Vector3.up * speed * Time.deltaTime);
					}
					else if (direction.y < 0)
					{
						animator.SetBool("isClimbing", true);
						dir = -1;
						transform.Translate(dir * Vector3.up * speed * Time.deltaTime);
					}

					if (direction.x > 0)
					{
						jumpDir = 1;
						transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
					}
					else if (direction.x < 0)
					{
						jumpDir = -1;
						transform.localScale = new Vector3(-1.5f, 1.5f, 1.5f);
					}

				}
				else if (touch.phase == TouchPhase.Ended)
				{
					dir = 0;
					jumpDir = 0;
					animator.SetBool("isClimbing", false);
				}
				
			}
			
		}
		else
		{
			dir = 0;
			jumpDir = 0;
			animator.SetBool("isClimbing", false);
		}
	}
	
	public void Jump()
	{
		if (isGround)
		{
			isJumping = true;
			animator.SetBool("isJumping", true);
			isGround = false;
			rb2D.AddForce(Vector3.up * jumpspeed , ForceMode2D.Impulse);
			isJumping = false;
		}
		else if (onLadder)
		{
			rb2D.AddForce(jumpDir * Vector2.right * speed * Time.deltaTime);
			//onLadder = false;
		}
        
	}

    public void Die()
    {
		hasKey = false;
		playerposX = PlayerPrefs.GetFloat("posX");
        playerposY = PlayerPrefs.GetFloat("posY");
        loadSceneName = PlayerPrefs.GetString("SaveStage");
		img.gameObject.SetActive(true);
		StartCoroutine(FadeImage(false));

    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
		fade = GameObject.Find("GameoverFade");
		fadeText1 = GameObject.Find("FadeText1");
		fadeText2 = GameObject.Find("FadeText2");
		img = fade.GetComponent<Image>();
		text1 = fadeText1.GetComponent<Text>();
		text2 = fadeText2.GetComponent<Text>();
		hasKey = false;
		isDie = false;
	}

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

	IEnumerator FadeImage(bool fadeAway)
	{
		if (fadeAway)
		{
			for (float i = 1; i >= 0; i -= Time.deltaTime)
			{
				img.color = new Color(1, 1, 1, i);
				yield return null;
			}

		}
		else
		{
			for (float i = 0; i <= 1; i += Time.deltaTime)
			{
				img.color = new Color(1, 0, 0, i);
				text1.color = new Color(1, 1, 1, i);
				text2.color = new Color(1, 1, 1, i);
				yield return null;
			}
			isDie = true;
			//Time.timeScale = 0;
		}
	}
}
