﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InOutType
{
	IN, OUT
}

public class TargetInOutCheck : MonoBehaviour {
	public List<string> targetTags;
	public Rect inRect;
	public Rect outRect;

	List<Transform> targets = new List<Transform>();
	List<Transform> inRangeTargets = new List<Transform>();  // 在可选中范围内的目标
	List<Transform> outRangeTargets = new List<Transform>(); // 在可选中范围外的目标
	bool hasTargetsIn = false;
	bool hasTargetsOut = false;
	void Awake()
	{
		foreach (string tag in targetTags) {
			GameObject[] tagTargets = GameObject.FindGameObjectsWithTag(tag);
			for (int i = 0; i < tagTargets.Length; ++i) {
				targets.Add(tagTargets[i].transform);
			}
		}
		foreach (Transform target in targets) {
			outRangeTargets.Add(target);
		}
	}

	void Start ()
	{
		
	}
	
	void Update ()
	{
		CheckTargetsIn();
		CheckTargetsOut();
		if (hasTargetsIn || hasTargetsOut) {
			print("hasTargetsIn:" + hasTargetsIn);
			print("hasTargetsOut:" + hasTargetsOut);
		}
	}

	// 是否有目标进入选中范围
	bool CheckTargetsIn()
	{
		hasTargetsIn = false;
		Vector2 o = new Vector2(transform.position.x, transform.position.z);
		List<Transform> removeTemp = new List<Transform>();
		foreach (Transform target in outRangeTargets) {
			Vector2 t = new Vector2(target.position.x, target.position.z);
			Vector2 offset = new Vector2(t.x - o.x, o.y - t.y);  // Rect的坐标系Y轴与Unity坐标系相反
			if (inRect.Contains(offset)) {
				if (!inRangeTargets.Contains(target)) {
					inRangeTargets.Add(target);
				}
				//outRangeTargets.Remove(target);
				removeTemp.Add(target);
				hasTargetsIn = true;
			}
		}
		foreach (Transform target in removeTemp) {
			outRangeTargets.Remove(target);
		}
		return hasTargetsIn;
	}

	// 是否有目标脱离选中范围
	bool CheckTargetsOut()
	{
		hasTargetsOut = false;
		Vector2 o = new Vector2(transform.position.x, transform.position.z);
		List<Transform> removeTemp = new List<Transform>();
		foreach (Transform target in inRangeTargets) {
			Vector2 t = new Vector2(target.position.x, target.position.z);
			Vector2 offset = new Vector2(t.x - o.x, o.y - t.y);  // Rect的坐标系Y轴与Unity坐标系相反
			if (!outRect.Contains(offset)) {
				if (!outRangeTargets.Contains(target)) {
					outRangeTargets.Add(target);
				}
				//inRangeTargets.Remove(target);
				removeTemp.Add(target);
				hasTargetsOut = true;
			}
		}
		foreach (Transform target in removeTemp) {
			inRangeTargets.Remove(target);
		}
		return hasTargetsOut;
	}
}