using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionAdjuster : MonoBehaviour
{

    private ScreenResolution m_currentResolution;

    // Start is called before the first frame update
    void Start()
    {

        Initialize();
    }

    void Initialize()
    {
        m_currentResolution = ScreenResolution.GetCurrentResolution();
        ChangeResolution();
    }

    bool IsResolutionChanged()
    {
        return m_currentResolution.IsChangeResolution();
    }

    void ChangeResolution() {
        m_currentResolution.UpdateValues();
        Debug.Log($"Change resolution to ({m_currentResolution.ToString()}) .");
    }

    void UpdateScreenResolution()
    {
        if (IsResolutionChanged())
        {
            ChangeResolution();
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScreenResolution();
    }
}

class ScreenResolution
{
    public int x { get; private set; }
    public int y { get; private set; }

    public static ScreenResolution GetCurrentResolution()
    {
        return new ScreenResolution(Screen.currentResolution.width, Screen.currentResolution.height);
    }

    public ScreenResolution(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public void UpdateValues()
    {
        x = Screen.currentResolution.width;
        y = Screen.currentResolution.height;
        ApplyWindowResolution();
    }

    private void ApplyWindowResolution()
    {
        Screen.SetResolution(x, y, false);
    }

    public bool IsChangeResolution()
    {
        return x != Screen.currentResolution.width || y != Screen.currentResolution.height;
    }

    public override string ToString()
    {
        return $"{x} * {y}";
    }

}
