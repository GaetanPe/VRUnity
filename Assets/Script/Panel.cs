using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class Panel : MonoBehaviour
{
    private Canvas canvas = null;
    private SettingsMenu settingsMenu = null;

    private void Awake()
    {
        canvas = GetComponent<Canvas>();
    }

    public void Setup(SettingsMenu settingsMenu)
    {
        this.settingsMenu = settingsMenu;
        Hide();
    }

    public void Show()
    {
        canvas.enabled = true;
    }

    public void Hide()
    {
        canvas.enabled = false;
    }
}
