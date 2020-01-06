using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndingText : MonoBehaviour {
    GameObject director;
    GameObject TimeText;
    GameObject DeathText;
    int EndDeath;
    float EndTime;

    public void OnclickStart()
    {
        Debug.Log("START");
        this.director.GetComponent<GameDirector>().ResetAll();
        SceneManager.LoadScene(0);
    }
    public void OnclickEnd()
    {
        Application.Quit();
    }
    void Start () {
        this.TimeText = GameObject.Find("EndTime");
        this.DeathText = GameObject.Find("EndDeath");
        this.director = GameObject.Find("GameDirector");
        EndDeath = this.director.GetComponent<GameDirector>().EndD();
        EndTime = this.director.GetComponent<GameDirector>().EndT();
    }
	
	// Update is called once per frame
	void Update () {
        this.TimeText.GetComponent<Text>().text = "총 소요시간 :" + EndTime.ToString("F1") + "초";
        this.DeathText.GetComponent<Text>().text = "총 " + EndDeath.ToString() + "번죽음";
    }
}
