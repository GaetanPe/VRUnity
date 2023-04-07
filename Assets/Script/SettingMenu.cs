using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class SettingsMenu : MonoBehaviour
{
    private Canvas canvas = null;
    private MainMenu mainMenu = null;

    private void Awake()
    {
        canvas = GetComponent<Canvas>();
    }

    public void Setup(MainMenu mainMenu)
    {
        this.mainMenu = mainMenu;
        Hide();
    }

    public  void Show()
    {
        canvas.enabled = true;
    }

    public void Hide()
    {
        canvas.enabled = false;
    }
}
