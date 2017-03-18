using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Count2 : MonoBehaviour {

	private int score;

	void Update(){
		if (Cell.player2 == true){
			score++;
			GetComponent<Text> ().text = score.ToString();
			Cell.player2 = false;
		} else if (CellAi.player2 == true){
			score++;
			GetComponent<Text> ().text = score.ToString();
			CellAi.player2 = false;

		}  else if (CellAiToe.player1 == true){
			score++;
			GetComponent<Text> ().text = score.ToString();
			CellAiToe.player1 = false;

		}
	}

}
