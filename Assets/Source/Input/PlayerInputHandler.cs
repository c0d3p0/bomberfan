using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
	void Update()
	{
		HandleRefreshController();
		HandleDirectionInputs();
		HandleButtonInputs();
	}

	public void RefreshController()
	{
		mRefreshController = true;
	}

	protected void HandleRefreshController()
	{
		if(mController == null)
		{
			mController = GetComponentInChildren<MB_CC_BomberController>();	
			mRefreshController = false;
		}
	}

	protected void HandleDirectionInputs()
	{
//		mController.MoveUp(Input.GetButton("MoveUp"));
//		mController.MoveLeft(Input.GetButton("MoveLeft"));
//		mController.MoveDown(Input.GetButton("MoveDown"));
//		mController.MoveRight(Input.GetButton("MoveRight"));
		if(mController != null)
		{
			mController.MoveUp(Input.GetKey(KeyCode.W));
			mController.MoveLeft(Input.GetKey(KeyCode.A));
			mController.MoveDown(Input.GetKey(KeyCode.S));
			mController.MoveRight(Input.GetKey(KeyCode.D));
		}
	}

	protected void HandleButtonInputs()
	{
//		mController.PutBomb(Input.GetButtonDown("PutBomb"));
//		mController.DetonateBomb(Input.GetButton("DetonateBomb"));

		if(mController != null)
		{
			mController.PutBomb(Input.GetKeyDown(KeyCode.I));
			mController.DetonateBomb(Input.GetKeyDown(KeyCode.O));
			mController.ChangeSelectedBomb(Input.GetKeyDown(KeyCode.J));
		}
	}

	protected MB_CC_BomberController mController;
	protected bool mRefreshController;
}
