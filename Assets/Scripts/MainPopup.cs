using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainPopup : GameMonoBehaviour
{
    public Button lang;
    private int localId=0;
    void Start()
    {
        lang.onClick.AddListener(OnLangPress);
    }

    void OnLangPress()
    {
        if (localId == 0)
        {
            localId = 1;
            SetLocale(localId);
        }
        else
        {
            localId = 0;
            SetLocale(localId);
        }
    }
    void SetLocale(int _localeId)
    {
        //LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[_localeId];
    }
}
