using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour {


    public void OnclickStart() {
        Debug.Log("START");
        SceneManager.LoadScene(1);
    }

    public void OnclickEnd()
    {
        Application.Quit();
    }

    void Start () {
        
    }

	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        if (Input.GetMouseButtonDown(0))
        {

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

    }
}
