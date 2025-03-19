using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PauseMenuUI : BaseUICanvas
{
  // Start is called before the first frame update

  public TextMeshProUGUI confirmLeaveReadingText;
  public Transform confirmLeaveReadingModal;
  ConfirmLeaveReadingOption currentLeaveReadingOption;

  public enum ConfirmLeaveReadingOption { MainMenu, QuitGame }
  public GameRunner gameRunner;

  void OnEnable()
  {
    confirmLeaveReadingModal.gameObject.SetActive(false);
  }

  void OnDisable()
  {
    confirmLeaveReadingModal.gameObject.SetActive(false);
  }

  public void ShowConfirmMainMenuModal()
  {
    confirmLeaveReadingModal.gameObject.SetActive(true);
    currentLeaveReadingOption = ConfirmLeaveReadingOption.MainMenu;
    confirmLeaveReadingText.text = "Return to the main menu?";
  }


  public void ShowConfirmQuitModal()
  {
    confirmLeaveReadingModal.gameObject.SetActive(true);
    currentLeaveReadingOption = ConfirmLeaveReadingOption.QuitGame;
    confirmLeaveReadingText.text = "Quit?";
  }

  public void LeaveReading()
  {
    switch (currentLeaveReadingOption)
    {
      case ConfirmLeaveReadingOption.MainMenu:
        MainMenu();
        break;
      case ConfirmLeaveReadingOption.QuitGame:
      default:
        Quit();
        break;
    }
  }

  // TODO: probably shouldn't be handling sound from here


  void MainMenu()
  {
    gameRunner.QuitToMainMenu();
  }

  void Quit()
  {
    gameRunner.QuitGame();
  }
}