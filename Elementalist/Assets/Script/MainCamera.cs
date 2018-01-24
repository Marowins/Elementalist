using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {

	public GameObject player;


	void Update () {
		transform.position = Vector2.Lerp(transform.position, player.transform.position, 10.0f * Time.deltaTime);
		transform.Translate (0, 0, -10);
	}
}
