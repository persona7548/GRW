using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerCtrl : MonoBehaviour
{
    private float h = 0.0f;
    private float v = 0.0f;

    //접근 컴포넌트 변수할당
    private Transform tr;
    GameObject director;
    //이동속도 변수
    public float moveSpeed = 5.0f;

    public float rotSpeed = 100.0f;

    //애니메이션 클래스 변수
    public Anim anim;
    public Animation _animation;
 
    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.tag == "bullet")
        {
            Debug.Log("졌읍니다..");
            Destroy(this.gameObject);
            this.director.GetComponent<GameDirector>().DestoryPlayer();
        }
    }
    void Start()
    {
        // transform 컴포넌트 할당
        tr = GetComponent<Transform>();
        this.director = GameObject.Find("GameDirector");
        _animation = GetComponentInChildren<Animation>();

        _animation.clip = anim.idle;
        _animation.Play();
    }


    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        //전후좌우 이동방향 벡터 계산
        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);

        //Translate(이동방향 * 속도 * 변위값 * Time.deltatime, 기준좌표 )
        tr.Translate(moveDir.normalized * Time.deltaTime * moveSpeed, Space.Self);

        //Vector3.up 축을 기준으로 rotspeed만큼의 속도로 회전
        tr.Rotate(Vector3.up * Time.deltaTime * rotSpeed * Input.GetAxis("Mouse X"));

        //키보드 입력값을 기준으로 동작할 애니 수행
        if (v >= 0.1f)
        {
            _animation.CrossFade(anim.runForward.name, 0.3f);
        }
        else if (v <= -0.1f)
        {
            _animation.CrossFade(anim.runBackward.name, 0.3f);
        }
        else if (h >= 0.1f)
        {
            _animation.CrossFade(anim.runRight.name, 0.3f);
        }
        else if (h <= -0.1f)
        {
            _animation.CrossFade(anim.runLeft.name, 0.3f);
        }
        else
        {
            _animation.CrossFade(anim.idle.name, 0.3f);
        }
    }
}