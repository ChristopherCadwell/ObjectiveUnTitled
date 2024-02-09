using UnityEngine;
using System.Collections;

public class KillEnemy : MonoBehaviour {

	public GameObject menuItem;

	void OnDestroy() {
        //kill
		Destroy (this.menuItem);
	}
}
