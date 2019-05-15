using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGenerator : MonoBehaviour
{
	void Awake()
	{
		HandleRepositionExistingPlayers();
		HandleGenerateSelectedPlayers();
		HandleGenerateDefaultPlayer();
	}

	protected void HandleRepositionExistingPlayers()
	{
		if(LevelChangeManager.mActivePlayerManagers != null)
		{
			for(int i = 0; i < LevelChangeManager.mActivePlayerManagers.Length; i++)
			{
				if(LevelChangeManager.mActivePlayerManagers[i] != null)
				{
					MB_CC_BomberController mController = LevelChangeManager.mActivePlayerManagers[i].GetComponentInChildren<MB_CC_BomberController>();
					mController.transform.position = mPlayerPositions[i];
					LevelChangeManager.mActivePlayerManagers[i].GetComponentInChildren<PlayerHitTakenController>().ApplyInvincibility();
					mHasAtLeastOnePlayer = true;
					break;
				}
			}
		}
	}
		
	protected void HandleGenerateSelectedPlayers()
	{
		if(!mHasAtLeastOnePlayer)
		{
			for(int i = 0; i < LevelChangeManager.mSelectedBombers.Length; i++)
			{
				if(LevelChangeManager.mSelectedBombers[i] != null)
				{
					mPlayersManagers[i].GetComponent<PlayerManager>().mMadBomber = LevelChangeManager.mSelectedBombers[i];
					LevelChangeManager.mActivePlayerManagers[i] = Instantiate(mPlayersManagers[i], 
							mPlayerPositions[i], Quaternion.identity);
					mHasAtLeastOnePlayer = true;
				}
			}
		}
	}

	protected void HandleGenerateDefaultPlayer()
	{
		if(!mHasAtLeastOnePlayer)
		{
//			LevelChangeManager.Init();
			LevelChangeManager.mActivePlayerManagers[0] = Instantiate(mDefaultPlayerManager, mPlayerPositions[0], Quaternion.identity);
			mHasAtLeastOnePlayer = true;
		}
	}

	public GameObject mDefaultPlayerManager;

	public GameObject[] mPlayersManagers;

	public Vector3[] mPlayerPositions = new Vector3[]{new Vector3(0f, 2.02f, 0f), new Vector3(40f, 2.02f, 0f), 
			new Vector3(0f, 2.02f, -28f), new Vector3(40f, 2.02f, -28f)};

	protected bool mHasAtLeastOnePlayer;
}
