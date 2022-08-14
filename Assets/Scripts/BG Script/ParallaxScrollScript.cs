using UnityEngine;
using System.Collections;

public class ParallaxScrollScript : MonoBehaviour
{

	public Renderer background;
	public Renderer midground;
	public Renderer foreground;

	public float backgroundSpeed = 0.01f;
	public float midgroundSpeed = 0.06f;
	public float foregroundSpeed = 0.12f;

	public float offset = 0;

	// Use this for initialization
	void Start()
	{
		float backgroundOffset = offset * backgroundSpeed;
		float midgroundOffset = offset * midgroundSpeed;
		float foregroundOffset = offset * foregroundSpeed;

		background.material.mainTextureOffset = new Vector2(backgroundOffset, 0);
		midground.material.mainTextureOffset = new Vector2(midgroundOffset, 0);
		foreground.material.mainTextureOffset = new Vector2(foregroundOffset, 0);
	}

	// Update is called once per frame
	void Update()
	{
		float backgroundOffset = offset * backgroundSpeed;
		float midgroundOffset = offset * midgroundSpeed;
		float foregroundOffset = offset * foregroundSpeed;

		background.material.mainTextureOffset = new Vector2(backgroundOffset, 0);
		midground.material.mainTextureOffset = new Vector2(midgroundOffset, 0);
		foreground.material.mainTextureOffset = new Vector2(foregroundOffset, 0);

	}
}