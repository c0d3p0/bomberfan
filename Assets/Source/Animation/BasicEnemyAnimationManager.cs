using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyAnimationManager : BaseAnimationManager
{
	protected void Start()
	{
		mController = GetComponentInParent<RandomDirectionEnemyController>();
		mAnimator = GetComponentInChildren<Animator>();
		mEnemyData = GetComponentInParent<EnemyData>();
		mHitTakenController = GetComponentInParent<EnemyHitTakenController>();
		mAnimator = GetComponentInChildren<Animator>();
		mModel3DRenderers = GetComponentsInChildren<Renderer>();
	}

	protected override void Update()
	{
		HandleAttributes();
		HandleRotation();
		HandleInvincibleBlinkEffect(Time.deltaTime);
		SetAnimatorAttributes();
	}

	protected void HandleInvincibleBlinkEffect(float deltaTime)
	{
		if(mHitTakenController.mInvincible)
		{
			mSecondsPassed += deltaTime;

			if(mSecondsPassed >= mBlinkTimeInterval)
			{
				for(int i = 0; i < mModel3DRenderers.Length; i++)
					mModel3DRenderers[i].enabled = !mModel3DRenderers[i].enabled;

				mSecondsPassed = 0f;
			}

			mModel3DForceVisible = true;
		}
		else
		{
			if(mModel3DForceVisible)
			{
				for(int i = 0; i < mModel3DRenderers.Length; i++)
					mModel3DRenderers[i].enabled = true;

				mModel3DForceVisible = false;
			}

			mSecondsPassed = 0f;
		}
	}

	protected void SetAnimatorAttributes()
	{
		mAnimator.SetBool("Run", mRun);
		mAnimator.SetBool("Walk", mWalk);
		mAnimator.SetBool("Damage", mDamage);
		mAnimator.SetBool("Dead", mDead);
	}

	protected void HandleAttributes()
	{
		switch(mController.MoveDirectionIndex)
		{
			case 0:
				SetMoveFlags(true, false, false, false);
				break;
			case 1:
				SetMoveFlags(false, true, false, false);
				break;
			case 2:
				SetMoveFlags(false, false, true, false);
				break;
			case 3:
				SetMoveFlags(false, false, false, true);
				break;
		}

		mWalk = (mMoveUp || mMoveLeft || mMoveDown || mMoveRight) && (mEnemyData.mMoveSpeedFactor <= 1);
		mRun = (mMoveUp || mMoveLeft || mMoveDown || mMoveRight) && (mEnemyData.mMoveSpeedFactor > 1);
		mDamage = mHitTakenController.mDamage;
		mDead = mHitTakenController.mDead;
	}
		
	protected RandomDirectionEnemyController mController;
	protected EnemyData mEnemyData;
	protected Animator mAnimator;

	protected EnemyHitTakenController mHitTakenController;

	protected Renderer[] mModel3DRenderers;

	[HideInInspector]
	public bool mDamage, mDead, mWalk, mRun;


	protected float mSecondsPassed;
	protected float mBlinkTimeInterval = 0.1f;
	protected bool mModel3DForceVisible;
}
