using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldItems : MonoBehaviour {

	public int element = 0;

	public Sprite[] sprites = new Sprite[7];

	void Update()
	{
		gameObject.GetComponent<SpriteRenderer> ().sprite = sprites [element];
	}

}
