using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cell : MonoBehaviour {

	public Camera cameraMain;
	public GameObject lost; //Панель выигрыша
	public Text playerText; //Текст с именем победителя
	public Sprite tic; // Спрайт крестика 
	public Sprite toe; // Спрайт нолика
	public static bool Turn = true; // Очередность хода
	public GameObject cell1; //Ячейка 1
	public GameObject cell2; //Ячейка 2
	public GameObject cell3; //Ячейка 3
	public GameObject cell4; //Ячейка 4
	public GameObject cell5; //Ячейка 5
	public GameObject cell6; //Ячейка 6
	public GameObject cell7; //Ячейка 7
	public GameObject cell8; //Ячейка 8
	public GameObject cell9; //Ячейка 9
	private List<SpriteRenderer> filledCells; // Список заполненных спрайтами ячеек
	private List<GameObject> tempList; //Список всех ячеек
	public static bool player1; // Переменная, меняющаяся при выигрыше 1 игрока
	public static bool player2; // Переменная, меняющаяся при выигрыше 2 игрока
	public static bool end; // Переменная конца игры. True, если игра окончена.



	void Start(){

		Turn = true;
		end = false;

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

		if(end == false){

		if (Input.GetMouseButtonDown (0)) {
			if (Turn == true) {
				Player ();
				checkWinner ();
			} else if (Turn == false) {
				Player2 ();
				checkWinner ();
			}
		}

			if (Input.GetKeyDown(KeyCode.Escape)) 
			{
				SceneManager.LoadScene ("main"); 
			}
		}
			
	}

	void Player(){
		Vector2 clickPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		RaycastHit2D hit = Physics2D.Raycast(clickPoint, Vector2.zero);

		if (hit.collider){

			Transform hitCell = hit.transform;

			if (!hitCell.GetComponent<SpriteRenderer>().sprite){
					hitCell.GetComponent<SpriteRenderer>().sprite = tic;
				Turn = false;
			}
		}
	}

	void Player2(){
		Vector2 clickPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		RaycastHit2D hit = Physics2D.Raycast(clickPoint, Vector2.zero);

		if (hit.collider){

			Transform hitCell = hit.transform;

			if (!hitCell.GetComponent<SpriteRenderer>().sprite && !gameObject.name.Equals("Home") && !gameObject.name.Equals("reset")){
				hitCell.GetComponent<SpriteRenderer>().sprite = toe;
				Turn = true;
			}
		}
	}

	void checkWinner(){



		if (filledCells[0].sprite == tic && filledCells[1].sprite == tic && filledCells[2].sprite == tic //Проверка победы крестиков
			|| filledCells[0].sprite == tic && filledCells[3].sprite == tic && filledCells[6].sprite == tic
			|| filledCells[6].sprite == tic && filledCells[7].sprite == tic && filledCells[8].sprite == tic
			|| filledCells[8].sprite == tic && filledCells[5].sprite == tic && filledCells[2].sprite == tic
			|| filledCells[0].sprite == tic && filledCells[4].sprite == tic && filledCells[8].sprite == tic
			|| filledCells[2].sprite == tic && filledCells[4].sprite == tic && filledCells[6].sprite == tic
			|| filledCells[3].sprite == tic && filledCells[4].sprite == tic && filledCells[5].sprite == tic
			|| filledCells[1].sprite == tic && filledCells[4].sprite == tic && filledCells[7].sprite == tic){
			player1 = true;
			end = true;
			win ();
		} else if (filledCells[0].sprite == toe && filledCells[1].sprite == toe && filledCells[2].sprite == toe //Проверка победы ноликов
			|| filledCells[0].sprite == toe && filledCells[3].sprite == toe && filledCells[6].sprite == toe
			|| filledCells[6].sprite == toe && filledCells[7].sprite == toe && filledCells[8].sprite == toe
			|| filledCells[8].sprite == toe && filledCells[5].sprite == toe && filledCells[2].sprite == toe
			|| filledCells[0].sprite == toe && filledCells[4].sprite == toe && filledCells[8].sprite == toe
			|| filledCells[2].sprite == toe && filledCells[4].sprite == toe && filledCells[6].sprite == toe
			|| filledCells[3].sprite == toe && filledCells[4].sprite == toe && filledCells[5].sprite == toe
			|| filledCells[1].sprite == toe && filledCells[4].sprite == toe && filledCells[7].sprite == toe){
			player2 = true;
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
		if (player1 == true) {
			playerText.text = "Крестики победили!";
			lost.SetActive (true);
		} else if (player2 == true) {
			playerText.text = "Нолики победили!";
			lost.SetActive (true);
		}
	}
}