using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThankScreenManager : MonoBehaviour
{
	protected void Start()
	{
		mStartButton = GameObject.Find(GameObjectName.BACK_TO_INIT).GetComponent<Button>();
		mQuitButton = GameObject.Find(GameObjectName.QUIT_BUTTON).GetComponent<Button>();

		mStartButton.onClick.AddListener(OnClickBackToInit);
		mQuitButton.onClick.AddListener(OnClickQuitButton);
	}

	protected void OnClickBackToInit()
	{
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
