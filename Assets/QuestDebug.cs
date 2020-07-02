using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

// ReSharper disable once CheckNamespace
public class QuestDebug : MonoBehaviour
{
    public static QuestDebug Instance;
    internal bool InMenu;
    internal Text LogText;

    void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        var rt = DebugUIBuilder.instance.AddLabel("Debug");
        LogText = rt.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(OVRInput.GetDown(OVRInput.Button.Two) || OVRInput.GetDown(OVRInput.Button.Start))
        {
            if (InMenu) DebugUIBuilder.instance.Hide();
            else DebugUIBuilder.instance.Show();
            InMenu = !InMenu;
        }
    }

    public void Log(string message)
    {
        LogText.text = message;
    }
}
