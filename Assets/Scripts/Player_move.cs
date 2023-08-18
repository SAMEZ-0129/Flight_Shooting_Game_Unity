using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_move : MonoBehaviour
{
    public float speed = 2;
    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");  // 키 입력을 받아 가로축 방향의 결정
        float v = Input.GetAxis("Vertical");    // 키 입력을 받아 세로축 방향의 결정

        Vector3 dir = new Vector3(h,v,0); // = Vector3.right * h + Vector3.up * v; // 받은 방향축을 토대로 방향값 변수 선언 
        // (right와 up만으로) 좌우 상하를 모두 할 수 있는 이유는 음수값 때문


        // transform.Translate(dir * speed * Time.deltaTime);  유니티에 너무 종속적인 코드라 아래 코드로 변경

        // P = P0 + vt 공식으로 변경함
        transform.position += dir * speed * Time.deltaTime;

    }
}
