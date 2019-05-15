using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerDeviceManager : MonoBehaviour
{
	public void DetectController()
	{
		if(Input.GetJoystickNames() != null)
		{
			if(Input.GetJoystickNames()[0] != null)
			{
				mHasControllerConnected = true;
				IdentifyController();
				return;
			}
		}

		mHasControllerConnected = false;
	}

	public void IdentifyController()
	{
		mControllerName = Input.GetJoystickNames()[0];

//		if(Input.inputString)
	}

	public void SetDefaultValues()
	{
//		if(mHasControllerConnected)
//		{
//			mKeyboardInputMapping.movement = "WASD";
//			mKeyboardInputMapping.putBomb = "I";
//			mKeyboardInputMapping.detonateBomb = "O";
//			mKeyboardInputMapping.changeBombSlot = "J";
//		}
//		else
//		{
//			Input.a
//		}
	}

	protected string GetKeyboardKeyPressed()
	{
		if(Input.anyKeyDown)
		{
			return Input.inputString;
		}

		return null;
	}

	protected string GetControllerButtonPressed()
	{
		for (int i = 0; i < 20; i++)
		{
			if(Input.GetKeyDown("joystick 1 button " + i))
				return "joystick 1 button " + i;
		}

		return null;
	}

	public InputMapping mKeyboardInputMapping = new InputMapping();
	public InputMapping mControllerInputMapping = new InputMapping();

	protected string mControllerName;
	protected bool mHasControllerConnected;
}
