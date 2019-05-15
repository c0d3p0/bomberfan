using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChibiMummyModelTest : MonoBehaviour
{
	void Start()
	{
		mAnimator = GetComponent<Animator>();
	}

	void Update()
	{
		mAnimator.SetBool("Walk", Input.GetKey(KeyCode.W));
		mAnimator.SetBool("Damage", Input.GetKey(KeyCode.S));
		mAnimator.SetBool("Dead", Input.GetKey(KeyCode.A));
	}

	protected Animator mAnimator;
}
