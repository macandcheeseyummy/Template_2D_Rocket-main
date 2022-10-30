using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System;

public class respawnManager : MonoBehaviour
{
    public static respawnManager I;


    public int totalCusm;
    public int stageCusm;

    public GameObject drinks;
    int[] drink_randNums;
    int drink_randNum;

    public GameObject customers;
    // int[] cusm_randNums;
    int cusm_randNum;
    public float delay;
    //public GameObject[] cusm_list;

    public GameObject seats;
    int[] seat_randNums;
    int seat_randNum;
    public GameObject seats_1;
    public GameObject seats_2;
    public GameObject seats_3;
    public GameObject seats_4;
    public GameObject seats_5;
    public GameObject seats_6;
    public int[] seat_check = new int[6];


    public GameObject[] cusm_prefabs;

    public GameObject temp;

    //[Serializable]
    public struct cusm_struct {
        public int cusm_order; // 손님 등장 순서
        public Transform trans_cusm_num; // Parents 안에서 불려질 숫자
        public int cusm_seat; // 손님 의자 번호
        public bool seatUse; // 의자 사용 여부
    };
    public cusm_struct[] arr_cusm_struct;

    public Queue seat1Q = new Queue();

    void Awake()
    {
        I = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        // seat_check[0] = 0;
        // seat_check[1] = 0;
        // seat_check[2] = 0;
        // seat_check[3] = 0;
        // seat_check[4] = 0;
        // seat_check[5] = 0;
        makeNum();
        //script_customers.GetComponent<customers>().;
        //InvokeRepeating("makeGlass", 0, 0.5f);
        //cusm_prefabs = new GameObject[stageCusm];
    }

    // Update is called once per frame
    void Update()
    {
        //seatCheck();
    }

    // 반복을 통해 스테이지 당 찾아올 손님, 음료 수를 구한다.
    public void makeNum()
    {
        // 반복을 통해 drinks child를 꺼낼 숫자를 찾는다.
        // 각 스테이지 고객 수만큼 반복한다.
        drink_randNums = new int[stageCusm];
        for (int i = 0; i < stageCusm; i++) {
            drink_randNum = Random.Range(0, totalCusm);
            drink_randNums[i] = drink_randNum;
        }

        // 반복을 통해 customers를 꺼낼 숫자를 찾는다.
        // drinks와 별개로 불러오기 때문에(랜덤 배정) 별도 함수를 생성한다.
        // cusm_randNums = new int[stageCusm];
        // for (int i = 0; i < stageCusm; i++) {
        //     cusm_randNum = Random.Range(0, totalCusm);
        //     cusm_randNums[i] = cusm_randNum;
        // }

        // 반복을 통해 customers가 들어갈 seat 배정을 위한 숫자를 찾는다.
        //cusm_num = new GameObject();
        //seat_randNums = new int[stageCusm];
        arr_cusm_struct = new cusm_struct[stageCusm];
        cusm_prefabs = new GameObject[stageCusm];
        
        for (int i = 0; i < stageCusm; i++) {
            cusm_randNum = Random.Range(0, totalCusm);
            seat_randNum = Random.Range(0, 6);
            
            // var test = customers.transform.GetChild(cusm_randNum);
            // Debug.Log(cusm_randNum);
            // Debug.Log("test " + arr_cusm_struct[i].cusm_num.name);
            //seat_randNums[i] = seat_randNum;
            //GameObject instance = Instantiate(customers.transform.GetChild(cusm_randNum)).gameObject;
            //var cusm_num_var = customers.transform.GetChild(cusm_randNum);
            //Debug.Log("흠 " + cusm_num_var);

            arr_cusm_struct[i].cusm_order = i;
            arr_cusm_struct[i].trans_cusm_num = customers.transform.GetChild(cusm_randNum);
            arr_cusm_struct[i].cusm_seat = seat_randNum;
            arr_cusm_struct[i].seatUse = false;

            Debug.Log("1. 손님 순서 " + arr_cusm_struct[i].cusm_order);
            //Debug.Log("1. 패런트 서 " + arr_cusm_struct[i].trans_cusm_num);
            //Debug.Log("2. 좌석 " + arr_cusm_struct[i].cusm_seat);
            //Debug.Log("3. 좌석 사용 여부 " + arr_cusm_struct[i].seatUse);

            var k = arr_cusm_struct[i].cusm_seat;
            var seat_transform = seats.transform.GetChild(k);
            cusm_prefabs[i] = (GameObject)Instantiate(arr_cusm_struct[i].trans_cusm_num, seat_transform.position, Quaternion.identity).gameObject;



            //cusm_prefabs[i] = (GameObject)Instantiate(arr_cusm_struct[i].trans_cusm_num, seat_transform.position, Quaternion.identity).gameObject;
            //cusm_prefabs[i].SetActive(false);
            //Debug.Log(cusm_prefabs);
        }
    
        //StartCoroutine(makeCusm());
        //activateCusm();
        //Invoke("makeGlass", 2); // 2초 후
    }

    public void seat1Queue() {
        for (int i = 0; i < stageCusm; i++) {
            seat1Q.Enqueue(cusm_prefabs[i]);
            Debug.Log(seat1Q);
            seat1Q.Dequeue();
        }
    }
    



    // 손님을 부른다. 음료에 종속되지 않는다.
    // IEnumerator makeCusm() {
    //     cusm_list = new GameObject[stageCusm];
    //     for (int i = 0; i < cusm_randNums.Length; i++) {
    //         var cusm_prefab = customers.transform.GetChild(cusm_randNums[i]);
    //         var seat_transform = seats.transform.GetChild(seat_randNums[i]);
            
    //         cusm_prefab_name = Instantiate(cusm_prefab, seat_transform.position, Quaternion.identity).gameObject;
    //         cusm_list[i] = cusm_prefab_name;
    //         yield return new WaitForSeconds(delay); 
    //     }
    //     
    // }

    // 손님을 SetActive 한다.
    // public void activateCusm() {
    //     for (int i = 0; i < arr_cusm_struct.Length; i++) {
    //         var k = arr_cusm_struct[i].cusm_seat;
    //         var seat_transform = seats.transform.GetChild(k);
    //         cusm_prefabs[i] = (GameObject)Instantiate(arr_cusm_struct[i].trans_cusm_num, seat_transform.position, Quaternion.identity).gameObject;
            // if (seat_check[k] == 0) {
            //     arr_cusm_struct[i].seatUse = true;
            //     Debug.Log("앉은 놈들의 seatUse" + arr_cusm_struct[i].seatUse);
            //     seat_check[k] = 1;

                // if (seat_check[k] == 1) {
                //     float random_0 = Random.Range(2f, 6.5f);
                //     Destroy(cusm_prefabs[i], random_0);
                //     //seat_check[k] = 0;
                //     //Invoke("seatChange", random_0);
                // }
                //seat_check[k] = 0;
            // }
            // else {
            //     cusm_prefabs[i].SetActive(false);
            //     Debug.Log("못 앉은ㅇㅇㅇㅇ 놈들의 seatUse" + arr_cusm_struct[i].seatUse);
            // }
    //     }
    // }


    // public void activateCusmCheck() {
    //     for (int i = 0; i < arr_cusm_struct.Length; i++) {
    //         var k = arr_cusm_struct[i].cusm_seat;
    //         var seat_transform = seats.transform.GetChild(k);
    //         if (arr_cusm_struct[i].seatUse == false) {
    //             temp.SetActive(true);
    //             arr_cusm_struct[i].seatUse = true;
    //         }
    //     }
    // }

    public void seatCheck() {
        for (int i = 0; i < arr_cusm_struct.Length; i++) {
            var k = arr_cusm_struct[i].cusm_seat;
            if (seat_check[k] == 0) {
                cusm_prefabs[i].SetActive(true);
                seat_check[k] = 1;

                float random_0 = Random.Range(2f, 6.5f);
                Invoke("byeCustomer", random_0);
                break;
            }
            else {
                Debug.Log("앉지마");
            }
            
        }
    }

    public void byeCustomer() {
        for (int i = 0; i < arr_cusm_struct.Length; i++) {
            var k = arr_cusm_struct[i].cusm_seat;
            if (seat_check[k] == 1) {
                cusm_prefabs[i].SetActive(false);
                seat_check[k] = 0;
            }
        }
    }

    // public void DestroyImmediate() {
    //     for (int i = 0; i < arr_cusm_struct.Length; i++) {
    //         Destroy(arr_cusm_struct[i].trans_cusm_num);
    //     }

    //}
    
        // 손님이 온 n초 후, 잔이 불러진다.
    // public void makeGlass()
    // {

    //     //drinks.transform.GetChild(0).gameObject.Setactive(false);
    //     //GameObject drinks_0000 = drinks.transform

    //     // 가장 첫 번째 음료는 첫 번째 손님이 온 후, n초 후 나타난다.
    //     Instantiate(drinks.transform.GetChild(drink_randNums[0]));

    //     // 나머지 음료도 마찬가지로 손님이 온 후, n초 후 나타난다.
    // }
}
