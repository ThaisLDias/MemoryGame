using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class CardObject : MonoBehaviour {

	public Sprite thisSprite;
	public Sprite cardDown;
	public int index;
	public bool isDown;
	// Use this for initialization
	void Start () {
		index = Convert.ToInt32(this.gameObject.name);
		isDown = true;
	}

	void Update() {

			if (isDown) {
			this.gameObject.GetComponent<Image>().sprite = cardDown;
		} else {
			this.gameObject.GetComponent<Image>().sprite = thisSprite;
		}
	}
}
