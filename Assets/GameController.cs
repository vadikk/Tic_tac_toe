using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController {

    private GameModel model;
    private GameView view;

    public GameController(GameModel model, GameView view)
    {
        this.model = model;
        this.view = view;
    }

    public int GetCountOfWinner() { return model.GetCountOfWinner(); }
    public int GetCountOfFailure() { return model.GetCountOfFailure(); }
    public int GetCountOfDraw() { return model.GetCountOfDraw(); }


    public void SetCountOfWinner(int value)
    {
        model.SetCountOfWinner(value);
    }

    public void SetCountOfFailure(int value)
    {
        model.SetCountOfFailure(value);
    }

    public void SetCountOfDraw(int value)
    {
        model.SetCountOfDraw(value);
    }

    public void UpdateView()
    {
        view.UpdateView(model.GetCountOfWinner(), model.GetCountOfDraw(), model.GetCountOfFailure());
    }
}
