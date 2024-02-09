using UnityEngine;
using System.Collections;

public class ShowUnitHealth : ShowUnitStat {
    //show health
	override protected float newStatValue() {
		return unit.GetComponent<UnitStats> ().health;
	}
}
