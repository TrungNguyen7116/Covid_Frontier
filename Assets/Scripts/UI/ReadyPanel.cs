using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadyPanel : MonoBehaviour
{
    private CanvasGroup panel;
    [SerializeField]
    private Text levelmap;
    private void Start()
    {
        panel = GetComponent<CanvasGroup>();
        ShowPanel();
    }
    public void HidePanel()
    {
        panel.alpha = 0;
        panel.blocksRaycasts = false;
    }
    public void ShowPanel()
    {
        levelmap.text = "Map " + PlayerPrefs.GetInt("MAP_LEVEL").ToString();
        panel.alpha = 1;
        panel.blocksRaycasts = true;
    }
    public void Previous()
    {
        if (PlayerPrefs.GetInt("MAP_LEVEL") == 0) return;
        PlayerPrefs.SetInt("MAP_LEVEL", PlayerPrefs.GetInt("MAP_LEVEL") - 1);
        GamePlayManager.instance.StartGame();
        HidePanel();
    }
    public void Retry()
    {
        GamePlayManager.instance.StartGame();
        HidePanel();
    }
    public void Next()
    {
        PlayerPrefs.SetInt("MAP_LEVEL", PlayerPrefs.GetInt("MAP_LEVEL") + 1);
        GamePlayManager.instance.StartGame();
        HidePanel();
    }
}
