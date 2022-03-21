using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Audio;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject OptionMenu;
    public GameObject LeaderBoard;
    private Button[] MainMenuButtons;
    private Button[] OptionMenuButtons;
    private Button[] LeaderMenuButtons;    
    private TextMeshProUGUI[] MainMenuTexts;
    private TextMeshProUGUI[] OptionMenuTexts;
    private TextMeshProUGUI[] LeaderMenuTexts;



    public void Start()
    {
       MainMenuButtons= MainMenu.GetComponentsInChildren<Button>();
       OptionMenuButtons= OptionMenu.GetComponentsInChildren<Button>();
       LeaderMenuButtons= LeaderBoard.GetComponentsInChildren<Button>();
       
       MainMenuTexts= MainMenu.GetComponentsInChildren<TextMeshProUGUI>();
       OptionMenuTexts= OptionMenu.GetComponentsInChildren<TextMeshProUGUI>();
       LeaderMenuTexts= LeaderBoard.GetComponentsInChildren<TextMeshProUGUI>();
    }
    public void ToOptions()
    {
        foreach (var item in MainMenuButtons)
        {
            item.ShrinkBar();
        }
        foreach (var item in MainMenuTexts)
        {
            item.enabled = !item.enabled;
        }
        StartCoroutine(ShowOption());
    }

    public void ToMain()
    {
        StartCoroutine(ShowMain());
    }

    public void ToLeaderboard()
    {
        foreach (var item in MainMenuButtons)
        {
            item.ShrinkBar();
        }
        foreach (var item in MainMenuTexts)
        {
            item.enabled = !item.enabled;
        }

        StartCoroutine(ShowLeader());
    }


    void ShrinkButtons(Button[] Buttons)
    {
        foreach (var item in Buttons)
        {
            item.ShrinkBar();
        }
    }    
    void GrowButtons(Button[] Buttons)
    {
        foreach (var item in Buttons)
        {
            item.GrowBar();
        }
    }    
    
    void ShowHideText(TextMeshProUGUI[] Texts)
    {
        foreach (var item in Texts)
        {
            item.enabled = !item.enabled;
        }
    }    


    IEnumerator ShowLeader()
    {
        yield return new WaitForSeconds(0.7f);

        MainMenu.transform.DOLocalMoveX(-180, 0.5f);

        yield return new WaitForSeconds(0.5f);

        MainMenu.SetActive(false);
        LeaderBoard.SetActive(true);
        OptionMenu.SetActive(false);

        
        LeaderBoard.transform.DOLocalMoveX(0, 0.5f);

        yield return new WaitForSeconds(0.5f);

        GrowButtons(LeaderMenuButtons);

        yield return new WaitForSeconds(0.5f);

        ShowHideText(LeaderMenuTexts);
    }
    
    IEnumerator ShowMain()
    {

        ShowHideText(OptionMenuTexts);
        ShowHideText(LeaderMenuTexts);

        yield return new WaitForSeconds(0.5f);

        ShrinkButtons(OptionMenuButtons);
        ShrinkButtons(LeaderMenuButtons);


        yield return new WaitForSeconds(0.7f);

        OptionMenu.transform.DOLocalMoveX(-180, 0.5f);
        LeaderBoard.transform.DOLocalMoveX(-180, 0.5f);

        yield return new WaitForSeconds(0.5f);

        MainMenu.SetActive(true);
        LeaderBoard.SetActive(false);
        OptionMenu.SetActive(false);

        //MainMenu.transform.position = (new Vector3(-180, 0, 0));
        MainMenu.transform.DOLocalMoveX(0, 0.5f);

        yield return new WaitForSeconds(0.5f);

        GrowButtons(MainMenuButtons);

        yield return new WaitForSeconds(0.5f);

        ShowHideText(MainMenuTexts);

    }
    IEnumerator ShowOption()
    {
        yield return new WaitForSeconds(0.7f);

        MainMenu.transform.DOLocalMoveX(-180, 0.5f);

        yield return new WaitForSeconds(0.5f);

        MainMenu.SetActive(false);
        LeaderBoard.SetActive(false);
        OptionMenu.SetActive(true);

        //OptionMenu.transform.position = new Vector3(0,0,0);
        OptionMenu.transform.DOLocalMoveX(0, 0.5f);

        yield return new WaitForSeconds(0.5f);

        GrowButtons(OptionMenuButtons);

        yield return new WaitForSeconds(0.5f);

        ShowHideText(OptionMenuTexts);
    }



}