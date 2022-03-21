using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Audio;

public class MenuManager : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject OptionMenu;
    public GameObject LeaderBoard;
    private Button[] MainMenuButtons;
    private Button[] OptionMenuButtons;
    private Button[] LeaderMenuButtons;


    public void Start()
    {
       MainMenuButtons= MainMenu.GetComponentsInChildren<Button>();
       OptionMenuButtons= OptionMenu.GetComponentsInChildren<Button>();
       LeaderMenuButtons= LeaderBoard.GetComponentsInChildren<Button>();
    }
    public void ToOptions()
    {
        foreach (var item in MainMenuButtons)
        {
            item.ShrinkBar();
        }
        StartCoroutine(ShowOption());
    }

    public void ToMain()
    {

        foreach (var item in MainMenuButtons)
        {
            item.GrowBar();
        }
        StartCoroutine(ShowMain());
    }

    public void ToLeaderboard()
    {
        foreach (var item in MainMenuButtons)
        {
            item.ShrinkBar();
        }


        StartCoroutine(ShowLeader());
    }





    IEnumerator ShowLeader()
    {
        yield return new WaitForSeconds(2);

        MainMenu.SetActive(false);
        LeaderBoard.SetActive(true);
        OptionMenu.SetActive(false);
    }
    
    IEnumerator ShowMain()
    {
        yield return new WaitForSeconds(2);

        MainMenu.SetActive(true);
        LeaderBoard.SetActive(false);
        OptionMenu.SetActive(false);
    }
    IEnumerator ShowOption()
    {
        yield return new WaitForSeconds(2);

        MainMenu.SetActive(false);
        LeaderBoard.SetActive(false);
        OptionMenu.SetActive(true);
    }



}