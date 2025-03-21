﻿using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Takes a TarotCardData object and applies its properties
// to the card/board as required.

public class CardReadingSpot : MonoBehaviour
{
  public TextMeshProUGUI cardMeaningText;
  public Image cardFront;
  public TarotCardData cardData;
  public CanvasGroup canvasGroup;
  public Button rereadButton;
  int readingOrder;
  GameRunner gameRunner;
  public float fadeSpeed = 1.0f;
  // public bool isReversed;
  // Start is called before the first frame update
  public void Init(TarotCardData cd, string cardMeaning, int order, GameRunner gr)
  {
    readingOrder = order;
    gameRunner = gr;
    cardMeaningText.text = cardMeaning;
    cardData = cd;
    cardFront.sprite = cardData.cardPicture2x;
    EnableButton(false);
  }


  public void SetCardMeaningText(string cardMeaning)
  {
    cardMeaningText.text = cardMeaning;
  }
  public void OnClickReread()
  {
    gameRunner.RereadCard(readingOrder);
  }

  public void EnableButton(bool enable)
  {
    rereadButton.gameObject.SetActive(enable);
  }

  public void OnGameStateChange(GameState newState)
  {
    if (GameRunner.InReadingGameState(newState))
    {
      canvasGroup.interactable = false;
    }
    else
    {
      canvasGroup.interactable = true;
    }
  }
  public void OnHover(bool hover)
  {
    Debug.Log("OnHover");
    if (gameRunner != null && rereadButton.gameObject.activeSelf)
    {
      gameRunner.buttonHover = hover;
    }
  }
}
