using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAnimationManager : MonoBehaviour	
{
	protected virtual void Update()
	{
		HandleRotation();
	}

	protected virtual void HandleRotation()
	{
		if(mMoveUp || mMoveLeft || mMoveDown || mMoveRight)
			transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, GetModelAngleFromMove(), transform.localEulerAngles.z);
	}

	protected float GetModelAngleFromMove()
	{
		if(mEightWayMove)
			return GetModelAngleFrom8WayMove();
		else
			return GetModelAngleFrom4WayMove();
	}

	protected float GetModelAngleFrom4WayMove()
	{
		if(mMoveUp)
			return mMoveUpAngle;

		if(mMoveLeft)
			return mMoveLeftAngle;
		
		if(mMoveDown)
			return mMoveDownAngle;
		
		if(mMoveRight)
			return mMoveRightAngle;

		return 0;
	}

	protected float GetModelAngleFrom8WayMove()
	{
		if(mMoveUp)
		{
			if(mMoveLeft)
				return mMoveUpLeftAngle;

			if(mMoveRight)
				return mMoveUpRightAngle;

			return mMoveUpAngle;
		}

		if(mMoveDown)
		{
			if(mMoveLeft)
				return mMoveDownLeftAngle;

			if(mMoveRight)
				return mMoveDownRightAngle;

			return mMoveDownAngle;
		}

		if(mMoveLeft)
			return mMoveLeftAngle;

		if(mMoveRight)
			return mMoveRightAngle;

		return 0;
	} 

	public void SetMoveFlags(bool moveUp, bool moveLeft, bool moveDown, bool moveRight)
	{
		mMoveUp = moveUp;
		mMoveLeft = moveLeft;
		mMoveDown = moveDown;
		mMoveRight = moveRight;
	}

	public bool mEightWayMove;

	public float mMoveUpAngle = 180f;
	public float mMoveLeftAngle = 90f;
	public float mMoveDownAngle = 0f;
	public float mMoveRightAngle = 270f;

	public float mMoveUpRightAngle = 225f;
	public float mMoveUpLeftAngle = 135f;
	public float mMoveDownRightAngle = 315f;
	public float mMoveDownLeftAngle = 45f;
		
	protected bool mMoveUp, mMoveLeft, mMoveDown, mMoveRight;
}