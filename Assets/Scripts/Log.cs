using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Log : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI logText;
    [SerializeField] GameObject logPanel;

    public void AddLog(string content)
    {
        logText.text += content;
    }

    public void EnablePanel()
    {
        logPanel.SetActive(true);
    }

    public void DisenablePanel()
    {
        logPanel.SetActive(false);
    }
}
