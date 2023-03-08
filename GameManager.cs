using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	[SerializeField]
	private GameObject blockPrefab;
	[SerializeField]
	private GameObject block2Prefab;
	[SerializeField]
	private GameObject PlayerPrefab;
	[SerializeField]
	private Transform blocksHolder;

	public int points = 0;

	private int[,] tileMatrix = {
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
		{ 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0},
		{ 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0},
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
		{ 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0},
		{ 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0},
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
		{ 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0},
		{ 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0},
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
		{ 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0},
		{ 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0},
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},

	};

	void Update (){
		print (points);
	}

	void Start () {
		for (int i = 0; i < tileMatrix.GetLength(0); i++) {
			for (int j = 0; j < tileMatrix.GetLength(1); j++) {
			
				switch (tileMatrix [i, j]) {
					case 1:
						Instantiate (
							blockPrefab, 
							new Vector2 (-tileMatrix.GetLength (1) / 2f + j + 0.5f, tileMatrix.GetLength (0) / 2f - i - 0.5f), 
							Quaternion.identity, 
							blocksHolder
						);
						break;
					case 9:
						GameObject player = Instantiate (
							PlayerPrefab, 
							new Vector2 (-tileMatrix.GetLength (1) / 2f + j + 0.5f, tileMatrix.GetLength (0) / 2f - i - 0.5f), 
							Quaternion.identity
						);
					Instantiate (
						block2Prefab, 
						new Vector2 (-tileMatrix.GetLength (1) / 2f + j + 0.5f, tileMatrix.GetLength (0) / 2f - i - 0.5f), 
						Quaternion.identity,
						blocksHolder
					);
					player.GetComponent<PlayerScript> ().SetArrayPosition (i, j);
						break;
					case 0:
						Instantiate (
							block2Prefab, 
							new Vector2 (-tileMatrix.GetLength (1) / 2f + j + 0.5f, tileMatrix.GetLength (0) / 2f - i - 0.5f), 
							Quaternion.identity,
							blocksHolder
						);
						break;
				}
			}
		}
	}

	public bool IsEmptyPosition(int i, int j) {
        if (i<0 || i >= tileMatrix.GetLength(0) || j<0 || j >= tileMatrix.GetLength(1)){
            return false;
        }
		return tileMatrix [i, j] != 1;
	}

}
