using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimlessBomb : ActivationBomb
{
	public Vector3 GetActualDirection()
	{
		return mMoveDirections[mMoveDirectionIndex];
	}
		
	protected override void OnUpdate()
	{
		base.OnUpdate();
		HandleAttributes();
		HandleAction(Time.deltaTime);
	}

	protected void HandleAttributes()
	{
		mActualPosition = transform.localPosition;
	}

	protected void HandleAction(float deltaTime)
	{
		if(mActivated && !mDetonationActivated)
		{
			switch(mMoveDirectionIndex)
			{
				case -1:
					mMoveDirectionIndex = Random.Range(0, 4);
					mDistanceToMove = Random.Range(mMinMovementDistance, mMaxMovementDistance) * 2;
					mDesiredDestinyPosition.x = mActualPosition.x + mDistanceToMove;
					mDesiredDestinyPosition.y = mActualPosition.y + mDistanceToMove;
					mDesiredDestinyPosition.z = mActualPosition.z + mDistanceToMove;
					mDesiredDestinyPosition.Scale(mMoveDirections[mMoveDirectionIndex]);
					break;
				case 0:
//					SetMoveFlags(true, false, false, false);
					HandleMovement(mDesiredDestinyPosition.z > mActualPosition.z, deltaTime);
					break;
				case 1:
//					SetMoveFlags(false, true, false, false);
					HandleMovement(mDesiredDestinyPosition.x < mActualPosition.x, deltaTime);
					break;
				case 2:
//					SetMoveFlags(false, false, true, false);
					HandleMovement(mDesiredDestinyPosition.z < mActualPosition.z, deltaTime);
					break;
				case 3:
//					SetMoveFlags(false, false, false, true);
					HandleMovement(mDesiredDestinyPosition.x > mActualPosition.x, deltaTime);
					break;
			}
		}
	}

	protected void HandleMovement(bool needMove, float deltaTime)
	{
		if(needMove)
			transform.root.Translate(mMoveSpeed * deltaTime * mMoveDirections[mMoveDirectionIndex]);
		else
			mMoveDirectionIndex = -1;
	}

//	protected void SetMoveFlags(bool moveUp, bool moveLeft, bool moveDown, bool moveRight)
//	{
//		mMoveUp = moveUp;
//		mMoveLeft = moveLeft;
//		mMoveDown = moveDown;
//		mMoveRight = moveRight;
//	}

	public int MoveDirectionIndex
	{
		get
		{
			return mMoveDirectionIndex;
		}
	}

	public float mMoveSpeed = 1f;
	public int mMaxMovementDistance = 8;
	public int mMinMovementDistance = 1;

	protected Vector3[] mMoveDirections = new Vector3[]{Vector3.forward, Vector3.left, Vector3.back, Vector3.right};

	protected Vector3 mActualPosition;
	protected Vector3 mDesiredDestinyPosition;

	protected float mDistanceToMove;

	protected int mMoveDirectionIndex = -1;
}
