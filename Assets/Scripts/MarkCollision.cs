using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MarkCollision : MonoBehaviour {
     
    private bool isHitted;
    public Text scoreUI;
    public Text highscoreUI;
    private int score;
    private int highScore;
    public Canvas mainCanvas;
    public Canvas retryCanvas;
    public Text endScore;
    public Text bestendScore;
    public Button retry;
    public Text level;
    private bool isAlive = true;
    private int diamond=10;
    [SerializeField]
    private Text nDiamondText;
    // Use this for initialization
    void Start () {
        diamond = PlayerPrefs.GetInt("diamond", diamond);
        mainCanvas.enabled = true;
        retryCanvas.enabled = false;
        isHitted = false;
        score = 0;
        highScore = PlayerPrefs.GetInt("highscore", highScore);
        highscoreUI.text = " Best " + highScore;
        nDiamondText.text = diamond.ToString();
        Button mRetry = retry.GetComponent<Button>();
        mRetry.onClick.AddListener(rebeatLevel);
        isAlive = true;
        switch (SceneManager.GetActiveScene().name)
        {
            case "FairBall": { level.text = "1"; break; }
            case "FairBallLevel2": { level.text = "2"; break; }
            case "L3": { level.text =" 3"; break; }
            case "L4": { level.text = " 7"; break; }
            case "L5": { level.text = " 4"; break; }
            case "L6": { level.text = " 5"; break; }
            case "L7": { level.text = " 6"; break; }
            case "L8": { level.text = " 15"; break; }
            case "L9": { level.text = " 12"; break; }
            case "L10": { level.text = " 8"; break; }
            case "L11": { level.text = " 19"; break; }
            case "L12": { level.text = " 21"; break; }
            case "L13": { level.text = " 27"; break; }
            case "L14": { level.text = " 13"; break; }
            case "L15": { level.text = " 25"; break; }
            case "L16": { level.text = "  16"; break; }
            case "L17": { level.text = "  14"; break; }
            case "L18": { level.text = "  16"; break; }
            case "L19": { level.text = "  9"; break; }
            case "L20": { level.text = "  18"; break; }
            case "L21": { level.text = "  28"; break; }
            case "L22": { level.text = "  23"; break; }
            case "L23": { level.text = "  10"; break; }
            case "L24": { level.text = "  30"; break; }
            case "L25": { level.text = "  24"; break; }
            case "L26": { level.text = "  20"; break; }
            case "L27": { level.text = "  27"; break; }
            case "L28": { level.text = "  26"; break; }
            case "L29": { level.text = "  17"; break; }
            case "L30": { level.text = "  22"; break; }
            case "L31": { level.text = "  34"; break; }
            case "L32": { level.text = "  33"; break; }
            case "l33": { level.text = "  31"; break; }
            case "l34": { level.text = "  32"; break; }
        }
       
    }
	
	// Update is called once per frame
	void Update () {
        isHitted = false;
    }
 
    void rebeatLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
 
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "ground")
        {
           collision.collider.gameObject.tag = "Untagged";
            isHitted = true;
            score += 10;
            scoreUI.text = Convert.ToString(score);
        }
        if (  collision.collider.tag == "enemy")
        {
            isAlive = false;
            this.gameObject.GetComponent<Rigidbody>().useGravity = false;
            mainCanvas.enabled = false;
            retryCanvas.enabled = true;
            endScore.text = "  Score " + score;
            bestendScore.text = " Best " + highScore;
            if (score > highScore)
            {
                highScore = score;
                PlayerPrefs.SetInt("highscore", highScore);
            }
        }
        else if(collision.collider.tag == "end"&&isAlive)
        { //Return the current Active Scene in order to get the current Scene's name
          string   m_Scene = SceneManager.GetActiveScene().name;
            switch (m_Scene)
            {

                case "FairBall": {    SceneManager.LoadScene("FairBallLevel2"); PlayerPrefs.SetString("level", "L2"); break; } //1
                case "FairBallLevel2": { SceneManager.LoadScene("L3"); PlayerPrefs.SetString("level", "L3"); break; } //2
                case "L3":  { SceneManager.LoadScene("L5"); PlayerPrefs.SetString("level", "L5"); break; }//3
                case "L4": { SceneManager.LoadScene("L10"); PlayerPrefs.SetString("level", "L10"); break; }//7
                case "L5":  { SceneManager.LoadScene("L6"); PlayerPrefs.SetString("level", "L6"); break; }//4
                case "L6": { SceneManager.LoadScene("L7"); PlayerPrefs.SetString("level", "L7"); break; }//5
                case "L7": { SceneManager.LoadScene("L4"); PlayerPrefs.SetString("level", "L4"); break; }//6
                case "L8": { SceneManager.LoadScene("L18"); PlayerPrefs.SetString("level", "L18"); break; }//15
                case "L9": { SceneManager.LoadScene("L14"); PlayerPrefs.SetString("level", "L14"); break; }//12
                case "L10": { SceneManager.LoadScene("L19"); PlayerPrefs.SetString("level", "L19"); break; }//8
                case "L11": { SceneManager.LoadScene("L26"); PlayerPrefs.SetString("level", "L26"); break; }//19
                case "L12": { SceneManager.LoadScene("L30"); PlayerPrefs.SetString("level", "L30"); break; }//21
                case "L13": { SceneManager.LoadScene("L21"); PlayerPrefs.SetString("level", "L21"); break; }//27
                case "L14": { SceneManager.LoadScene("L17"); PlayerPrefs.SetString("level", "L17"); break; }//13
                case "L15": { SceneManager.LoadScene("L27"); PlayerPrefs.SetString("level", "L27"); break; }//25
                case "L16": { SceneManager.LoadScene("L9"); PlayerPrefs.SetString("level", "L9"); break; }//25
                case "L17": { SceneManager.LoadScene("L8"); PlayerPrefs.SetString("level", "L8"); break; }//14
                case "L18": { SceneManager.LoadScene("L29"); PlayerPrefs.SetString("level", "L29"); break; }//16
                case "L19": { SceneManager.LoadScene("L23"); PlayerPrefs.SetString("level", "L23"); break; }//9
                case "L20": { SceneManager.LoadScene("L11"); PlayerPrefs.SetString("level", "L11"); break; }//18
                case "L21": { SceneManager.LoadScene("L28"); PlayerPrefs.SetString("level", "L28"); break; }//28
                case "L22": { SceneManager.LoadScene("L25"); PlayerPrefs.SetString("level", "L25"); break; }//23
                case "L23": { SceneManager.LoadScene("L16"); PlayerPrefs.SetString("level", "L16"); break; }//10
                case "L24": { SceneManager.LoadScene("L33"); PlayerPrefs.SetString("level", "L33"); break; }//30
                case "L25": { SceneManager.LoadScene("L15"); PlayerPrefs.SetString("level", "L15"); break; }//24
                case "L26": { SceneManager.LoadScene("L12"); PlayerPrefs.SetString("level", "L12"); break; }//20
                case "L27": { SceneManager.LoadScene("L13"); PlayerPrefs.SetString("level", "L13"); break; }//26
                case "L28": { SceneManager.LoadScene("L24"); PlayerPrefs.SetString("level", "L24"); break; }//29
                case "L29": { SceneManager.LoadScene("L20"); PlayerPrefs.SetString("level", "L20"); break; }//17
                case "L30": { SceneManager.LoadScene("L22"); PlayerPrefs.SetString("level", "L22"); break; }//22
                case "L32": { SceneManager.LoadScene("L31"); PlayerPrefs.SetString("level", "L31"); break; }//34
                case "L33": { SceneManager.LoadScene("L34"); PlayerPrefs.SetString("level", "L34"); break; }//31
                case "L34": { SceneManager.LoadScene("L32"); PlayerPrefs.SetString("level", "L32"); break; }//33
                
            }
        }
        else if (collision.collider.tag == "end" && !isAlive)
        {
            mainCanvas.enabled = false;
            retryCanvas.enabled = true;
        }
        else if (collision.collider.tag == "diamond" && isAlive)
        {
            diamond++;
            PlayerPrefs.SetInt("diamond", diamond);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "enemy")
        {
            mainCanvas.enabled = false;
            retryCanvas.enabled = true;
            isAlive = false;
            endScore.text = "  Score " + score;
            bestendScore.text = " Best " + highScore;
            if (score > highScore)
            {
                highScore = score;
                PlayerPrefs.SetInt("highscore", highScore);
            }
        }
    }
    public bool mIsHitted { get { return isHitted; } }
}
