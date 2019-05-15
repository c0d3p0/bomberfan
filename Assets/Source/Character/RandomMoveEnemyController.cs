using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMoveEnemyController : RandomDirectionEnemyController
{
	void Start ()
	{
		mEnemyData = GetComponent<EnemyData>();
		mController = GetComponent<CharacterController>();
		mRaycastDistance = (GameObject.FindGameObjectWithTag(TagName.LEVEL_MANAGER).GetComponent<LevelData>().mBlockWidthDepthDimension / 2) + 0.1f;
		mMoveDirectionIndex = Random.Range(0, 4);
		mAnimationManager = GetComponentInChildren<BasicEnemyAnimationManager>();
	}

	void Update ()
	{
		if(mCanExecuteActions)
		{
			HandleAttributes();
			HandleNewDestinyPosition();
			HandleMovement(Time.deltaTime);
		}
	}

	protected void HandleAttributes()
	{
		mActualPosition = mController.transform.position;
		mChangeDirection = NeedChangeDirection();
		mArrivedDestiny = CheckArrivedInDestiny();	
	}

	protected void HandleMovement(float deltaTime)
	{
		if(!mChangeDirection && !mArrivedDestiny)
			mController.Move(mEnemyData.mMoveSpeed * mEnemyData.mMoveSpeedFactor * deltaTime * mMoveDirections[mMoveDirectionIndex]);
	}

	protected void HandleNewDestinyPosition()
	{
		if(mChangeDirection || mArrivedDestiny)
		{
			if(mChangeDirection && !mArrivedDestiny)
			{
				int oldIndex = mMoveDirectionIndex;

				do
					mMoveDirectionIndex = Random.Range(0, 4);
				while(mMoveDirectionIndex == oldIndex);
			}
			else
				mMoveDirectionIndex = Random.Range(0, 4);

			mDistanceToMove = Random.Range(mMinMovementDistance, mMaxMovementDistance) * 2;
			mDesiredDestinyPosition.x = mActualPosition.x + mDistanceToMove;
			mDesiredDestinyPosition.y = mActualPosition.y + mDistanceToMove;
			mDesiredDestinyPosition.z = mActualPosition.z + mDistanceToMove;
			mDesiredDestinyPosition.Scale(mMoveDirections[mMoveDirectionIndex]);
		}
	}

	protected bool NeedChangeDirection()
	{
		Vector3 startPosition = mActualPosition;
		startPosition.y = mRaycastPositionY;
		return Physics.Raycast(startPosition, mMoveDirections[mMoveDirectionIndex], mRaycastDistance, mPhysicBoxLayer);
	}

	public bool CheckArrivedInDestiny()
	{
		if(mMoveDirections[mMoveDirectionIndex].x != 0)
		{
			if(mMoveDirections[mMoveDirectionIndex].x > 0)
				return mActualPosition.x >= mDesiredDestinyPosition.x;
			else
				return mActualPosition.x <= mDesiredDestinyPosition.x;	
		}

		if(mMoveDirections[mMoveDirectionIndex].z != 0)
		{
			if(mMoveDirections[mMoveDirectionIndex].z > 0)
				return mActualPosition.z >= mDesiredDestinyPosition.z;
			else
				return mActualPosition.z <= mDesiredDestinyPosition.z;	
		}

		return false;
	}

	public LayerMask mPhysicBoxLayer;

	public int mMaxMovementDistance = 8;
	public int mMinMovementDistance = 1;

	public float mRaycastPositionY = 0.5f;

	protected Vector3 mActualPosition;
	protected Vector3 mDesiredDestinyPosition;

	protected float mDistanceToMove;

	protected float mRaycastDistance;

	protected CharacterController mController;
	protected BasicEnemyAnimationManager mAnimationManager;
	protected EnemyData mEnemyData;


	protected bool mChangeDirection, mArrivedDestiny;

	protected Vector3[] mMoveDirections = new Vector3[]{Vector3.forward, Vector3.left, Vector3.back, Vector3.right};
}
