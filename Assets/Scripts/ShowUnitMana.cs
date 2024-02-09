using UnityEngine;
using System.Collections;

public class ShowUnitMana : ShowUnitStat {
    //show mana
	override protected float newStatValue() {
		return unit.GetComponent<UnitStats> ().mana;
	}
}
