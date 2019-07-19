using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void ChangeStartScene()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void ChangeEnding()
    {
        SceneManager.LoadScene("ENDING");
    }

    public void ChangeGameScene()
    {
        SceneManager.LoadScene("GameScene2");
    }

    public void ChangeTutorialScene()
    {
        SceneManager.LoadScene("TutorialScene");
    }
    public void s1()
    {
        SceneManager.LoadScene("s1");
    }
    public void s2()
    {
        SceneManager.LoadScene("s2");
    }
    public void s3()
    {
        SceneManager.LoadScene("s3");
    }
    public void s4()
    {
        SceneManager.LoadScene("s4");
    }
    public void s5()
    {
        SceneManager.LoadScene("s5");
    }

    public void ENDING2()
    {
        SceneManager.LoadScene("ENDING2");
    }

    public void onClickExit()
    {
        Application.Quit();
        Debug.Log("Button Click");
    }
}
