using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pythonCord : MonoBehaviour
{
    // Start is called before the first frame update
    System.Diagnostics.Process process = new System.Diagnostics.Process();
    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
    void Start()
    {
        //var p = new System.Diagnostics.Process();
        
        startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
        startInfo.FileName = "cmd.exe";
        startInfo.Arguments = "/python colorrec.py";
        process.StartInfo = startInfo;
        //showed error about this.
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.RedirectStandardOutput = true;
        process.Start();
        
        Debug.Log(process.StandardOutput.ReadToEnd());
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(process.StandardOutput.ReadToEnd());
    }
}
