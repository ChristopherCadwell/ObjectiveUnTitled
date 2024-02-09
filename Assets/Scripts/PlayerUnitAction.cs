using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerUnitAction : MonoBehaviour {

	[SerializeField]
	private GameObject physicalAttack;

	[SerializeField]
	private GameObject magicalAttack;

	private GameObject currentAttack;

	[SerializeField]
	private Sprite faceSprite;

	void Awake () {
		this.physicalAttack = Instantiate (this.physicalAttack, this.transform) as GameObject;//attack button
		this.magicalAttack = Instantiate (this.magicalAttack, this.transform) as GameObject;//magic button

		this.physicalAttack.GetComponent<AttackTarget> ().owner = this.gameObject; //attack with physical
		this.magicalAttack.GetComponent<AttackTarget> ().owner = this.gameObject;//attack with magic

		this.currentAttack = this.physicalAttack;
	}

	public void selectAttack(bool physical) {
		this.currentAttack = (physical) ? this.physicalAttack : this.magicalAttack;
	}

	public void act(GameObject target) {
		this.currentAttack.GetComponent<AttackTarget> ().hit (target);
	}

	public void updateHUD() {
        //show player face
		GameObject playerUnitFace = GameObject.Find ("PlayerUnitFace") as GameObject;
		playerUnitFace.GetComponent<Image> ().sprite = this.faceSprite;

        //show player health
		GameObject playerUnitHealthBar = GameObject.Find ("PlayerUnitHealthBar") as GameObject;
		playerUnitHealthBar.GetComponent<ShowUnitHealth> ().changeUnit (this.gameObject);

        //show player mana
		GameObject playerUnitManaBar = GameObject.Find ("PlayerUnitManaBar") as GameObject;
		playerUnitManaBar.GetComponent<ShowUnitMana> ().changeUnit (this.gameObject);
	}
}
