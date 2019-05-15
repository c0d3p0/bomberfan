using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MadBomberAnimationManager : BaseAnimationManager
{
	protected void Start()
	{
		mMadBomberData = GetComponentInParent<MadBomberData>();
		mController = GetComponentInParent<MB_CC_BomberController>();
		mHitTakenController = GetComponentInParent<PlayerHitTakenController>();
		mAnimator = GetComponentInChildren<Animator>();
		mModel3DRenderers = GameObjectUtil.FindChildByTag(transform, TagName.MODEL_3D).GetComponentsInChildren<Renderer>();
	}

	protected override void HandleRotation()
	{
		if(mController.mCanExecuteActions)
			base.HandleRotation();
	}

	protected override void Update()
	{
		HandleAttributes();
		HandleRotation();
		SetAnimatorAttributes();
		HandleInvincibleBlinkEffect(Time.deltaTime);
	}

	protected void HandleAttributes()
	{
		SetMoveFlags(mController.mMoveUp, mController.mMoveLeft, mController.mMoveDown, mController.mMoveRight);

		bool anyDirection = (mMoveUp || mMoveLeft || mMoveDown || mMoveRight);

		mWalk = anyDirection && mMadBomberData.MoveSpeedFactor <= mWalkSpeedFactor;
		mRun = anyDirection && mMadBomberData.MoveSpeedFactor > mWalkSpeedFactor;
		mDamage = mHitTakenController.mDamage;
		mDead = mHitTakenController.mDead;

	}

	protected void SetAnimatorAttributes()
	{
		mAnimator.SetBool("Walk", mWalk);
		mAnimator.SetBool("Run", mRun);
		mAnimator.SetBool("Damage", mDamage);
		mAnimator.SetBool("Dead", mDead);
		mAnimator.SetBool("Win", Input.GetKey(KeyCode.L));
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

	public float mWalkSpeedFactor = 3f;

	protected Animator mAnimator;

	protected MB_CC_BomberController mController;
	protected MadBomberData mMadBomberData;

	protected PlayerHitTakenController mHitTakenController;

//	protected GameObject mModel3DGameObject;
	protected Renderer[] mModel3DRenderers;

	protected bool mWalk, mRun, mDamage, mDead, mWin;

	protected float mSecondsPassed;
	protected float mBlinkTimeInterval = 0.1f;
	protected bool mModel3DForceVisible;
}
