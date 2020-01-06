using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour {
   
    GameObject timerText;
    GameObject EnemyNum;
    GameObject Stage;
    GameObject TotalTime;
    GameObject Death;

    int stageLevel;
     static int death = 0;
     static float totalTime = 0.0f;
    float time = 0.0f;

    int num = 0;
    void Start()
    {
        stageLevel=SceneManager.GetActiveScene().buildIndex;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        GameObject[] Enemy = GameObject.FindGameObjectsWithTag("Enemy");
        num = Enemy.Length;
        this.timerText = GameObject.Find("Time");
        this.EnemyNum = GameObject.Find("Num");
        this.Stage = GameObject.Find("StageNum");
        this.TotalTime = GameObject.Find("TotalTime");
        this.Death = GameObject.Find("Death");
      
    }
    public void DestroyEnemy()
    {
        num -= 1;
    }
    public void DestoryPlayer() {
        death++;
        SceneManager.LoadScene(stageLevel);
          }
    public void ResetAll()
    {
       death = 0;
       totalTime = 0.0f;
    }
    public int EndD() { return death; }
    public float EndT() { return totalTime; }
    public void OnclickStart()
    {
        Debug.Log("START");
        ResetAll();
        SceneManager.LoadScene(0);
    }
    public void OnclickRestart()
    {
        Debug.Log("RESTART");
        death++;
        SceneManager.LoadScene(stageLevel);
    }

    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        if (Input.GetMouseButtonDown(0)) {

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        if (Input.GetKeyDown(KeyCode.F1))
        {
            Debug.Log("START");
            ResetAll();
            SceneManager.LoadScene(0);
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            Debug.Log("RESTART");
            death++;
            SceneManager.LoadScene(stageLevel);
        }
        if (num == 0) {
           SceneManager.LoadScene(stageLevel+1);
        }
        this.time += Time.deltaTime;
        totalTime += Time.deltaTime;
        this.timerText.GetComponent<Text>().text =this.time.ToString("F1");
        this.EnemyNum.GetComponent<Text>().text =this.num.ToString()+ "마리 남음";
        this.TotalTime.GetComponent<Text>().text = "총 소요시간 : "+totalTime.ToString("F1");
        this.Death.GetComponent<Text>().text = "총 "+death.ToString()+"번죽음";
        this.Stage.GetComponent<Text>().text = stageLevel.ToString() + " Stage";

    }
}
