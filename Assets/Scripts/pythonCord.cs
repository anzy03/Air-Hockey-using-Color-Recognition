using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pythonCord : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //var p = new System.Diagnostics.Process();
        System.Diagnostics.Process process = new System.Diagnostics.Process();
        System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
        startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
        startInfo.FileName = "cmd.exe";
        startInfo.Arguments = "/python colorrec.py";
        process.StartInfo = startInfo;
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.RedirectStandardInput = true;
        process.Start();
        
        Debug.Log(process.StandardOutput.ReadToEnd());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
