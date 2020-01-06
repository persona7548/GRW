using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBlock : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player"|| other.tag == "Enemy")
        {
            Debug.Log("회전....");
            other.transform.Rotate(0, 90, 0);
            Destroy(this.gameObject);
        }

    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Rotate(new Vector3(0, 30, 0) * Time.deltaTime);
    }
}
