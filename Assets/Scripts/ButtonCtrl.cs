using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonCtrl : MonoBehaviour {
    public void OnExitClick()
    {
        print("exit");
        Application.Quit();
    }
}
