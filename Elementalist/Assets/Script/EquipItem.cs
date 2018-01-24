using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipItem : MonoBehaviour {

	public Sprite[] sprites = new Sprite[7];
	public int state = 6;

	void Start () {
		state = 6;
	}

	void Update () {
		GetComponent<SpriteRenderer> ().sprite = sprites[state];
		GameObject.Find ("Player").GetComponent<Player> ().element = state;
	}
}
