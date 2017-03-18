using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class UnityAdsExample : MonoBehaviour
{
	public void ShowAd()
	{
		if (Advertisement.IsReady())
		{
			Advertisement.Show();
		}
	}
}

public class ButtonPlay : MonoBehaviour {

	public Sprite circleBlue, circleRed;
	public GameObject Switch, Lost, Info, Select;
	public GameObject cell1;
	public GameObject cell2;
	public GameObject cell3;
	public GameObject cell4;
	public GameObject cell5;
	public GameObject cell6;
	public GameObject cell7;
	public GameObject cell8;
	public GameObject cell9;
	private List<GameObject> tempList;

	public void ShowAd()
	{
		if (Advertisement.IsReady())
		{
			Advertisement.Show();
		}
	}

	void OnMouseDown(){
		GetComponent <SpriteRenderer> ().sprite = circleBlue;
	}

	void OnMouseUp(){
		GetComponent <SpriteRenderer> ().sprite = circleRed;
	}

	void OnMouseUpAsButton(){

		switch(gameObject.name){
		case "Play":
			if (Info.activeInHierarchy == false && Select.activeInHierarchy == false) {
				Switch.SetActive (true);
			}
			break;

		case "home": 
			SceneManager.LoadScene ("main");
			break;
		case "pvp":
			ShowAd ();
			SceneManager.LoadScene ("play");
			break;
		case "pve":
			if (Info.activeInHierarchy == false && Switch.activeInHierarchy == true) {
				Select.SetActive (true);
				Switch.SetActive (false);
			}
			break;
		case "reset2":
			SceneManager.LoadScene ("play_ai");
			break;
		case "reset":
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


			foreach (GameObject obj in tempList) {
				obj.GetComponent<SpriteRenderer> ().sprite = null;
			}

			Lost.SetActive (false);
			Cell.end = false;
			Cell.Turn = true;
			CellAi.end = false;
			CellAi.Turn = true;
			CellAiToe.end = false;
			CellAiToe.Turn = true;
			break;
		case "Home":
			SceneManager.LoadScene ("main");
			break;
		case "Back":
			Switch.SetActive (false);
			break;
		case "Info":
			if(Switch.activeInHierarchy == false && Select.activeInHierarchy == false){
			Info.SetActive (true);
			}
			break;
		case "Tic":
			SceneManager.LoadScene ("play_ai");
			break;
		case "Toe":
			SceneManager.LoadScene ("play_ai_toe");
			break;
		}
	}

	void Update(){
		if (Input.GetKeyDown(KeyCode.Escape)) 
		{
			SceneManager.LoadScene ("main");
			Cell.end = false;
			CellAi.end = false;
			Cell.Turn = true;
		}
	}

}
