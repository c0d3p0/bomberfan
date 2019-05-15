using UnityEngine;
using System.Collections;


public class BasicMoveEnemyController : RandomDirectionEnemyController
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
			HandleAction(Time.deltaTime);
	}

	protected void HandleAction(float deltaTime)
	{
		if(NeedChangeDirection())
		{
			int oldIndex = mMoveDirectionIndex;

			do
				mMoveDirectionIndex = Random.Range(0, 4);
			while(mMoveDirectionIndex == oldIndex);
		}

		mController.Move(mEnemyData.mMoveSpeed * mEnemyData.mMoveSpeedFactor * deltaTime * mMoveDirections[mMoveDirectionIndex]);
	}

	protected bool NeedChangeDirection()
	{
		Vector3 startPosition = transform.position;
		startPosition.y = mRaycastPositionY;
		return Physics.Raycast(startPosition, mMoveDirections[mMoveDirectionIndex], mRaycastDistance, mPhysicBoxLayer);
	}

	public LayerMask mPhysicBoxLayer;

	public float mRaycastPositionY = 0.5f;

	protected float mRaycastDistance;

	protected CharacterController mController;
	protected BasicEnemyAnimationManager mAnimationManager;
	protected EnemyData mEnemyData;

	protected Vector3[] mMoveDirections = new Vector3[]{Vector3.forward, Vector3.left, Vector3.back, Vector3.right};
}
