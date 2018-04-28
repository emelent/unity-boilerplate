using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GM : MonoBehaviour {

	public static GM instance;
	public int numLevels = 2;
	public float nextLevelDelay = 1f;
	CameraShake cameraShake;
	AudioManager audioManager;

	[SerializeField]
	int numBlocks;
	// Use this for initialization
	void Awake () {
		if(instance == null){
			instance = this;
		}
		cameraShake = Camera.main.GetComponent<CameraShake>();
		audioManager = GetComponent<AudioManager>();
		instance.numBlocks = GameObject.FindGameObjectsWithTag("Platform").Length;
	}

	IEnumerator goToNextLevel(delay=nextLevelDelay){
		yield return new WaitForSeconds(delay);
		int  nextLevel =  SceneManager.GetActiveScene().buildIndex + 1;
		nextLevel = (nextLevel == numLevels)? 0: nextLevel;
		SceneManager.LoadScene(nextLevel);
	}

	public static void GoToNextLevel(){
		instance.StartCoroutine(instance.goToNextLevel());
	}

	public static void ShakeCamera(float amount, float duration){
		instance.cameraShake.Shake(amount, duration);
	}

	public static void PlaySound(string name){
		instance.audioManager.PlaySound(name);
	}
}
