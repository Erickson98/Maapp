using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public UniversitySelect[] SeleccionUniversidades = new UniversitySelect[4];
    public GameObject selectionPage;
    
    void Start()
    {
        changeToPage(selectionPage); //CHANGE: This is the first page to show to the user

        for (int i = 0; i < SeleccionUniversidades.Length; i++)
        {
            int index = i; //Local copy of i is needed becasue the lambda function captures the reference of i instead of its value.
            SeleccionUniversidades[index].button.onClick.AddListener(() =>
            {
                changeToPage(SeleccionUniversidades[index].targetPage);
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

        //This for loop may be changed
        for (int i = 0; i < SeleccionUniversidades.Length; i++)
        {
            SeleccionUniversidades[i].targetPage.SetActive(false);
        }
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
}
