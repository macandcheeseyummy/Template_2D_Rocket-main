using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class customers : MonoBehaviour
{
    respawnManager respawn;

    public GameObject seats;
    public GameObject seats_1;
    public GameObject seats_2;
    public GameObject seats_3;
    public GameObject seats_4;
    public GameObject seats_5;
    public GameObject seats_6;

    public int position;

    public int temp;

    // Start is called before the first frame update
    void Start()
    {
        respawn = GameObject.Find("respawnManager").GetComponent<respawnManager>();
        // positionCheck();
    }

    // Update is called once per frame
    void Update()
    {
        //activeCheck();
    }

    // public void positionCheck() {
    //     if (seats_1.transform.position == gameObject.transform.position) {
    //         position == 0;
    //     }
    //     if (seats_2.transform.position == gameObject.transform.position) {
    //         position == 1;
    //     }
    //     if (seats_3.transform.position == gameObject.transform.position) {
    //         position == 2;
    //     }
    //     if (seats_4.transform.position == gameObject.transform.position) {
    //         position == 3;
    //     }
    //     if (seats_5.transform.position == gameObject.transform.position) {
    //         position == 4;
    //     }
    //     if (seats_6.transform.position == gameObject.transform.position) {
    //         position == 5;
    //     }
    // }




    // public void leaveCusm() {
    //     Destroy(gameObject);
    //     Debug.Log(gameObject.name);
    // }



}
