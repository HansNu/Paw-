using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class characterselection : MonoBehaviour {
	public Button spaceCatButton;
	public Button cowboyCatButton;
	public Button ninjaCatButton;
	public Button luckyCatButton; 
	public Button confirmButton;
	public Button startButton;
	int temporalSelection = 0;
	string [] characterSelectionArray = new string[4] {"Space Cat", "Cowboy Cat", "Ninja Cat", "Lucky Cat"};
	string[] characterSelectedArray = new string[4] {"No", "No", "No", "No"};
	int numberOfPlayers = 1; 
	string Player_1, Player_2, Player_3, Player_4;

	//temporalmente pone al space cat como el elegido
	void spaceCatTemporal() {
		temporalSelection = 1;
		Debug.Log ("funciona");
	}

	//temporalmente pone al cowboy cat como el elegido
	void cowboyCatTemporal() {
		temporalSelection = 2;
		Debug.Log ("funciona x2");
	}

	//temporalmente pone al ninja cat como el elegido
	void ninjaCatTemporal() {
		temporalSelection = 3;
		Debug.Log ("funciona x3");
	}

		//temporalmente pone al lucky cat como el elegido
		void luckyCatTemporal() {
			temporalSelection = 4;
			Debug.Log ("funciona x4");
		}

	//toma el personaje escogido del array y lo asigna al numero del jugador
	void characterAssignation(){
		if (numberOfPlayers == 1) {
			Player_1 = characterSelectionArray [temporalSelection - 1];
			numberOfPlayers++;
			characterSelectedArray [0] = Player_1;
			Debug.Log("sigue funcionando");
		}
		else if (numberOfPlayers == 2) {
			Player_2 = characterSelectionArray [temporalSelection - 1];
			numberOfPlayers++;
			startButton.interactable = true;
			characterSelectedArray [1] = Player_2; 
			Debug.Log("sigue funcionando x2");
		}
		else if (numberOfPlayers == 3) {
			Player_3 = characterSelectionArray [temporalSelection - 1];
			numberOfPlayers++;
			characterSelectedArray [2] = Player_3; 
			Debug.Log("sigue funcionando x3");
		}
		else {
			Player_4 = characterSelectionArray [temporalSelection - 1];
			numberOfPlayers++;
			characterSelectedArray [3] = Player_4; 
			Debug.Log("sigue funcionando x4");
		}
			
	}
	//pasa los valores de los jugadores para poder comenzar el juego
	void passValues()
	{
		SceneManager.LoadScene ("actualgametest");
		Debug.Log ("number of players " + (numberOfPlayers - 1));
		for (int i = 0; i < 4; i++) {
			Debug.Log (characterSelectedArray[i]);
		}
		numberOfPlayers = 1;
	}

	// Use this for initialization
	void Start () {




		//boton para space cat
		Button spaceCatSelection = spaceCatButton.GetComponent<Button> ();
		spaceCatSelection.onClick.AddListener (spaceCatTemporal);

		//boton para cowboy cat
		Button cowboyCatSelection = cowboyCatButton.GetComponent<Button> ();
		cowboyCatSelection.onClick.AddListener (cowboyCatTemporal);

		//boton para ninja cat
		Button ninjaCatSelection = ninjaCatButton.GetComponent<Button> ();
		ninjaCatSelection.onClick.AddListener (ninjaCatTemporal);

		//boton para lucky cat
		Button luckyCatSelection = luckyCatButton.GetComponent<Button> ();
		luckyCatSelection.onClick.AddListener (luckyCatTemporal);

	
		//boton para confirmar el personaje 
		Button confirmSelection = confirmButton.GetComponent<Button> ();
		confirmSelection.onClick.AddListener (characterAssignation);

		//boton para empezar el juego
		Button startGame = startButton.GetComponent<Button> ();
		startGame.onClick.AddListener (passValues);



	}
	

}
