using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    //public UniversitySelect[] SeleccionUniversidades = new UniversitySelect[4];
    public ButtonPagePair[] SelectionPage_Routes = new ButtonPagePair[4]; //For going from select page to routes
    public ButtonPagePair[] SelectionPage_Info = new ButtonPagePair[4]; //From select to info

    public Button[] InfoPage_Return = new Button[4];
    public ButtonPagePair[] InfoPage_Routes = new ButtonPagePair[4];

    public GameObject selectionPage;
    
    void Start()
    {
        changeToPage(selectionPage); //CHANGE: This is the first page to show to the user

        //Connect each button with its target page

        for (int i = 0; i < SelectionPage_Routes.Length; i++)
        {
            int index = i; //Local copy of i is needed becasue the lambda function captures the reference of i instead of its value.
            SelectionPage_Routes[index].button.onClick.AddListener(() =>
            {
                changeToPage(SelectionPage_Routes[index].targetPage);
            });
        }

        for (int i = 0; i < SelectionPage_Info.Length; i++)
        {
            int index = i; 
            SelectionPage_Info[index].button.onClick.AddListener(() =>
            {
                changeToPage(SelectionPage_Info[index].targetPage);
            });
        }

        //All the return buttons on the info pages always go to Selection Page
        for (int i = 0; i < InfoPage_Return.Length; i++)
        {
            int index = i;
            InfoPage_Return[index].onClick.AddListener(() =>
            {
                changeToPage(selectionPage);
            });
        }

        for (int i = 0; i < InfoPage_Routes.Length; i++)
        {
            int index = i;
            InfoPage_Routes[index].button.onClick.AddListener(() =>
            {
                changeToPage(InfoPage_Routes[index].targetPage);
            });
        }
    }

    // Update is called once per frame
    void Update()
    {
        //DEBUG: To return to selection page
        if (Input.GetKeyDown(KeyCode.Space)){
            changeToPage(selectionPage);
        }
    }

    void changeToPage(GameObject page)
    {
        //Deactivate all pages

        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }

        //This for loop may be changed
        
        //Deactivate the other pages


        //Activate the desired screen
        page.SetActive(true);


    }
}
[System.Serializable]
public struct UniversitySelect
{
    public Button button;
    public GameObject targetPage;
    public Button infoButton;
    public GameObject infoPage;
}

[System.Serializable]
public struct InfoPage
{
    public Button returnToSelectionBtn;
    public Button ViewRouteBtn;
}

[System.Serializable]
public struct ButtonPagePair
{
    public Button button;
    public GameObject targetPage;
}
