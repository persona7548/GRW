using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletCtrl : MonoBehaviour {

    
    public int speed = 1000;

	void Start () {
        GetComponent<Rigidbody>().AddForce(transform.forward * speed);
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Wall")
        {
            Debug.Log("벽..");
        }
        Destroy(this.gameObject);
        
    }
    // Update is called once per frame
    void Update () {
		
	}
}
