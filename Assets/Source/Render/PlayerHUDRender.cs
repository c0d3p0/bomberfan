using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHUDRender : MonoBehaviour
{
	void Start()
	{
		HandleAttributes();
		HandleRefreshPlayersAttributes();
		InitHUDRectangles();
		InitGUIStyle();
	}

	protected void HandleRefreshPlayersAttributes()
	{
		for(int i = 0; i < LevelChangeManager.mPlayerAmount; i++)
		{
			if(LevelChangeManager.mActivePlayerManagers[i] != null)
				mPlayerManagers[i] = LevelChangeManager.mActivePlayerManagers[i].GetComponent<PlayerManager>();

			if(mPlayerManagers[i] != null)
				mMadBomberDatas[i] = mPlayerManagers[i].GetComponentInChildren<MadBomberData>();
		}
	}

	protected void HandleAttributes()
	{
		mPlayerManagers = new PlayerManager[LevelChangeManager.mPlayerAmount];
		mMadBomberDatas = new MadBomberData[LevelChangeManager.mPlayerAmount];
		mPlayerHUDRects = new Rect[LevelChangeManager.mPlayerAmount];
	}

	protected void DrawHUD()
	{
		for(int i = 0; i < LevelChangeManager.mPlayerAmount; i++)
		{
			if(LevelChangeManager.mActivePlayerManagers[i] != null && mMadBomberDatas[i] != null)
			{
				GUILayout.BeginArea(mPlayerHUDRects[i], mGUIStyle);
				GUILayout.BeginHorizontal();
				GUILayout.BeginVertical();
				GUILayout.FlexibleSpace();
				GUILayout.Label("Life: " + mPlayerManagers[i].mLifeAmount);
				GUILayout.Label("Move Speed: " + mMadBomberDatas[i].MoveSpeedFactor);
				GUILayout.FlexibleSpace();
				GUILayout.FlexibleSpace();
				GUILayout.FlexibleSpace();
				GUILayout.EndVertical();

				GUILayout.BeginVertical();
				GUILayout.FlexibleSpace();
				GUILayout.Label("Bomb Amount: " + mMadBomberDatas[i].BombAmount);
				GUILayout.Label("Explosion Size: " + mMadBomberDatas[i].ExplosionSizeFactor);
				GUILayout.FlexibleSpace();
				GUILayout.FlexibleSpace();
				GUILayout.FlexibleSpace();
				GUILayout.EndVertical();

				GUILayout.BeginVertical();
				GUILayout.FlexibleSpace();
//				GUILayout.Label("Points: " + mPlayerManagers[i].mPoints);
//				GUILayout.Label("");
				GUILayout.FlexibleSpace();
				GUILayout.FlexibleSpace();
				GUILayout.FlexibleSpace();
				GUILayout.EndVertical();

				GUILayout.EndHorizontal();
				GUILayout.EndArea();
			}
		}
	}

	protected void InitHUDRectangles()
	{
		mHudWidth = Screen.width * 0.24f;
		mHudHeight = Screen.height * 0.10f;
		mMargin = Screen.width * 0.008f;

		float positionY = mMargin;

		for(int i = 0; i < LevelChangeManager.mPlayerAmount; i++)
		{
			float positionX = mMargin + (i * mHudWidth) + (i * mMargin);
			mPlayerHUDRects[i] = new Rect(positionX, positionY, mHudWidth, mHudHeight);
		}
	}

	protected void InitGUIStyle()
	{
		Texture2D background = new Texture2D(Mathf.RoundToInt(mHudWidth), Mathf.RoundToInt(mHudHeight));
		Color rgb_color = new Color(0f, 0f, 0f, 0.2f);

		for(int i = 0; i < mHudWidth; i++)
		{
			for(int j = 0; j < mHudHeight; j++)
				background.SetPixel(i, j, rgb_color);
		}

		background.Apply();

		mGUIStyle = new GUIStyle();
		mGUIStyle.alignment = TextAnchor.UpperLeft;
		mGUIStyle.fontSize = Screen.height * 50;
		mGUIStyle.normal.textColor = new Color(1f, 1f, 1f, 1f);
		mGUIStyle.normal.background = background;
	}

	public void Update()
	{
//		HandleRefreshPlayersAttributes();
	}

	void OnGUI()
	{
		DrawHUD();
	}

	protected Rect[] mPlayerHUDRects;

//	protected string[] mPlayerManagerNames = new string[]{GameObjectName.PLAYER_ONE_MANAGER, GameObjectName.PLAYER_TWO_MANAGER, 
//			GameObjectName.PLAYER_THREE_MANAGER, GameObjectName.PLAYER_FOUR_MANAGER};
	
	protected PlayerManager[] mPlayerManagers;
	protected MadBomberData[] mMadBomberDatas;
//	protected bool[] mHasPlayers;

	protected float mHudWidth;
	protected float mHudHeight;
	protected float mMargin;

	protected GUIStyle mGUIStyle;
}
