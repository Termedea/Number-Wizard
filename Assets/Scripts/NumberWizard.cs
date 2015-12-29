using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class NumberWizard : MonoBehaviour {
	private int _max;	
	private int _min; 
	private int _guess;
	private bool _gameRangeChosen;
	// Use this for initialization
	private void Start () {
		
		StartGame();
	}
	
	// Update is called once per frame
	private void Update () {
	
		if(_gameRangeChosen){
			if (Input.GetKeyDown(KeyCode.UpArrow)){
				_min = _guess; 
				NextGuess();
			} else if (Input.GetKeyDown(KeyCode.DownArrow)){
				_max = _guess;
				NextGuess();			
			} else if (Input.GetKeyDown(KeyCode.Return)){
				print("I won!");
				StartGame();
			}
		} else {
			ChooseRange();
		}
		
		
	
	}
	private void StartGame(){
		_gameRangeChosen = false; 
		print ("=======================");
		print ("Welcome to Number Wizard");
		print ("Pick a range of numbers");
		
		print ("For 1-100, press 1");
		print ("====");
		print ("For 100-10,000, press 2");
		print ("====");
		print ("For 10,000-1,000,000, press 3");
		print ("====");
		
		ChooseRange();
		
	}
	
	private void ChooseRange(){
		
		if(Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1)){
			_min = 1;
			_max = 100;
			_gameRangeChosen = true;
			print ("1");
		} else if(Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2)) {
			_min = 100;
			_max = 10000;
			_gameRangeChosen = true;
			print ("2");
		} else if(Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3)) {
			_min = 10000;
			_max = 1000000;
			_gameRangeChosen = true;
			print ("3");
		} 
		
		if(_gameRangeChosen)
		{
			print ("Awesome, you've chosen wisely! The lowest number you can pick is " + _min ); 
			print("The highest number you can pick is " +_max);
			print ("================");
			print ("Go ahead, pick a number in your head, but don't tell me! I'll try to guess your number :)");
			_max++;
			NextGuess();
		}
	
		
	}
	private void NextGuess(){
		
		_guess = Random.Range(_min, _max);
		print ("Is the number higher or lower than " +_guess +"?");
		print ("Up = higher, down = lower, return = equal");
	}
}
