using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI storyTMP;
    [SerializeField] GameObject titleTMP;
    [SerializeField] State startingState;

    string imageCanvasName = "0";
    GameObject imageCanvas;
    State state;

    int dimaxi = 0;
    int huachenyu = 0;
    int wangyibo = 0;
    int xiaozhan = 0;
    int wang_xiao = 0;

    // Start is called before the first frame update
    void Start()
    {
        state = startingState;

        UpdateStoryInfo();
    }

    // Update is called once per frame
    void Update()
    {
        ManageState();
    }

    private void ManageState()
    {
        var nextStates = state.GetNextStates();
        for (int i = 0; i < nextStates.Length; i++) {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i)) {
                state = nextStates[i];
            }
        }

        UpdateStoryInfo();
    }

    private void UpdateStoryInfo()
    {
        storyTMP.SetText(state.GetStoryText());

        if (state.GetIsTitle())
        {
            titleTMP.SetActive(true);
        }
        else
        {
            titleTMP.SetActive(false);
        }

        if (imageCanvasName != state.GetIimageCanvasName())
        {
            imageCanvas = GameObject.Find(imageCanvasName);
            imageCanvas.GetComponent<CanvasGroup>().alpha = 0f;
        }

        imageCanvasName = state.GetIimageCanvasName();
        imageCanvas = GameObject.Find(imageCanvasName);
        imageCanvas.GetComponent<CanvasGroup>().alpha = 1f;

        dimaxi += state.GetDi();
        huachenyu += state.GetHua();
        wangyibo += state.GetWang();
        xiaozhan += state.GetXiao();
        wang_xiao += state.GetWX();
    }
        
        
}
