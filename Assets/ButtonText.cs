using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonText : MonoBehaviour {

    private Button btn;
    private Game game;
    public Text btntext;

	// Use this for initialization
	void Start () {
        btn = GetComponent<Button>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetBtn()
    {
        if (game.next)
        {
            btntext.text = game.GetText();
            btn.interactable = false;
            game.next = false;
            game.CheckWin();
        }
        
    }

    public void SetReferencePlayer(Game game)
    {
        this.game = game;
    }
}
