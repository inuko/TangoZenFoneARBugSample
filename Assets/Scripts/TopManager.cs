using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TopManager : MonoBehaviour {

	public void showManagerScene(){
		SceneManager.LoadScene ("Manager");
	}

	public void showPlayerScene(){
		SceneManager.LoadScene ("Player");
	}
}
