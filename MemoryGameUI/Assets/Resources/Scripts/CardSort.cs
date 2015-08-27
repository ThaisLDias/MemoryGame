using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CardSort : MonoBehaviour {

	public List<int> cards = new List<int>{1,2,3,4,5,6,7,8,9,10};
	public Sprite[] imagesAnimals;
	public Sprite[] imagesPlaces ;
		
	void Start(){
		imagesAnimals = Resources.LoadAll<Sprite> ("Animals");
		imagesPlaces = Resources.LoadAll <Sprite>("Habitats");
		for (int i = 0; i <= cards.Count; i++) {

			string animal =  Random.Range(1,21).ToString();
			string habitat = Random.Range(1,21).ToString();
			Debug.Log("A: " + animal +" H: " + habitat );
			SortImagePar(animal,habitat);
		}
	}

	void SortImagePar(string animals, string places){

		int randomSprite = Random.Range (0, (cards.Count - 1));

		GameObject.Find (animals).GetComponent<CardObject>().thisSprite = imagesAnimals[randomSprite];
		GameObject.Find (places).GetComponent<CardObject>().thisSprite = imagesPlaces[randomSprite];
		GameObject.Find (animals).GetComponent<CardObject>().index = randomSprite;
		GameObject.Find (places).GetComponent<CardObject>().index = randomSprite;

		cards.RemoveAt (randomSprite);
	}
}
