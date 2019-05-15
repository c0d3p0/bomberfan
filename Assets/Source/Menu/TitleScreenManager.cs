using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScreenManager : MonoBehaviour
{
	protected void Start()
	{
		mStartButton = GameObject.Find(GameObjectName.START_GAME_BUTTON).GetComponent<Button>();
		mQuitButton = GameObject.Find(GameObjectName.QUIT_BUTTON).GetComponent<Button>();
//		mShowCollisionBoxesToggle = GameObject.Find(GameObjectName.SHOW_COLLISION_BOXES_TOGGLE).GetComponent<Toggle>();

		mStartButton.onClick.AddListener(OnClickStartButton);
		mQuitButton.onClick.AddListener(OnClickQuitButton);

//		LevelChangeManager.Init();
	}

	protected void OnClickStartButton()
	{
//		GameFlag.drawTriggerBoxes = mShowCollisionBoxesToggle.isOn;
		LevelChangeManager.ChangeLevel();
	}

	protected void OnClickQuitButton()
	{
		Application.Quit();
	}

	protected Button mStartButton;
	protected Button mQuitButton;
	protected Toggle mShowCollisionBoxesToggle;
}
