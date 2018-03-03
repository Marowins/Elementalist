using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour {
	//웨이브
	public int wave = 1;
	//현재 웨이브에서 몬스터를 몇번 스폰했는지
	int spawnCnt = 0;

	bool waveProceeding = false;

	public GameObject[] spawnPoint = new GameObject[4];	//0 = Up, 1 = Left, 2 = Down, 3 = Right
	public GameObject kelsiper;

	void Update () {
		if (waveProceeding == false) {
			StartCoroutine(WaveControl());
			waveProceeding = true;
		}
	}

	void WaveStart(){
		
	}

	IEnumerator WaveControl(){
		int randomNumb1 = Random.Range (0, 4);
		int randomNumb2 = Random.Range (0, 4);
		while (randomNumb2 == randomNumb1) {
			randomNumb2 = Random.Range (0, 4);
		}
		Instantiate (kelsiper, spawnPoint [randomNumb1].transform.position, Quaternion.identity);
		Instantiate (kelsiper, spawnPoint [randomNumb2].transform.position, Quaternion.identity);
		spawnCnt++;
		yield return new WaitForSeconds (10.0f);
		if (spawnCnt < 5)
			StartCoroutine (WaveControl ());
	}

}
