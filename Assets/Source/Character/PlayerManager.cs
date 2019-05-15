using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Code it.
public class PlayerManager : MonoBehaviour
{
	protected void Start()
	{
		mMadBomberData = GetComponent<MadBomberData>();
		mInputHandler = GetComponent<PlayerInputHandler>();
	}

	void Update()
	{
		HandleRespawn();
		HandleLoseLife();
	}
		
	public void ApplyLoseLife()
	{
		mLoseLife = true;
	}

	public void HandleLoseLife()
	{
		if(mLoseLife)
		{
			mLifeAmount--;
			mMadBomberData.SetToDefaultValues();

			if(mLifeAmount < 0)
				LevelChangeManager.ChangeLevelToThanksScreen();

			if(mActualMadBomber != null)
				Destroy(mActualMadBomber);

			mRespawn = true;
			mLoseLife = false;
		}
	}

	public void HandleRespawn()
	{
		if(mRespawn)
		{
			mRespawn = false;
			mActualMadBomber = Instantiate<GameObject>(mMadBomber, Vector3.zero, Quaternion.identity, transform);
			mActualMadBomber.transform.localPosition = Vector3.zero;
			mInputHandler.RefreshController();

			PlayerHitTakenController hitTakenController = mActualMadBomber.GetComponent<PlayerHitTakenController>();
			hitTakenController.InitAttributes();
			hitTakenController.ApplyInvincibility();
		}
	}

	public int mLifeAmount = 3;

	public GameObject mMadBomber;

	[HideInInspector]
	public int mPoints = 0;


	protected GameObject mActualMadBomber;
	protected MadBomberData mMadBomberData;
	protected PlayerInputHandler mInputHandler;

	protected bool mLoseLife;
	protected bool mRespawn = true;
}

