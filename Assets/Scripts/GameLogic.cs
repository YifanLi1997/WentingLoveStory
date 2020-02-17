using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI storyTMP;
    [SerializeField] State startingState;

    string imageCanvasName = "0";
    GameObject imageCanvas;
    State state;

    Log m_log;

    void Start()
    {
        state = startingState;
        m_log = FindObjectOfType<Log>();

        UpdateStoryInfo();
    }

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

                if (state.name == "0")
                {
                    m_log.Reset();
                }

                m_log.AddLog(state.GetStoryText());
                UpdateStoryInfo();
            }
        }
    }

    private void UpdateStoryInfo()
    {
        StopAllCoroutines();
        StartCoroutine(TypeSentence(state.GetStoryText()));

        if (imageCanvasName != state.GetIimageCanvasName())
        {
            imageCanvas = GameObject.Find(imageCanvasName);
            imageCanvas.GetComponent<CanvasGroup>().alpha = 0f;
        }

        imageCanvasName = state.GetIimageCanvasName();
        imageCanvas = GameObject.Find(imageCanvasName);
        imageCanvas.GetComponent<CanvasGroup>().alpha = 1f;
    }

    IEnumerator TypeSentence(string sentence)
    {
        storyTMP.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            storyTMP.text += letter;
            yield return new WaitForFixedUpdate();
        }
    }
}
