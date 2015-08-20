using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class CardObject : MonoBehaviour {

	public Sprite thisSprite;
	public Sprite cardDown;
	public int index;
	public bool isDown;
	public bool valueNull;

	void Update() {

			if (isDown) {
			this.gameObject.GetComponent<Image>().sprite = cardDown;
		} else {
			this.gameObject.GetComponent<Image>().sprite = thisSprite;
		}
	}
}
