using UnityEngine;
using System.Collections;

public class FPSDataRender : MonoBehaviour
{
	void Awake()
	{
		InitGUIStyle();
	}

	void Update()
	{
		mDeltaTime += (Time.deltaTime - mDeltaTime) * 0.1f;
	}

	void OnGUI()
	{
		string fps = "FPS: " + (1f / Time.deltaTime);
		string milisecond = "ms:" + (mDeltaTime * 1000f);

		GUILayout.BeginArea(new Rect(0, 0, Screen.width / 10, Screen.height / 10), mStyle);
		GUILayout.BeginVertical();
		GUILayout.FlexibleSpace();
		GUILayout.Label(fps);
		GUILayout.Label(milisecond);
		GUILayout.FlexibleSpace();
		GUILayout.EndVertical();
		GUILayout.EndArea();
	}

	protected void InitGUIStyle()
	{
		Texture2D background = new Texture2D(width, height);
		Color rgb_color = new Color(0f, 0f, 0f, 0.2f);

		for(int i = 0; i < width; i++)
			for(int j = 0; j < height; j++)
				background.SetPixel(i, j, rgb_color);

		background.Apply();

		mStyle = new GUIStyle();
		mStyle.alignment = TextAnchor.UpperLeft;
		mStyle.fontSize = Screen.height * 2 / 100;
		mStyle.normal.textColor = new Color(1f, 1f, 1f, 1f);
		mStyle.normal.background = background;
	}

	protected float mDeltaTime = 0.0f;
	protected GUIStyle mStyle;
	protected int width = Screen.width / 10;
	protected int height = Screen.height / 10;
}
