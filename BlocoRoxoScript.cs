using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocoRoxoScript : MonoBehaviour {

	private GameManager gameManager;
	[SerializeField]
	private BoxCollider2D myCollider2D; 

	void Awake (){
		gameManager = FindObjectOfType<GameManager>();
	}

	void OnTriggerEnter2D(){
		GetComponent <SpriteRenderer> ().color = Color.yellow;
		gameManager.points += 10;
		myCollider2D.enabled = false;
	}
}
