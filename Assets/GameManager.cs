using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.WSA.Input;

public class GameManager : MonoBehaviour
{

	public Sprite basic;
	public Sprite cross;
	public Sprite circle;
	public float secondsTillReset = 2f;
	public Text text;

	public delegate void Restart();
	public static event Restart OnRestart;
	
	public enum Player
	{
		One,
		Two
	}

	public Player currentPlayer;

	public int[] tiles = new int[9];

	private void Start()
	{
		Reset();	
	}

	public void SetTile(int tileNumber)
	{
		tiles[tileNumber] = currentPlayer.Equals(Player.One) ? 1 : 2;
		CheckWinningCondition();
		currentPlayer = currentPlayer.Equals(Player.One) ? Player.Two : Player.One;		
	}

	public Sprite GetSpriteForTile()
	{
		return currentPlayer.Equals(Player.One) ? circle : cross;
	}

	private void Reset()
	{
		for (int i = 0; i < 9; i++)
		{
			tiles[i] = 0;
		}
		currentPlayer = Player.One;
	}

	private void CheckWinningCondition()
	{
		if (tiles[0] == 1)
		{
			if (tiles[1] == 1 && tiles[2] == 1)
			{
				AnnounceWinner();
			}
			if (tiles[4] == 1 && tiles[8] == 1)
			{
				AnnounceWinner();
			}
			if (tiles[3] == 1 && tiles[6] == 1)
			{
				AnnounceWinner();
			}
		}
		if (tiles[1] == 1 && tiles[4] == 1 && tiles[7] == 1)
		{
			AnnounceWinner();
		}
		if (tiles[2] == 1)
		{
			if (tiles[5] == 1 && tiles[8] == 1)
			{
				AnnounceWinner();
			}
			if (tiles[4] == 1 && tiles[6] == 1)
			{
				AnnounceWinner();
			}
		}
		if (tiles[3] == 1 && tiles[4] == 1 && tiles[5] == 1)
		{
			AnnounceWinner();
		}	
		if (tiles[6] == 1 && tiles[7] == 1 && tiles[8] == 1)
		{
			AnnounceWinner();
		}
		
		if (tiles[0] == 2)
		{
			if (tiles[1] == 2 && tiles[2] == 2)
			{
				AnnounceWinner();
			}
			if (tiles[4] == 2 && tiles[8] == 2)
			{
				AnnounceWinner();
			}
			if (tiles[3] == 2 && tiles[6] == 2)
			{
				AnnounceWinner();
			}
		}
		if (tiles[1] == 2 && tiles[4] == 2 && tiles[7] == 2)
		{
			AnnounceWinner();
		}
		if (tiles[2] == 2)
		{
			if (tiles[5] == 2 && tiles[8] == 2)
			{
				AnnounceWinner();
			}
			if (tiles[4] == 2 && tiles[6] == 2)
			{
				AnnounceWinner();
			}
		}
		if (tiles[3] == 2 && tiles[4] == 2 && tiles[5] == 2)
		{
			AnnounceWinner();
		}	
		if (tiles[6] == 2 && tiles[7] == 2 && tiles[8] == 2)
		{
			AnnounceWinner();
		}
	}

	private void AnnounceWinner()
	{
		OnRestart();
		StartCoroutine(TextCoroutine());
		Reset();
	}

	private IEnumerator TextCoroutine()
	{
		text.text = "Player " + currentPlayer + " wins!";
		yield return new WaitForSeconds(secondsTillReset);
		text.text = "";
	}

}
