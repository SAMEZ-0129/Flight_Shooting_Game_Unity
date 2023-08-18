using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_fire_bullet : MonoBehaviour
{
    public GameObject bulletFactory; // prefab에서 총알 생산을 위한 총알 공장 선언
    public GameObject fireposition; // 사용자의 총구 방향 위치 지정 ( 플레이어 객체에 자식으로 추가된 총구객체 할당 )
    public int poolsize = 10; // 탄창에 넣을 수 있는 총알의 개수
    [HideInInspector]
    public static List<GameObject> bulletObjectPool = new List<GameObject>(); // 오브젝트 풀 리스트 부여 

    void Start() {
        for (int i = 0; i < poolsize ; i ++) // 탄창에 넣을 총알 개수만큼 반복한다
        {
            // 총알 공장에서 총알 생성
            GameObject bullet = Instantiate(bulletFactory);

            // 총알을 오브젝트 풀에 넣고 싶다
            bulletObjectPool.Add(bullet); // 오브젝트 풀에 넣음 , 리스트에 추가

            bullet.SetActive(false); // 비활성화(탄창에 넣고 대기, 내가 쏠때 나가야 하기 때문)
        }
#if UNITY_ANDROID
        GameObject.Find("Joystick canvas XYBZ").SetActive(true);
#elif UNITY_EDITOR || UNITY_STANDALONE
        GameObject.Find("Joystick canvas XYBZ").SetActive(false);
#endif
    }
    // Update is called once per frame
    void Update()
    {
        // 유니티 데이터와 PC 환경일 때 작동
#if UNITY_STANDALONE
        if (Input.GetButtonDown("Fire1")) // 만약 버튼을 누르면(누를 당시) 총알이 발사
        {
            Fire();
        }
#endif
    }

    public void Fire()
    {
    // 탄창에 있는 총알 중 비활성화 된 총알을 발사
        if(bulletObjectPool.Count > 0)
        {
            GameObject bullet = bulletObjectPool[0];
            bulletObjectPool.RemoveAt(0);
            bullet.SetActive(true); // 비활성화된 총알을 활성화
            bullet.transform.position = fireposition.transform.position; // 총알 발사 (총구에 위치)
        }    
    }
}
    

