using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	[SerializeField]
	private Animator animator;

	private Direction nextDirection = Direction.Down;
	private Direction actualDirection = Direction.Down;
	private Vector3 targetPosition;
	private float speed = 5f;
		
	private int myArrayPositionI;
	private int myArrayPositionJ;

	private GameManager gameManager;

    private bool wrongTry = true;

	void Start () {
		gameManager = FindObjectOfType<GameManager> ();
		targetPosition = transform.position;
	}

    void Update() {

        float horizontalMove = Input.GetAxisRaw("Horizontal");
        float verticalMove = Input.GetAxisRaw("Vertical");

        if (horizontalMove == 1) {
            //Movimento para a Direita
            nextDirection = Direction.Right;
            speed = 5f;


        } else if (horizontalMove == -1) {
            //Movimento para a Esquerda
            nextDirection = Direction.Left;
            speed = 5f;

        } else if (verticalMove == 1) {
            //Movimento para Cima
            nextDirection = Direction.Up;
            speed = 5f;

        } else if (verticalMove == -1) {
            //Movimento para Baixo
            nextDirection = Direction.Down;
            speed = 5f;

        } else {
            //Parado
            speed = 0;
        }

        switch (nextDirection)
        {
            case Direction.Right:
                if (gameManager.IsEmptyPosition(myArrayPositionI, myArrayPositionJ + 1))
                    wrongTry = true;
                else
                    wrongTry = false;
                break;
            case Direction.Left:
                if (gameManager.IsEmptyPosition(myArrayPositionI, myArrayPositionJ - 1))
                    wrongTry = true;
                else
                    wrongTry = false;
                break;
            case Direction.Up:
                if (gameManager.IsEmptyPosition(myArrayPositionI - 1, myArrayPositionJ))
                    wrongTry = true;
                else
                    wrongTry = false;
                break;
            case Direction.Down:
                if (gameManager.IsEmptyPosition(myArrayPositionI + 1, myArrayPositionJ))
                    wrongTry = true;
                else
                    wrongTry = false;
                break;
        }

        if (transform.position != targetPosition && speed != 0) {
            switch (actualDirection) {
                case Direction.Right:
                    animator.SetTrigger("Right");
                    break;
                case Direction.Left:
                    animator.SetTrigger("Left");
                    break;
                case Direction.Up:
                    animator.SetTrigger("Up");
                    break;
                case Direction.Down:
                    animator.SetTrigger("Down");
                    break;
            }
        }

        else if (speed == 0 || (transform.position == targetPosition && wrongTry == false)) { 
            animator.SetTrigger("Stop");
        }

		Move ();
	}

	void Move (){
		if (nextDirection == Direction.Left && actualDirection == Direction.Right) {
			actualDirection = nextDirection;
			myArrayPositionJ--;
			targetPosition.x--;
		}
		if (nextDirection == Direction.Right && actualDirection == Direction.Left) {
			actualDirection = nextDirection;
			myArrayPositionJ++;
			targetPosition.x++;
		}
		if (nextDirection == Direction.Up && actualDirection == Direction.Down && gameManager.IsEmptyPosition(myArrayPositionI+1,myArrayPositionJ)) {
			actualDirection = nextDirection;
			myArrayPositionI--;
			targetPosition.y++;
		}
		if (nextDirection == Direction.Down && actualDirection == Direction.Up) {
			actualDirection = nextDirection;
			myArrayPositionI++;
			targetPosition.y--;
		}

		if (transform.position == targetPosition) {
			switch (nextDirection) {
			case(Direction.Right):
				if(gameManager.IsEmptyPosition(myArrayPositionI,myArrayPositionJ+1)){
			        actualDirection = nextDirection;
					targetPosition.x++;
					myArrayPositionJ++;
				}
				break;
			case(Direction.Up):
					if(gameManager.IsEmptyPosition(myArrayPositionI-1,myArrayPositionJ)){
                        actualDirection = nextDirection;
                        targetPosition.y++;
					    myArrayPositionI--;
					}
				break;
			case(Direction.Down):
					if(gameManager.IsEmptyPosition(myArrayPositionI+1,myArrayPositionJ)){
                       actualDirection = nextDirection;
                       targetPosition.y--;
			    	   myArrayPositionI++;
					}
				break;
			case(Direction.Left):
					if(gameManager.IsEmptyPosition(myArrayPositionI,myArrayPositionJ-1)){
                        actualDirection = nextDirection;
                        targetPosition.x--;
					    myArrayPositionJ--;
				}
				break;

			}
		}
		transform.position = Vector3.MoveTowards (transform.position, targetPosition, Time.deltaTime * speed);

	}

	public void SetArrayPosition (int i, int j){
		myArrayPositionI = i;
		myArrayPositionJ = j;
	}
		
}
