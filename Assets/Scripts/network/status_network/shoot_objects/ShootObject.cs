﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace MMO
{
	//飞行过程中的击中判断类型
	public enum ShootCheckType
	{
		//没有物理检查，一般来说这种方式最简单高效
		NonePhysics,
		//射线检测
		LineCast,
		//球形物理检查
		SphereCast}

	;

	//Base class of all shoot object;
	//按照策略模式，一个SO应该分为三个部分，1.运动轨迹控制，2.击中判断，3.击中效果
	public abstract class ShootObject : MonoBehaviour
	{
		protected Transform thisT;
		protected Transform target;
		protected Vector3 offset;
		protected Vector3 targetPos;
		public float speed = 10;
		public float maxShootRange = 100;
		public MMOUnit baseAttribute;
		//飞行过程中的击中判断类型
		public ShootCheckType checkType = ShootCheckType.NonePhysics;
		//判断是否击中的最短距离，在所有模式下都有效
		public float hitThreshold = 0.15f;
		//当有物理检查时，可以进行物理检测的层
		public int[] targetLayers;
		//计算过后的多个层的‘与’值
		protected int calculatedLayer;
		//当用球形检查时，求的半径
		public float sphereRadius = 0.2f;
		//是否造成伤害，有一些情况下只是一个美术表现，不需要有伤害。
		public bool damageAble = true;
		//是否加上目标的相对位移
		public bool addTargetMoveDeltaPos = true;
		public AudioClip shootAudio;
		public GameObject shootEffect;

		public List<BaseHit> baseHits;

		public MMOUnit attacker;

		public bool isFriends;

		protected virtual void Awake ()
		{
			thisT = transform;
		}

		public virtual void Shoot (MMOUnit attacker, Vector3 targetPos, Vector3 offset)
		{
			this.targetPos = targetPos + offset;
			this.attacker = attacker;
			this.target = null;
			this.offset = offset;
		}

		public virtual void Shoot (MMOUnit attacker, MMOUnit target, Vector3 offset)
		{
			this.attacker = attacker;
			this.target = target.transform;
			this.offset = offset;
		}

		public virtual void Shoot (MMOUnit attacker, Transform target, Vector3 offset)
		{
			this.attacker = attacker;
			this.target = target;
			this.offset = offset;
		}

		//TODO dirction move shootobject.
		public virtual void Shoot (MMOUnit attacker, Vector3 direction)
		{
			this.attacker = attacker;
		}

		public virtual void OnHit ()
		{
			if (baseHits != null && baseHits.Count > 0) {
				for (int i = 0; i < baseHits.Count; i++) {
					if (target != null)
						baseHits [i].OnHit (thisT.position, isFriends, target.GetComponent<MMOUnit> ());
					else
						baseHits [i].OnHit (thisT.position, isFriends,null);
				}
			}
		}

		//设置进行碰撞物理检查的层
		public void SetTargetLayer (int[] layers)
		{
			targetLayers = layers;
			this.CalculateLayer ();
		}

		protected int CalculateLayer ()
		{
			int targetLayer = 0;
			if (targetLayers != null && targetLayers.Length > 0) {
				targetLayer = 1 << targetLayers [0];
				for (int i = 1; i < targetLayers.Length; i++) {
					targetLayer = targetLayer | (1 << targetLayers [i]);
				}
			}
			return targetLayer;
		}

	}
}
