using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneSwap : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Restart"))
            RestartLevel();
	}

	void RestartLevel() {
		SceneManager.LoadScene("SampleScene");
	}
}
