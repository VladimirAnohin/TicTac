using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Count : MonoBehaviour {

	private int score;

	void Update(){
		if (Cell.player1 == true){
			score++;
			GetComponent<Text> ().text = score.ToString();
			Cell.player1 = false;
		} else if (CellAi.player1 == true){
			score++;
			GetComponent<Text> ().text = score.ToString();
			CellAi.player1 = false;

		} else if (CellAiToe.player2 == true){
			score++;
			GetComponent<Text> ().text = score.ToString();
			CellAiToe.player2 = false;

		}
	}

}
