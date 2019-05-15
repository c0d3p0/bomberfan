using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectManager : MonoBehaviour
{
	void Update ()
	{
		HandleChangeCharacterSelectionInput();
		HandleSelectCharacterInput();
		HandleCamera();
	}

	protected void HandleChangeCharacterSelectionInput()
	{
		if(mCameraTransform != null && mCharacters != null)
		{
			if(Input.GetKeyDown(KeyCode.A))
			{
				mCharacterIndex--;

				if(mCharacterIndex < 0)
					mCharacterIndex = 0;
			}

			if(Input.GetKeyDown(KeyCode.D))
			{
				mCharacterIndex++;

				if(mCharacterIndex >= mCharacters.Length)
					mCharacterIndex = mCharacters.Length - 1;
			}
		}
	}

	protected void HandleSelectCharacterInput()
	{
		if(mBombers != null)
		{
			if(Input.GetKeyDown(KeyCode.I))
			{
				LevelChangeManager.mSelectedBombers[0] = mBombers[mCharacterIndex];
				LevelChangeManager.ChangeLevel();
			}
		}
	}

	protected void HandleCamera()
	{
		if(mCameraTransform != null && mCharacters != null)
		{
			mCameraPosition.x = mCharacters[mCharacterIndex].position.x;
			mCameraTransform.position = mCameraPosition;
		}
	}

	public Transform mCameraTransform;
	public Vector3 mCameraPosition;

	public Transform[] mCharacters;
	public GameObject[] mBombers;

	protected int mCharacterIndex;
}
