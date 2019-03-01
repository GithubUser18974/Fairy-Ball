using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChooseLevel : MonoBehaviour {
    private string mCurrenLevel = "FairBall";
    // Use this for initialization
    void Start () {
        
        mCurrenLevel = PlayerPrefs.GetString("level", mCurrenLevel);
        if ((mCurrenLevel != null || mCurrenLevel != "")) { StartCoroutine(Example()); mCurrentLevel(); }
    
}
    void mCurrentLevel()
    {
        SceneManager.LoadScene(mCurrenLevel);
    }
    IEnumerator Example()
    {
        print(Time.time);
        yield return new WaitForSeconds(4);
        print(Time.time);
    }
}
