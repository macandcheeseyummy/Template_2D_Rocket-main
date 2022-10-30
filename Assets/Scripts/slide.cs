using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slide : MonoBehaviour
{
    Vector2 StartPos;
    Vector2 EndPos;

    public float swipelength;
    public float force;
    public Rigidbody2D rigid;

    public bool movingTrue;
    public bool mouseCheck;

    public float lastX;

    float SwipeLength, Speed;

    bool glasscheck;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0f, 0f, 0);
        rigid = GetComponent<Rigidbody2D>();
        movingTrue = true;
        lastX = gameObject.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (movingTrue != false) {
            mouseMoving();
        }

        if (mouseCheck == true) {
            checkmoving();
        }

    }
    
    void mouseMoving() {
        if (Input.GetMouseButtonDown(0)) {
            Debug.Log("눌려라");
            this.StartPos = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0)) {
            this.EndPos = Input.mousePosition;
            SwipeLength = EndPos.x - StartPos.x;
            this.Speed = SwipeLength / swipelength;
            mouseCheck = true;
        }

        transform.Translate(this.Speed, 0, 0);
        this.Speed *= force;
        
    }


    // void OnTriggerEnter2D(Collider2D collision)
    // {
    //     if (collision.tag == "place1")
    //     {
    //         Destroy(gameObject, 2.0f);
    //         respawnManager.I.makeGlass();
    //     }
    // }

    void checkmoving() {
        if (Mathf.Abs(gameObject.transform.position.x) - Mathf.Abs(lastX) < 0.001f) {
            movingTrue = false;
        }
        lastX = gameObject.transform.position.x;
    }


}