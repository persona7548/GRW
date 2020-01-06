using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator : MonoBehaviour {

    public GameObject bullet;
    public Transform firePos;
    public AudioClip fsound;
    AudioSource fireSound;
    private LineRenderer lineRenderer;

	// Use this for initialization
	void Start () {
        fireSound = GetComponent<AudioSource>();
        lineRenderer = GetComponent<LineRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        lineRenderer.SetPosition(0, firePos.position);
        lineRenderer.SetPosition(1, firePos.position+firePos.forward * 10.0f);

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet, firePos.position, firePos.rotation);
            fireSound.PlayOneShot(fsound, 0.9f);
        }
	}
}
