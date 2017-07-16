using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModel {

    private int countOfWinner;
    private int countOfDraw;
    private int countOfFailure;
	
    public int GetCountOfWinner() { return countOfWinner; }
    public int GetCountOfDraw() { return countOfDraw; }
    public int GetCountOfFailure() { return countOfFailure; }

    public void SetCountOfWinner(int value) { countOfWinner = value; }
    public void SetCountOfDraw(int value) { countOfDraw = value; }
    public void SetCountOfFailure(int value) { countOfFailure = value; }
}
