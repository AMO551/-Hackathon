using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Replay : MonoBehaviour
{
   public void NextButton()
    {
        //現在のシーンを取得
        Scene scene = SceneManager.GetActiveScene();
        //現在のシーンのビルド番号を取得
        int index = scene.buildIndex;
        if (index == 3)
        {
            SceneManager.LoadScene(0);
        }
        //取得したビルド番号のシーン（現在のシーン）を読み込む
        SceneManager.LoadScene(index+1);
    }
    public void ReplayButton()
    {
        //現在のシーンを取得
        Scene scene = SceneManager.GetActiveScene();
        //現在のシーンのビルド番号を取得
        int index = scene.buildIndex;
        //取得したビルド番号のシーン（現在のシーン）を読み込む
        SceneManager.LoadScene(index);
    }
}
