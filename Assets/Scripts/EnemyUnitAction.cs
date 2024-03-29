﻿using UnityEngine;
using System.Collections;

public class EnemyUnitAction : MonoBehaviour {

	[SerializeField]
	private GameObject attack;

	[SerializeField]
	private string targetsTag;

	void Awake () {
		this.attack = Instantiate (this.attack);

		this.attack.GetComponent<AttackTarget> ().owner = this.gameObject;
	}

	GameObject findRandomTarget() {
        //pick target
		GameObject[] possibleTargets = GameObject.FindGameObjectsWithTag (targetsTag);

		if (possibleTargets.Length > 0) {
			int targetIndex = Random.Range (0, possibleTargets.Length);
			GameObject target = possibleTargets [targetIndex];

			return target;
		}

		return null;
	}

	public void act() {
		GameObject target = findRandomTarget ();
        //perform attack
		this.attack.GetComponent<AttackTarget> ().hit (target);
	}
}
