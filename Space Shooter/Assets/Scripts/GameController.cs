using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public GameObject hazard;
	public Vector3 spawnValue;
	public float waveWait;
	public float spawnWait;
	public float startWait;
	public int   hazardCount;

	private int score;
	public Text scoreText;

	private bool gameOver;
	public Text gameOverText;

	private bool restart;
	public Text restartText;
	// Use this for initialization
	void Start () {
		score = 0;
		gameOver = false;
		restart = false;
		gameOverText.gameObject.SetActive (false);
		restartText.gameObject.SetActive (false);
		StartCoroutine(SpawnWaves ());
	}

	// Update is called once per frame
	void Update () {
		if (gameOver) {
			if (Input.GetKeyDown (KeyCode.R)) {
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}

	IEnumerator SpawnWaves(){
		yield return new WaitForSeconds (startWait);
		while (true) {
			for (int i = 0; i < hazardCount; i++) {
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValue.x, spawnValue.x),
					                        spawnValue.y,
					                        spawnValue.z);

				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
		}
	}

	public void AddScore(int value){
		score += value;
		UpdateScore ();
	}

	void UpdateScore(){
		scoreText.text = "Score:" + score;
	}

	public void GameOver(){
		gameOver = true;
		gameOverText.gameObject.SetActive (true);
		restartText.gameObject.SetActive (true);
	}

	void RestartGame(){
		gameOver = false;
		gameOverText.gameObject.SetActive (false);
		restartText.gameObject.SetActive (false);
	}
}
