using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenWebsite : MonoBehaviour
{
    public string websiteURL = "https://www.linkedin.com/in/nicat-alioglu-793545286/"; // saytın linki.

    public void OpenSite()
    {
        // sayti ac
        Application.OpenURL(websiteURL);
    }
}
