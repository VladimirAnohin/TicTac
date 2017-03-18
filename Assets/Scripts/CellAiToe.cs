using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CellAiToe : MonoBehaviour {

	public Camera cameraMain;
	public GameObject lost;
	public Text playerText;
	public Sprite tic;
	public Sprite toe;
	int rand;
	public static bool Turn = true;
	public static bool end = false;
	public GameObject cell1;
	public GameObject cell2;
	public GameObject cell3;
	public GameObject cell4;
	public GameObject cell5;
	public GameObject cell6;
	public GameObject cell7;
	public GameObject cell8;
	public GameObject cell9;
	private List<SpriteRenderer> filledCells;
	private List<GameObject> tempList;
	public static bool player1 = false; // Переменная, меняющаяся при выигрыше 1 игрока
	public static bool player2 = false; // Переменная, меняющаяся при выигрыше 2 игрока


	void Start(){
		filledCells = new List<SpriteRenderer>();
		tempList = new List<GameObject> ();
		tempList.Add (cell1);
		tempList.Add (cell2);
		tempList.Add (cell3);
		tempList.Add (cell4);
		tempList.Add (cell5);
		tempList.Add (cell6);
		tempList.Add (cell7);
		tempList.Add (cell8);
		tempList.Add (cell9);


		foreach (GameObject obj in tempList){
			filledCells.Add(obj.GetComponent<SpriteRenderer>());
		}
	}



	void Update(){
		if (!end) {
			TurnAi ();
			checkWinner ();
			if (Input.GetMouseButtonDown (0)) {
				if (Turn == false) {
					Player ();
					checkWinner ();
				}
			}
		}

	}

	void Player(){
		Vector2 clickPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		RaycastHit2D hit = Physics2D.Raycast(clickPoint, Vector2.zero);

		if (hit.collider){

			Transform hitCell = hit.transform;

			if (!hitCell.GetComponent<SpriteRenderer>().sprite){
				hitCell.GetComponent<SpriteRenderer>().sprite = toe;
				Turn = true;
			}
		}
	}

	void TurnAi(){
		while (Turn == true){

			rand = Random.Range(0, 10);

			if (filledCells[rand].GetComponent<SpriteRenderer>().sprite == null){
				filledCells [rand].GetComponent<SpriteRenderer>().sprite = tic;

				Turn = false;
			}



		}
	}




	void checkWinner(){
		filledCells = new List<SpriteRenderer>();
		tempList = new List<GameObject> ();

		tempList.Add (cell1);
		tempList.Add (cell2);
		tempList.Add (cell3);
		tempList.Add (cell4);
		tempList.Add (cell5);
		tempList.Add (cell6);
		tempList.Add (cell7);
		tempList.Add (cell8);
		tempList.Add (cell9);


		foreach (GameObject obj in tempList){
			filledCells.Add(obj.GetComponent<SpriteRenderer>());
		}


		if (filledCells [0].sprite == tic && filledCells [1].sprite == tic && filledCells [2].sprite == tic
			|| filledCells [0].sprite == tic && filledCells [3].sprite == tic && filledCells [6].sprite == tic
			|| filledCells [6].sprite == tic && filledCells [7].sprite == tic && filledCells [8].sprite == tic
			|| filledCells [8].sprite == tic && filledCells [5].sprite == tic && filledCells [2].sprite == tic
			|| filledCells [0].sprite == tic && filledCells [4].sprite == tic && filledCells [8].sprite == tic
			|| filledCells [2].sprite == tic && filledCells [4].sprite == tic && filledCells [6].sprite == tic
			|| filledCells [3].sprite == tic && filledCells [4].sprite == tic && filledCells [5].sprite == tic
			|| filledCells [1].sprite == tic && filledCells [4].sprite == tic && filledCells [7].sprite == tic) {
			player2 = true;
			end = true;
			win ();
		} else if (filledCells [0].sprite == toe && filledCells [1].sprite == toe && filledCells [2].sprite == toe
			|| filledCells [0].sprite == toe && filledCells [3].sprite == toe && filledCells [6].sprite == toe
			|| filledCells [6].sprite == toe && filledCells [7].sprite == toe && filledCells [8].sprite == toe
			|| filledCells [8].sprite == toe && filledCells [5].sprite == toe && filledCells [2].sprite == toe
			|| filledCells [0].sprite == toe && filledCells [4].sprite == toe && filledCells [8].sprite == toe
			|| filledCells [2].sprite == toe && filledCells [4].sprite == toe && filledCells [6].sprite == toe
			|| filledCells [3].sprite == toe && filledCells [4].sprite == toe && filledCells [5].sprite == toe
			|| filledCells [1].sprite == toe && filledCells [4].sprite == toe && filledCells [7].sprite == toe) {
			player1 = true;
			end = true;
			win ();
		} else if (filledCells[0].sprite != null && filledCells[1].sprite != null && filledCells[2].sprite != null && //Проверка ничьи
			filledCells[3].sprite != null && filledCells[4].sprite != null && filledCells[5].sprite != null &&
			filledCells[6].sprite != null && filledCells[7].sprite != null && filledCells[8].sprite != null){
			playerText.text = "Ничья!";
			lost.SetActive (true);
		}
	}

	public void win(){
		if (player2 == true) {
			playerText.text = "Крестики победили!";
			lost.SetActive (true);
		} else if (player1 == true) {
			playerText.text = "Нолики победили!";
			lost.SetActive (true);
		}
	}

}
