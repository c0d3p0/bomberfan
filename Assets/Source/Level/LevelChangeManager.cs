using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelChangeManager
{
	static LevelChangeManager()
	{
		mActivePlayerManagers = new GameObject[mPlayerAmount];
		mSelectedBombers = new GameObject[mPlayerAmount];
	}

	public static void ChangeLevel()
	{
		Scene actualScene = SceneManager.GetActiveScene();
		
		if(mSceneIndex != null)
			mSceneIndex = actualScene.buildIndex;
		else
			mSceneIndex = 0;
		
		mSceneIndex++;

		if(mSceneIndex < SceneManager.sceneCountInBuildSettings)
		{
			for(int i = 0; i < mActivePlayerManagers.Length; i++)
			{
				if(mActivePlayerManagers[i] != null)
					GameObject.DontDestroyOnLoad(mActivePlayerManagers[i]);

				if(mSelectedBombers[i] != null)
					GameObject.DontDestroyOnLoad(mSelectedBombers[i]);
			}

			SceneManager.LoadScene(mSceneIndex);
		}
		else
		{
			DestroyAllPlayerActivePlayerManagers();
			SceneManager.LoadScene(GameAttributes.TITLE_SCREEN_NAME);
		}
	}

	public static void ChangeLevelToThanksScreen()
	{
		DestroyAllPlayerActivePlayerManagers();			
		mSceneIndex = -1;
		SceneManager.LoadScene(GameAttributes.THANKS_SCREEN_NAME);
	}

	protected static void DestroyAllPlayerActivePlayerManagers()
	{
		if(mActivePlayerManagers != null)
		{
			for(int i = 0; i < mActivePlayerManagers.Length; i++)
				GameObject.Destroy(mActivePlayerManagers[i]);
		}
	}

	public static int mSceneIndex = 0;
	public static GameObject[] mActivePlayerManagers;
	public static GameObject[] mSelectedBombers;
	public static int mPlayerAmount = 4;
}

