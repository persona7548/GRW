using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {
    public GameObject outP;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Enemy")
        {
            Debug.Log("포탈....");
            other.transform.SetPositionAndRotation(outP.transform.position,other.transform.rotation);
        }

    }
    // Use this for initialization
    void Start () {
        this.outP = GameObject.Find("OutPortal");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
