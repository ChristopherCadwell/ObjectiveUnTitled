using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ChangeScene : MonoBehaviour {
    //function for picking scene
	public void loadNextScene(string sceneName) {
		SceneManager.LoadScene (sceneName);
	}
}
