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
	public bool touchedPulley = false;
	public bool touchedHeavyFoolhold = false;
	public bool isInteracting = false;
	public bool hasKey = false;
	public float dir;
	public float jumpDir;
	public float speed;
	public float jumpspeed;
	public Vector2 startPos;			
	public Vector2 direction;

	public Animator animator;
	public Rigidbody2D rb2D;
	public Image img;

	private float playerposX;
    private float playerposY;
    private string loadSceneName = "";

	private AudioSource _audioSource;
	public AudioClip[] _audio = new AudioClip[5];
	private AudioClip _audioClip;

    private List<GameObject> footholds = new List<GameObject>();

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
	}
	
	private void OnCollisionEnter2D(Collision2D other)
     {
        if(other.collider.CompareTag("DeathGround"))
        {
            RestartSceneFunc();
        }

	     /*else if (other.collider.CompareTag("pulley")) // 도르래
	     {
		     touchedPulley = true;
	     }*/
     }
	
	private void OnCollisionExit2D(Collision2D other)
	{
		/*else if (other.collider.CompareTag("pulley")) // 도르래
		{
			touchedPulley = false;
		}*/

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

    public void SearchObject()
    {
        footholds.Clear();
        Debug.Log("작동했음");
        var foothold = GameObject.FindGameObjectsWithTag("Foothold");
        foreach (var c in foothold)
        {
            footholds.Add(c);
        }
    }

    private void RestartSceneFunc()
    {
		/* GameObject newGO = new GameObject();

		 for (int i = 0; i < footholds.Count; i++)
		 {
			 footholds[i].transform.parent = newGO.transform; // NO longer DontDestroyOnLoad();
			 transform.SetParent(null);
			 Destroy(newGO);
		 }*/

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
        //SearchObject();

		hasKey = false;
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
				img.color = new Color(0, 0, 0, i);
				yield return null;
			}
			transform.position = new Vector3(playerposX, playerposY);
			SceneManager.LoadScene(loadSceneName);
		}
	}
}
