using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MB_CC_BaseController : BaseController
{
	void Start ()
	{
		mController = GetComponent<CharacterController>();
	}

	void Update()
	{
		HandleMove(Time.deltaTime);
		mController.Move(mDesiredMove);
		CleanMoveVectors();
	}

	public virtual void MoveLeft(bool moveLeft)
	{
		mMoveLeft = moveLeft;

		if(moveLeft && !mMoveRight)
			mMoveDirection.x = -1;

		if(moveLeft && mMoveRight)
			mMoveDirection.x = 0;
	}

	public virtual void MoveRight(bool moveRight)
	{
		mMoveRight = moveRight;

		if(moveRight && !mMoveLeft)
			mMoveDirection.x = 1;

		if(moveRight && mMoveLeft)
			mMoveDirection.x = 0;
	}

	public virtual void MoveUp(bool moveUp)
	{
		mMoveUp = moveUp;

		if(moveUp && !mMoveDown)
			mMoveDirection.z = 1;

		if(moveUp && mMoveDown)
			mMoveDirection.z = 0;
	}

	public virtual void MoveDown(bool moveDown)
	{
		mMoveDown = moveDown;

		if(moveDown && !mMoveUp)
			mMoveDirection.z = -1;

		if(moveDown && mMoveUp)
			mMoveDirection.z = 0;
	}
		
	public virtual void CleanMoveVectors()
	{
		mMoveDirection.Set(0f, 0f, 0f);
		mDesiredMove.Set(0f, 0f, 0f);
	}

	protected virtual void HandleMove(float deltaTime)
	{
		if(mCanExecuteActions)
		{
			mDesiredMove.x += mMoveDirection.x * mMoveSpeed * (1 + (mMoveSpeedFactor * 0.5f)) * deltaTime;
			mDesiredMove.y = 0f;
			mDesiredMove.z += mMoveDirection.z * mMoveSpeed * (1 + (mMoveSpeedFactor * 0.5f)) * deltaTime;
		}
	}
		
	public float mMoveSpeed;

	[HideInInspector]
	public bool mMoveLeft, mMoveRight, mMoveUp, mMoveDown;

	[HideInInspector]
	public Vector3 mMoveDirection;

	protected int mMoveSpeedFactor = 1;

	protected Vector3 mDesiredMove;
	protected CharacterController mController;
}
