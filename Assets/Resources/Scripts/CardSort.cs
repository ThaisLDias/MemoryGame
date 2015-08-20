using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CardSort : MonoBehaviour {

	public List<int> cards = new List<int>(){1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21};
	public Sprite[] imagesAnimals = new Sprite[10];
	public Sprite[] imagesPlaces = new Sprite[10];
	public int[] savedValues;
	public bool canRunn;

	void Start(){
	
		imagesAnimals = Resources.LoadAll<Sprite> ("Assets/Animals");
		imagesPlaces = Resources.LoadAll <Sprite>("Assets/Habitats");
		canRunn = false;
		int i = 0;

		while(i < cards.Count - 1) {
			string animal =  cards[MyRandomRange(1,21,savedValues,canRunn)].ToString();
			string habitat = cards[Random.Range(1,20)].ToString();
			Debug.Log("A: " + animal +" H: " + habitat );
			SortImagePar(animal,habitat);
			i++;
		}
	}
	void SortImagePar(string animals, string places){

		int randomSprite = Random.Range (0, 9);
		Debug.Log (randomSprite);
		GameObject.Find (animals).GetComponent<CardObject>().thisSprite = imagesAnimals[randomSprite];
		GameObject.Find (places).GetComponent<CardObject>().thisSprite = imagesPlaces[randomSprite];
		GameObject.Find (animals).GetComponent<CardObject>().index = randomSprite;
		GameObject.Find (places).GetComponent<CardObject>().index = randomSprite;
		}

	public int MyRandomRange(int a, int b, int[] num, bool canRun)
	{
		int randomic = Random.Range (a, b);
		for (int i = 0; i < num.Count; i++) {
			if(randomic == num[i])
				randomic = Random.Range (a, b);
			else{
				return canRun = true;
			}
		}
	}
}
