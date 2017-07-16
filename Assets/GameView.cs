using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameView {

    public  int winvalue;
    public  int drawvalue;
    public  int failvalue;

    public void UpdateView(int valueWin, int valueDraw, int valueFail)
    {
        winvalue = valueWin;
        drawvalue = valueDraw;
        failvalue = valueFail;

        //Debug.Log("Win" + valueWin);
        //Debug.Log("Draw" + valueDraw);
        //Debug.Log("Fail" + valueFail);
    }

}
