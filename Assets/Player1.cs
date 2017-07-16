using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : IStateGame {

    private Game game;

    private string chrestik = null;

    public void ReactionOfPress(Game game)
    {
        this.game = game;
    }

    public void Execute()
    {
        chrestik = game.setOnBtnX;
        Debug.Log("go to pl1");
        game.playerSideText = chrestik;
        game.whoGoLastX = true;
        if (!game.next)
        {
            ChangePlayer();
            game.next = false;
            game.whoGoLastX = false;
        }
        
        game.changePlayer = true;
        
    }

    private void ChangePlayer()
    {
        game.ChangePlayer(new Player2());
        
    }

    
}
