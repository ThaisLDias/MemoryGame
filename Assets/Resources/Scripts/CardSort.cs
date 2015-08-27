using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CardSort : MonoBehaviour
{
	
	public List<CardObject> cards = new List<CardObject> ();
	public Sprite[] imagesAnimals = new Sprite[10];
	public Sprite[] imagesPlaces = new Sprite[10];
	int[] numbers;
	int random;
	int MAX;
	int mapX = 1;
	int randomSprite;
	void Start ()
	{
		numbers = new int[10];
		MAX = 10;
		for (int i = 0; i < 10; i++)
		{
			numbers[i] = 11;
		}
		PutCardImage (); 
	}
	public void PutCardImage ()
	{
		for (int i = 0; i < MAX; i++) {

			random = Random.Range (0, cards.Count);
			int random2 = Random.Range (0, cards.Count);
			
			if (random2 == random) {
				random2 = Random.Range (0, cards.Count);
				i -= 1;
			} else {
				int animal = random;
				int habitat = random2;
				
				if (cards [animal].valueNull && 
					cards [habitat].valueNull) {
					SortImagePar (animal, habitat, cards, numbers);
				} else {
					random = Random.Range (0, cards.Count);
					random2 = Random.Range (0, cards.Count);
					i -= 1;
				}
			}
		}
	}
	void SortImagePar (int animals, int places, List<CardObject> cartas, int[] num)
	{

		bool notEqual = true;
		int map;
		randomSprite = Random.Range (0, 10);
		if(numbers[0] == 11)
		{
			numbers[0] = randomSprite;
			notEqual = false;
		}
		else
		{
			for (int i = 0; i < 10000; i++) 
			{

				if(randomSprite != numbers[0] && randomSprite != numbers[1] && randomSprite != numbers[2] && 
				randomSprite != numbers[3] && randomSprite != numbers[4] && randomSprite != numbers[5] &&
				randomSprite != numbers[6] && randomSprite != numbers[7] && randomSprite != numbers[8] &&
				randomSprite != numbers[9])
				{
					numbers [mapX] = randomSprite;
					mapX++;
					notEqual = false;
					break;
				}
				else
				{
					randomSprite = Random.Range (0,10);
				}
			}
		
		}
		if(!notEqual) 
		{
			cartas [animals].thisSprite = imagesAnimals [randomSprite];
			cartas [places].thisSprite = imagesPlaces [randomSprite];
			cartas [animals].index = randomSprite + 1;
			cartas [places].index = randomSprite + 1;
			cartas [animals].valueNull = false;
			cartas [places].valueNull = false;
		}
			
	} 
}
