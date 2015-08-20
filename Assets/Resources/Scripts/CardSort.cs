using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CardSort : MonoBehaviour {

	public List<CardObject> cards = new List<CardObject>();
	public Sprite[] imagesAnimals = new Sprite[10];
	public Sprite[] imagesPlaces = new Sprite[10];
	int random;
	int i = 0;
	int b = 0;


	public void PutCardImage(){
		while(i < 20) {

			random = Random.Range (0, cards.Count);
			int random2 = Random.Range (0, cards.Count);

			if(random2 == random) 
			{
				random2 = Random.Range (0, cards.Count);
			}
			else 
			{
				Debug.Log (random.ToString() + " : " + random2.ToString());
				int animal =  random;
				int habitat = random2;

				if(cards[animal].valueNull && 
				   cards[habitat].valueNull)
				{
					SortImagePar(animal,habitat, cards);
					i++;
				}
				else
				{
					random2 = random;
				}
			}
		}
	}
	void SortImagePar(int animals, int places, List<CardObject> cardList){

		int randomSprite = Random.Range (0, 10);

		cardList[animals].thisSprite = imagesAnimals[randomSprite];
		cardList[places].thisSprite = imagesPlaces[randomSprite];
		cardList[animals].index = randomSprite;
		cardList[places].index = randomSprite;
		cardList[animals].valueNull = false;
		cardList[places].valueNull = false;
	}
	void Update()
	{
		if (b == 0) {
			PutCardImage ();
		}
		b = 1;
	}
}
