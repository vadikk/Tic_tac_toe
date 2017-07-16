using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : IStateGame {

    private Game game;

    private string nolik = null;

    public void ReactionOfPress(Game game)
    {
        this.game = game;
    }

    public void Execute()
    {
        nolik = game.setOnBtnO;
        Debug.Log("go to pl2");
        game.playerSideText = nolik;
        game.whoGoLastO = true;
        
        if (!game.next)
        {
            game.GoNextComputer();
            
            if (game.goNextPlayer)
            {
                ChangePlayer();
                game.goNextPlayer = false;
                game.whoGoLastO = false;
            }
            
        }
       
        game.changePlayer = false;
    }

    private void ChangePlayer()
    {
        game.ChangePlayer(new Player1());
        
    }
}
