using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "State")]
public class State : ScriptableObject
{
    [TextArea(10, 14)] [SerializeField] string storyText;
    [SerializeField] State[] nextStates;
    [SerializeField] string imageCanvasName;
    [SerializeField] bool isTitle;
    [SerializeField] int di;
    [SerializeField] int hua;
    [SerializeField] int wang;
    [SerializeField] int xiao;
    [SerializeField] int w_X;


    public string GetStoryText() {
        return storyText; 
    }

    public State[] GetNextStates() {
        return nextStates;
    }

    public bool GetIsTitle()
    {
        return isTitle;
    }

    public string GetIimageCanvasName()
    {
        return imageCanvasName;
    }

    public int GetDi() {
        return di;
    }

    public int GetHua()
    {
        return hua;
    }

    public int GetWang()
    {
        return wang;
    }

    public int GetXiao()
    {
        return xiao;
    }

    public int GetWX()
    {
        return w_X;
    }
}
