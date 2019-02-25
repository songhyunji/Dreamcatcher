using UnityEngine;

public class ShaderScript : MonoBehaviour
{
	// Toggle between Diffuse and Transparent/Diffuse shaders
	// when space key is pressed

	Shader shader;
	Renderer rend;


	void Start()
	{
		rend = GetComponent<Renderer>();
		shader = GetComponent<Shader>();
	}
}