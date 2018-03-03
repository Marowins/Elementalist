using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {

	public GameObject player;
	public float limX = 22f;
	public float limY = 20f;

	void Update () {
		transform.position = Vector3.Lerp (transform.position, player.transform.position, 10.0f * Time.deltaTime);

		Vector3 cameraP = transform.position; // 코드 위치 바꾸면 안되요

		if (cameraP.x >= limX) {
			cameraP.x = 22;
			transform.position = cameraP;
		} else if (cameraP.x <= -limX) {
			cameraP.x = -22;
			transform.position = cameraP;
		}
		if (cameraP.y >= limY) {
			cameraP.y = 20f;
			transform.position = cameraP;
		} else if (cameraP.y <= -limY) {
			cameraP.y = -20f;
			transform.position = cameraP;
		}

		transform.Translate (new Vector3 (0f, 0f, -10f));
	}

}
