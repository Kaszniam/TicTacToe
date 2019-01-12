using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{

	public int buttonNumber;

	private GameManager _gameManager;

	private Button _button;
	// Use this for initialization
	void Start ()
	{
		_gameManager = FindObjectOfType<GameManager>();
		GameManager.OnRestart += Restart;
		_button = GetComponent<Button>();
		_button.onClick.AddListener(SetUpSprite);
	}

	private void SetUpSprite()
	{
		GetComponent<Image>().sprite = _gameManager.GetSpriteForTile();
		_gameManager.SetTile(buttonNumber);
	}

	private void Restart()
	{
		StartCoroutine(RestartCoroutine());
	}

	private IEnumerator RestartCoroutine()
	{
		_button.interactable = false;
		yield return new WaitForSeconds(_gameManager.secondsTillReset);
		GetComponent<Image>().sprite = _gameManager.basic;
		_button.interactable = true;
	}
}
