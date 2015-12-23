using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	
	int gridWidth = 8;
	int gridHeight = 5;
	
	public GameObject baseCube;
	public static GameObject[,] GridCubes;
	public CubeBehavior cubeClicked;
	public GameObject nextCube;
	public Color cubeColor;
	int[] colorArray;
	public bool activeCube; 
	public bool clickedACube;

	public bool keyPressed = false;
	public float timeInGame = 0f;
	
	public bool newTurn = false;
	
	public float gameEndTime = 60f;
	
	public bool gameOver = false;
	public int nextCubeX = -3;
	public int nextCubeY = 5;
	
	public Text timeUI; 
	public Text scoreUI;
	public Text gameOverUI;
	public int score = 0;
	public float turnLength = 2.0f;
	public float timeToAct = 0;
	
	public int[] randomRow;
	
	public bool cubeInPlace;
	public bool foundWhiteCube;

	int cubeClickedX;
	int cubeClickedY;
	
	//scoring
	int samePlusPoints = 10;
	int rainbowPlusPoints= 5;
	
	
	//make cube activate
	public void CubeClicked()
	{
		if (cubeClicked.activeCube == false && cubeClicked.isColored == true) {

			cubeClicked.transform.localScale += new Vector3 (0.2f, 0.2f, 0.2f);
			cubeClicked.activeCube = true;

		}
	}

	public void UnClickCube(){

		if (cubeClicked.activeCube == true && cubeClicked.isColored == true) {

			cubeClicked.transform.localScale -= new Vector3(0.2, 0.2, 0.2);
			cubeClicked.activeCube = false;

		}

	}
	
	/**
a) Player clicks a colored cube. It activates.
b) Player clicks an adjacent white cube. The colored cube and the white cube swap, and the colored cube remains active.
c) Player clicks a colored cube. The recently-clicked colored cube becomes active.
d) Player clicks a far-away white cube. Nothing happens.
e) Player clicks a black cube. Nothing happens.
f) Player clicks the currently active cube. It deactivates.
	**/
	
	public static void ProcessClickedCube(int x, int y)
	{
		if(cubeClicked.isColored == true && x == cubeClickedX && cubeClickedY == y) {

			CubeClicked();

			if (cubeClicked != null) {

				cubeClicked.transform.localScale = new Vector3(1, 1, 1);
				cubeClicked.activeCube = false;

			}

			cubeClicked = cubeClicked;

		}

		if(GridCubes[cubeClickedX + 1, cubeClickedY].GetComponent<Renderer>.Color.white)
		{ 

			MakeCubeWhite(cubeClickedX, cubeClickedY);

		}
			else if (cubeClicked.activeCube == true) {
				
			UnClickCube(cubeClicked);

		}
	
		 if (IsAdjacent(true))
			{
				
			CubeClicked(cubeClicked);

				cubeClicked.GetComponent<Renderer> ().material.color = cubeClicked.GetComponent<Renderer> ().material.color;
				MakeCubeWhite(cubeClicked);

				cubeClicked.transform.localScale = new Vector3(1, 1, 1);
				cubeClicked.activeCube = false;

		}
	} 

		public bool IsAdjacent( int x, int y){

			bool isAdjacent;

		if (((cubeClickedX + 1 == x || cubeClickedX - 1) && cubeClickedY == y) || (cubeClickedX == x && (cubeClickedY + 1 == y || cubeClickedY == - 1)))
		{
				
				isAdjacent = true;

		} else {

				isAdjacent = false;

		}
	}
			//keyboard input
		void KeyInput () {
			
		int row; 
		int col;
			
		for (row = 0; row <gridWidth; row++) { 
				
			if (Input.GetKeyDown ("1")) {

				if (GridCubes [row, 1].GetComponent<Renderer> ().material.color != Color.white) {
					//ENDGAME!
					gameOverUI.text = "GAME OVER";
					keyPressed = true;
				} else {
					if (GridCubes [randomRow, 1].GetComponent<Renderer> ().material.color != Color.white) {
						while (GridCubes[randomRow,1].GetComponent<Renderer> ().material.color != Color.white) {
							randomRow = Random.Range (0, 8);

						}
					}
					GridCubes [randomRow, 1].GetComponent<Renderer> ().material.color = colorArray [Random.Range (0, 5)];
					cubeInPlace = true;
					nextCube.GetComponent<Renderer> ().material.color = Color.grey;
					keyPressed = true;
				}
			}
			if (Input.GetKeyDown ("2")) {
				if (GridCubes [row, 2].GetComponent<Renderer> ().material.color != Color.white) {
					//ENDGAME!
					gameOverUI.text = "GAME OVER";
				} else {
					if (GridCubes [randomRow, 2].GetComponent<Renderer> ().material.color != Color.white) {
						while (GridCubes[randomRow,2].GetComponent<Renderer> ().material.color != Color.white) {
							randomRow = Random.Range (0, 8);
						}
					}
					GridCubes [randomRow, 2].GetComponent<Renderer> ().material.color = colorArray [Random.Range (0, 5)];
					cubeInPlace = true;
					nextCube.GetComponent<Renderer> ().material.color = Color.grey;
					keyPressed = true;
				}
			}
			if (Input.GetKeyDown ("3")) {
				if (GridCubes [row, 3].GetComponent<Renderer> ().material.color != Color.white) {
					//ENDGAME!
					gameOverUI.text = "GAME OVER";
					keyPressed = true;
				} else {
					if (GridCubes [randomRow, 3].GetComponent<Renderer> ().material.color != Color.white) {
						while (GridCubes[randomRow, 3].GetComponent<Renderer> ().material.color != Color.white) {
							randomRow = Random.Range (0, 8);
						}
					}
					GridCubes [randomRow, 3].GetComponent<Renderer> ().material.color = colorArray [Random.Range (0, 5)];
					cubeInPlace = true;
					nextCube.GetComponent<Renderer> ().material.color = Color.grey;
					keyPressed = true;
				}

			}
			if (Input.GetKeyDown ("4")) {
				if (GridCubes [row, 1].GetComponent<Renderer> ().material.color != Color.white) {
						
					gameOverUI.text = "GAME OVER";
						
				} else {
					if (GridCubes [randomRow, 4].GetComponent<Renderer> ().material.color != Color.white) {
						while (GridCubes[randomRow,4].GetComponent<Renderer> ().material.color != Color.white) {
							randomRow = Random.Range (0, 8);
						}
					}
					GridCubes [randomRow, 4].GetComponent<Renderer> ().material.color = colorArray [Random.Range (0, 5)];
					cubeInPlace = true;
					nextCube.GetComponent<Renderer> ().material.color = Color.grey;
				}
			}
			if (Input.GetKeyDown ("5")) {
				if (GridCubes [row, 5].GetComponent<Renderer> ().material.color != Color.white) {
					gameOverUI.text = "GAME OVER";
						
				} else {
					if (GridCubes [randomRow, 5].GetComponent<Renderer> ().material.color != Color.white) {
						while (GridCubes[randomRow, 5].GetComponent<Renderer> ().material.color != Color.white) {
							randomRow = Random.Range (0, 8);
						}
					}
					GridCubes [randomRow, 5].GetComponent<Renderer> ().material.color = colorArray [Random.Range (0, 5)];
					cubeInPlace = true;
					nextCube.GetComponent<Renderer> ().material.color = Color.grey;
				}
			}
				
			if (!Input.anyKey) {

				print ("no Key Input");

			}

		}
	}		
			
			void ChangeColor(int x, int y){

			if (cubeClicked.GetComponent<Renderer>().material.color != Color.white) {
				cubeColor = GridCubes[x,y].GetComponent<Renderer>().material.color;
				cubeClicked.GetComponent<Renderer>().material.color = Color.white;
				GridCubes[x,y].GetComponent<CubeBehavior>().isColored = true; 
			}
		}
			
			
		void NewRandomColorCube(){
				
			nextCube = (GameObject)Instantiate (nextNewCube,new Vector3 (nextCubeX,nextCubeY,10), Quaternion.identity) as GameObject;
			nextCube.GetComponent<Renderer>().material.color = plusColors[Random.range(plusColors.length)];
					
		}
			
			
			
			bool CheckForColorPlus (int x, int y) { 
				
				//check for 5 cubes of the same color in a + configuration
				Color targetColor = GridCubes [x,y].GetComponent<Renderer>().material.color;
				
				//error
				if (targetColor == Color.white || targetColor == Color.black) {
					
					return false;

				}
				
				//negative values cause crash
				if (targetColor == GridCubes[x,y+1].GetComponent<Renderer>().material.color && 
				    targetColor == GridCubes[x,y-1].GetComponent<Renderer>().material.color &&
				    targetColor == GridCubes[x+1,y].GetComponent<Renderer>().material.color &&
				    targetColor == GridCubes[x-1,y].GetComponent<Renderer>().material.color) {
					
					return true;
					
					samePlusPoints++;
					MakePlusBlack();
					
				}
				
				return false;
				
			}
			
			bool ColorMatch (Color color1, Color color2, Color color3, Color color4, Color color5, Color targetColor)
			{
				if (color1 == targetColor ||
				    color2 == targetColor ||
				    color3 == targetColor ||
				    color4 == targetColor ||
				    color5 == targetColor) {
					
					return true;
				}
				
				return false; 
				
			}
			
			int ColorValue(Color myColor){
				
				if (myColor == Color.red) {
					return 1;
				}
				if (myColor == Color.blue) {
					return 10;
				}
				if (myColor == Color.green) {
					return 100;
					
				}
				if (myColor == Color.yellow) {
					
					return 1000;
					
				}
				if (myColor == Color.magenta) {
					
					return 10000;
				}
				
				return 0;
			}
			
			
			
	bool CheckForRainbowPlus(int x, int y)
	{
				int myColorTotal = 0;
				
				myColorTotal += ColorValue(GridCubes [x, y].GetComponent<Renderer> ().material.color);
				myColorTotal += ColorValue(GridCubes [x, y+1].GetComponent<Renderer> ().material.color);
				myColorTotal += ColorValue(GridCubes [x, y-1].GetComponent<Renderer> ().material.color);
				myColorTotal += ColorValue(GridCubes [x+1, y].GetComponent<Renderer> ().material.color);
				myColorTotal += ColorValue(GridCubes [x-1, y].GetComponent<Renderer> ().material.color);
				
				if(myColorTotal == 11111)
				{
					return true;
					MakePlusBlack();
					
				}
				
				return false;
				
	}
			
			
		
		public void MakePlusBlack (int x, int y)
		{

			GridCubes[x, y].GetComponent<Renderer>().material.color = Color.black;
			GridCubes[x,y].GetComponent<CubeBehavior>().activeCube = false;
			GridCubes[x,y].GetComponent<CubeBehavior>().isColored = false; 

			GridCubes[x, y + 1].GetComponent<Renderer>().material.color = Color.black;
			GridCubes[x, y + 1].GetComponent<CubeBehavior>().activeCube = false;
			GridCubes[x, y + 1].GetComponent<CubeBehavior>().isColored = false;

			GridCubes[x + 1,y].GetComponent<Renderer>().material.color = Color.black;
			GridCubes[x + 1,y].GetComponent<CubeBehavior>().activeCube = false;
			GridCubes[x + 1,y].GetComponent<CubeBehavior>().isColored = false;

			GridCubes[x - 1,y].GetComponent<Renderer>().material.color = Color.black;
			GridCubes[x - 1,y].GetComponent<CubeBehavior>().activeCube = false;
			GridCubes[x - 1,y].GetComponent<CubeBehavior>().isColored = false;

			GridCubes[x,y - 1].GetComponent<Renderer>().material.color = Color.black;
			GridCubes[x,y - 1].GetComponent<CubeBehavior>().activeCube = false;
			GridCubes[x,y - 1].GetComponent<CubeBehavior>().isColored = false;

		}


		
		void MakeCubeWhite (int whiteCubeX,int whiteCubeY)
		{
			
			GridCubes[whiteCubeX,whiteCubeY].gameObject.transform.localScale = new Vector3(1,1,1);
			GridCubes[whiteCubeX,whiteCubeY].GetComponent<Renderer> ().material.color = Color.white ;
			GridCubes[whiteCubeX,whiteCubeY].GetComponent<CubeBehavior>().activeCube = false;
			GridCubes[whiteCubeX,whiteCubeY].GetComponent<CubeBehavior>().isColored = false; 
			
		} 
		
		
		//checks for pluses and if it finds them turn them black 
		void WinPlus () {
			
			for (int x = 1; x < gridWidth-1; x++) {
				for (int y = 1; y < gridHeight-1; y++) {
					if(CheckForRainbowPlus(x,y)){
						MakePlusBlack(x,y);
						
						score += 5;
					}
					if(CheckForColorPlus(x,y)){
						MakePlusBlack(x,y);

						score += 10;
					}
				}
			}
		}
		//Turns a random cube black 
		public void makeRandomCubeBlack(int randomRow,int randomCol) 
		{
			
			int numBlackCubes = 0; 
			
			for (int x = 0; x < gridWidth;x++) {
				for (int y = 0; y < gridHeight;y++){
					
					if (GridCubes[x,y].GetComponent<CubeBehavior> ().blackCube == false) {
						
						numBlackCubes++; 
					}
					
				}
			}
			
			if (numBlackCubes == (gridWidth * gridHeight)) {
				notEnoughBlackCubes = false;
				gameOver = true; 
			}
			
			while (notEnoughBlackCubes == false) {
				
				if (GridCubes[randomRow,randomCol].GetComponent<CubeBehavior> ().blackCube == false && GridCubes[randomRow,randomCol].GetComponent<CubeBehavior> ().isColored == true) {

					GridCubes[randomRow, randomCol].GetComponent<Renderer>().material.color = Color.black;
					notEnoughBlackCubes = false; 

				}
				else {
					
					randomRow = Random.Range(0,gridWidth);
					randomCol = Random.Range(0,gridHeight);
					
				}
			}
		 
		}
		
		void CheckScore(){
			
			for(int x = 1; x < gridWidth - 1; x++)
			{
				for(int y = 1; y < gridHeight - 1; y++)
				{
					
					if(CheckForColorPlus(x,y) == true)
					{
						
						CubeBehavior.activeCube = false;
						score += samePlusPoints;
						//turn it black
						print("Found a Same Plus at x = " + x + "y: "+y);
						MakePlusBlack (x,y);
						
					}
					if (CheckForRainbowPlus(x,y) == true){
						
						CubeBehavior.activeCube = false;
						score += rainbowPlusPoints;
						MakePlusBlack(x,y);
						print("Found a Rainbow Plus at x = " + x + "y: "+y);	
						
					}

				}
		}
	}


					
					// Use this for initialization
					void Start () {
						
						GridCubes = new GameObject[gridWidth,gridHeight] ;
						colorArray = Random.Range (0, 5);
						
						for (int x = 0; x < (gridWidth);x++) {
							for (int y = 0; y < (gridHeight);y++){
								
								//instantiate the grid of cubes 
								GridCubes[x,y] = (GameObject) Instantiate(baseCube, new Vector2 ((x)*1.5f,(y)*1.5f), Quaternion.identity) ;
								GridCubes[x,y].GetComponent<Renderer> ().material.color = Color.white ;
								
								GridCubes[x,y].GetComponent<CubeBehavior> ().activeCube = true; 
								GridCubes[x,y].GetComponent<CubeBehavior> ().blackCube = false ; 
								GridCubes[x,y].GetComponent<Renderer> ().material.color = Color.white;
								
								GridCubes [gridWidth, gridHeight].GetComponent<CubeBehavior> ().x = i;
								GridCubes [gridWidth, gridHeight].GetComponent<CubeBehavior> ().y = j;
								
		}
	}
						
		NewRandomColorCube (x,y);
						
}
				
// Update is called once per frame
	void Update () {
	
	CheckScore ();
	scoreUI.text = "Score: " + score;
	//scoreUI.fontSize = 50;
	
	if (clickedACube == false) {
		ProcessedClickedCube (x,y);
	}
	if (Time.time > timeToAct) {
		if (cubeInPlace == false){
			MakeRandomCubeBlack (x,y);
		}

		clickedACube = false;
		
	
		NewRandomColoredCube(x,y);
		timeToAct += turnLength;
	}
	if (Time.time <= endGame) {

		endGameUI.text = "GAME OVER";

	}                    
}
}
