using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogoScene : MonoBehaviour
{
	public Image img;

    // Start is called before the first frame update
    void Start()
    {
		StartCoroutine(Fade());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	IEnumerator Fade()
	{
		for (float i = 1; i >= 0; i -= Time.deltaTime)
		{
			img.color = new Color(0, 0, 0, i);
			yield return null;
		}

		yield return new WaitForSeconds(1); // 5초 동안 logo 띄워놓음

		for (float i = 0; i <= 1; i += Time.deltaTime)
		{
			img.color = new Color(0, 0, 0, i);
			yield return null;
		}
		SceneManager.LoadScene("Main");
	}
}
