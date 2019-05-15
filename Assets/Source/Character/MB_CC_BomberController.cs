using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MB_CC_BomberController : MB_CC_BaseController
{
	void Start()
	{
		mMadBomberData = GetComponentInParent<MadBomberData>();
		mController = GetComponent<CharacterController>();
	}

	void Update()
	{
		UpdateAttributes();
		HandleMove(Time.deltaTime);
		HandlePutBomb();
		HandleDetonateBomb();
		mController.Move(mDesiredMove);
		CleanMoveVectors();
	}

	protected void UpdateAttributes()
	{
		mMoveSpeedFactor = mMadBomberData.MoveSpeedFactor;
	}

	protected void HandlePutBomb()
	{
		if(mCanExecuteActions && mPutBomb && mMadBomberData.mActiveBombs.Count < mMadBomberData.BombAmount)
		{
			int positionX = 0;
			int positionZ = 0;
//			float positionY = mAttributes.mBomb.transform.localScale.y / 2f;
			float positionY = 0f;

			// Get a integer value from position to plot. Integer position is
			// the valid value to put bomb.
			if(transform.position.x >= 0)
				positionX = Mathf.FloorToInt(transform.position.x);
			else
				positionX = Mathf.CeilToInt(transform.position.x);

			if(transform.position.z >= 0)
				positionZ = Mathf.FloorToInt(transform.position.z);
			else
				positionZ = Mathf.CeilToInt(transform.position.z);

			if(positionX % 2 == 1)
				positionX++;

			if(positionZ % 2 == -1)
				positionZ--;

			Vector3 position = new Vector3(positionX, positionY, positionZ);
			GameObject bombGameObject = Instantiate<GameObject>(mMadBomberData.mBombSlots[mMadBomberData.mSelectedBombIndex], position, Quaternion.identity);
			Bomb bomb = bombGameObject.GetComponent<Bomb>();
			bomb.mMBOwner = transform.gameObject;
			bomb.mExplosionSizeFactor = mMadBomberData.ExplosionSizeFactor;
			/// TODO: Code here
//			Bomb b
//			bombGameObject.GetComponent<Bomb>().mMBOwner = transform.gameObject;
			mMadBomberData.mActiveBombs.Add(bombGameObject);
		}
	}

	protected void HandleDetonateBomb()
	{
		if(mCanExecuteActions && mDetonateBomb)
		{
			foreach(GameObject gameObject in mMadBomberData.mActiveBombs)
			{
				Bomb bomb = gameObject.GetComponent<Bomb>();

				if(!bomb.ExplosionStarted)
				{
					if(bomb.Detonate())
						break;
				}
			}
		}
	}

	public void PutBomb(bool putBomb)
	{
		mPutBomb = putBomb;
	}

	public void DetonateBomb(bool detonateBomb)
	{
		mDetonateBomb = detonateBomb;
	}

	public void ChangeSelectedBomb(bool changeBomb)
	{
		if(changeBomb)
		{
			mMadBomberData.mSelectedBombIndex++;

			if(mMadBomberData.mSelectedBombIndex >= mMadBomberData.mBombSlots.Length)
				mMadBomberData.mSelectedBombIndex = 0;
		}
	}

//	public void ResetPosition()
//	{
//		transform.position = 
//	}

	protected MadBomberData mMadBomberData;

	protected bool mPutBomb;
	protected bool mDetonateBomb;
}
