﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyAnimEvents : MonoBehaviour {
	AnimEventsManager I_AnimEventsManager;
	void Awake()
	{
		I_AnimEventsManager = GetComponentInParent<AnimEventsManager>();
	}

	void Start()
	{

	}
	
	void Update () {
		
	}

	// 近战武器左右攻击动画切换
	void ChangeAtkDir()
	{
		I_AnimEventsManager.ChangeAtkDir();
	}

	/*--------------- 帧动画响应函数 ---------------*/
	// 武器攻击
	void OnAttack()
	{
		I_AnimEventsManager.OnAttack();
	}

	// 攻击结束
	void OnAttackEnd()
	{
		I_AnimEventsManager.OnAttackEnd();
	}

	void OnReloadEnd()
	{
		I_AnimEventsManager.OnReloadEnd();
	}

	void PlayReloadSound()
	{
		I_AnimEventsManager.PlayReloadSound();
	}

	void ResetOnceAttack()
	{
		I_AnimEventsManager.ResetOnceAttack();
	}
}
