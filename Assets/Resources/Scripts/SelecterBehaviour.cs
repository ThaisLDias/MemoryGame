using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class SelecterBehaviour : MonoBehaviour {

	private List<Vector3> positions = new List<Vector3>();
	private GameObject Manager;
	private int currentPosition;
	public int openedCards;
	public List<GameObject> cardsOpenedNow = new List<GameObject>();
	void Start () {
		Manager = GameObject.Find ("Manager");
		openedCards = 0;
		for(int i = 0; i< Manager.GetComponent<CardSort>().cards.Count; i++)
		{
			positions.Add(Manager.GetComponent<CardSort>().cards[i].transform.position);
		}
		currentPosition = 0;
		this.transform.position = positions [currentPosition];
	}

	void Update () {
		this.transform.position = positions [currentPosition];
		Debug.Log (openedCards);
		if (Input.GetKeyDown (KeyCode.RightArrow) && currentPosition <= 16) {
			currentPosition += 3;
		}

		if (Input.GetKeyDown (KeyCode.LeftArrow) && currentPosition >=3) {
			currentPosition -= 3;
		}

		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			if (currentPosition == 0) 
			{
				currentPosition = 19;
			} 
			else 
			{
				currentPosition -= 1;
			}
		}

		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			if(currentPosition == 19)
			{
				currentPosition = 0;
			}
			else
			{
				currentPosition += 1;
			}
		}
	
		if (Input.GetKeyDown (KeyCode.Return) &&
		    GameObject.Find((currentPosition+1).ToString()).GetComponent<CardObject>().isDown &&
		    !GameObject.Find((currentPosition+1).ToString()).GetComponent<CardObject>().discoveredCard) 
		{
			GameObject.Find((currentPosition+1).ToString()).GetComponent<CardObject>().isDown = false;
			openedCards += 1;
			cardsOpenedNow.Add(GameObject.Find((currentPosition+1).ToString()));
		}
		if (openedCards == 2) {
			StartCoroutine(cardDelay(2f));

		}

	}
	void indexCheck(CardObject a, CardObject b, List<GameObject> list)
	{
		if (a.index == b.index) {
			a.discoveredCard = true;
			b.discoveredCard = true;
		}
		else {
			b.isDown = true;
			a.isDown = true;
		}
		list.RemoveAt (1);
		list.RemoveAt (0);
	}

	IEnumerator cardDelay (float _time) {
		yield return new WaitForSeconds(_time);
		indexCheck(cardsOpenedNow[0].GetComponent<CardObject>(),cardsOpenedNow[1].GetComponent<CardObject>(),cardsOpenedNow);
		openedCards = 0;
	}

}
