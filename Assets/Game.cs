using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour {

    public IStateGame StateGame;
    public Text[] texts;
    public string playerSideText;
    public bool next = false;
    public bool changePlayer = false;
    public bool goNextPlayer = false;
    private bool gameover = false;

    public Text textOfWin;
    public Text textOfDraw;
    public Text textOfFail;
    public Text textWhoWin;
    public GameObject winpanel;
    public GameObject resetGame;
    public GameObject menu;

    private string WhoWin;
    private int checkCount = 0;
    private static int winnerValue = 0;
    private static int drawValue = 0;
    private static int failValue = 0;
    private static GameModel model = GetValuesFromModel();
    private static GameView view = new GameView();
    private static GameController controll = new GameController(model, view);

    public bool whoGoLastX = false;
    public bool whoGoLastO = false;
    public bool winDraw = false;
    public bool winX = false;
    public bool winO = false;
    public string setOnBtnX = "X";
    public string setOnBtnO = "O";
    public float startTime = 1.2f;
    private int value;

    private void Awake()
    {
        winpanel.gameObject.SetActive(false);
        resetGame.gameObject.SetActive(false);
        SetReferenceOnBtn();
        ChangePlayer(new Player1());
        UpdateValueView();
    }

    public void GoToMenu()
    {
        model.SetCountOfWinner(0);
        model.SetCountOfDraw(0);
        model.SetCountOfFailure(0);
        winnerValue = 0;
        drawValue = 0;
        failValue = 0;
        SceneManager.LoadScene("Menu");
    }

    private void UpdateValueView()
    {
        controll.UpdateView();
        textOfWin.text = view.winvalue.ToString();
        textOfDraw.text = view.drawvalue.ToString();
        textOfFail.text = view.failvalue.ToString();
    }

    private static GameModel GetValuesFromModel()
    {
        GameModel model = new GameModel();
        model.SetCountOfWinner(winnerValue);
        model.SetCountOfDraw(drawValue);
        model.SetCountOfFailure(failValue);
        return model;
    }

    private void Update()
    {
        StateGame.Execute();
    }

    public void GoNextComputer()
    {
        if (next == false && !gameover)
        {
            startTime += startTime * Time.deltaTime;
            if (startTime > 5f)
            {
                value = Random.Range(0, 9);
                if (texts[value].GetComponentInParent<Button>().interactable == true)
                {
                    texts[value].text = setOnBtnO;
                    texts[value].GetComponentInParent<Button>().interactable = false;
                    CheckWin();
                    goNextPlayer = true;
                    startTime = 1.2f;
                }
            }

            print(startTime);
        }
        
    }

    public void ChangePlayer(IStateGame pl)
    {
        StateGame = pl;
        StateGame.ReactionOfPress(this);
        next = !next;
    }

    private void SetCount()
    {
        if(changePlayer)
        {
            winnerValue++;
            WhoWin = "You Win!!!";
            gameover = true;
            winX = true;
        }
        else
        {
            failValue++;
            goNextPlayer = false;
            gameover = true;
            startTime = 1.2f;
            WhoWin = "Computer Win!!!";
            winO = true;
        }
        SetBtnInteractible(false);
        UpdateGameModel();
        winpanel.gameObject.SetActive(true);
        textWhoWin.text = WhoWin;
        resetGame.gameObject.SetActive(true);
        next = true;
        startTime = 1.2f;
        ChangeValueOnBtn();
    }

    private void ChangeValueOnBtn()
    {
        if(winX && !winO)
        {
            setOnBtnX = "X";
            setOnBtnO = "O";
            winX = false;
        }else if(!winX && winO)
        {
            setOnBtnX = "O";
            setOnBtnO = "X";
            winO = false;
        }else if(winDraw && whoGoLastX)
        {
            setOnBtnX = "O";
            setOnBtnO = "X";
            ChangePlayer(new Player2());
        }
        else if (winDraw && whoGoLastO)
        {
            setOnBtnX = "X";
            setOnBtnO = "O";
            ChangePlayer(new Player1());
        }
    }

    public void ResetGame()
    {
        for(int i=0; i < texts.Length; i++)
        {
            texts[i].GetComponentInParent<Button>().interactable = true;
            texts[i].text = null;
        }
        resetGame.gameObject.SetActive(false);
        winpanel.gameObject.SetActive(false);
        checkCount = 0;
        startTime = 1.2f;
        gameover = false;
        winDraw = false;
    }

    public void SetBtnInteractible(bool istrue)
    {
        for(int i=0; i < texts.Length; i++)
        {
           texts[i].GetComponentInParent<Button>().interactable = istrue;
        }
    }

    private void UpdateGameModel()
    {
        model.SetCountOfWinner(winnerValue);
        model.SetCountOfDraw(drawValue);
        model.SetCountOfFailure(failValue);
    }

    public void CheckWin()
    {
        checkCount++;
        if (texts[0].text == playerSideText && texts[1].text == playerSideText && texts[2].text == playerSideText)
        {
            SetCount();
            UpdateValueView();
        }
        else if (texts[3].text == playerSideText && texts[4].text == playerSideText && texts[5].text == playerSideText)
        {
            SetCount();
            UpdateValueView();
        }
        else if (texts[6].text == playerSideText && texts[7].text == playerSideText && texts[8].text == playerSideText)
        {
            SetCount();
            UpdateValueView();

        }
        else if (texts[0].text == playerSideText && texts[3].text == playerSideText && texts[6].text == playerSideText)
        {
            SetCount();
            UpdateValueView();

        }
        else if (texts[1].text == playerSideText && texts[4].text == playerSideText && texts[7].text == playerSideText)
        {
            SetCount();
            UpdateValueView();

        }
        else if (texts[2].text == playerSideText && texts[5].text == playerSideText && texts[8].text == playerSideText)
        {
            SetCount();
            UpdateValueView();

        }
        else if (texts[0].text == playerSideText && texts[4].text == playerSideText && texts[8].text == playerSideText)
        {
            SetCount();
            UpdateValueView();

        }
        else if (texts[2].text == playerSideText && texts[4].text == playerSideText && texts[6].text == playerSideText)
        {
            SetCount();
            UpdateValueView();

        }
        else if (checkCount >= 9)
        {
            drawValue++;
            UpdateGameModel();
            winpanel.gameObject.SetActive(true);
            WhoWin = "It`s Draw!!!";
            textWhoWin.text = WhoWin;
            UpdateValueView();
            next = true;
            gameover = true;
            resetGame.gameObject.SetActive(true);
            winDraw = true;
            ChangeValueOnBtn();
        }
        else
        {
            startTime = 1.2f;
        }
    }

    public string GetText()
    {
        return playerSideText;
    }


    public void SetReferenceOnBtn()
    {
        for(int i=0; i<texts.Length;i++)
        {
            texts[i].GetComponentInParent<ButtonText>().SetReferencePlayer(this);
        }
    }
}
