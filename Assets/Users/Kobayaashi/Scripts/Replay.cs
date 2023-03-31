using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Replay : MonoBehaviour
{
   public void NextButton()
    {
        //���݂̃V�[�����擾
        Scene scene = SceneManager.GetActiveScene();
        //���݂̃V�[���̃r���h�ԍ����擾
        int index = scene.buildIndex;
        if (index == 3)
        {
            SceneManager.LoadScene(0);
        }
        //�擾�����r���h�ԍ��̃V�[���i���݂̃V�[���j��ǂݍ���
        SceneManager.LoadScene(index+1);
    }
    public void ReplayButton()
    {
        //���݂̃V�[�����擾
        Scene scene = SceneManager.GetActiveScene();
        //���݂̃V�[���̃r���h�ԍ����擾
        int index = scene.buildIndex;
        //�擾�����r���h�ԍ��̃V�[���i���݂̃V�[���j��ǂݍ���
        SceneManager.LoadScene(index);
    }
}
