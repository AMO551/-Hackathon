using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_button : MonoBehaviour
{

    public void OnClickStartButton()
    {
        SceneManager.LoadScene("Game");
    }
}