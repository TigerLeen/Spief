using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLoadScene : MonoBehaviour
{
    public string _sceneName = string.Empty;

    public void OnButtonPressed()
    {
        Application.LoadLevel(_sceneName);
    }
} //taken from the tank game :D
