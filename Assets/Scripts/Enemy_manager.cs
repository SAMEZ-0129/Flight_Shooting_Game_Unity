using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy_manager : MonoBehaviour
{   
    // 최소 시간 ( 생성 주기 )
    public float minTime = 0.5f;
    // 최대 시간 ( 생성 주기 )
    public float maxTime = 1.5f;
    // 현재 시간
    float currentTime;
    // 일정 시간   
    float createTime;
    //적 생산 공장
    public GameObject enemyFactory;

    public int poolSize = 10;
    GameObject[] enemyObjectPool;
    public Transform[] spawnPoints;


    void Start()
    {
        // 태어날 때 적의 생성 시간 설정
        createTime = Random.Range(minTime,maxTime);
        enemyObjectPool = new GameObject[poolSize];
        // 오브젝트 풀 생성
        for (int i = 0; i < poolSize ; i ++) // 탄창에 넣을 총알 개수만큼 반복한다
        {
            // 총알 공장에서 총알 생성
            GameObject enemy = Instantiate(enemyFactory);

            // 총알을 오브젝트 풀에 넣고 싶다
            enemyObjectPool[i] = enemy; // 오브젝트 풀에 넣음

            enemy.SetActive(false); // 비활성화(탄창에 넣고 대기, 내가 쏠때 나가야 하기 때문)
        }
    }

    // Update is called once per frame
    void Update()
    {
        // 시간이 흐르다가
        currentTime += Time.deltaTime;

        // 만약 일정한 시간의 주기가 되면 ( 일정 시간이 되면/넘으면 )
        if (currentTime > createTime)
        {
            // 오브젝트 풀에서 에너미를 가져다가 사용함
            for (int i = 0; i <poolSize; i ++)
            {
                GameObject enemy = enemyObjectPool[i];
                if (enemy.activeSelf == false)
                {
                    // 랜덤으로 스폰포인트 중 하나를 선택( random )하여 배치함
                    int index = Random.Range(0,spawnPoints.Length);
                    enemy.transform.position = spawnPoints[index].position;
                    enemy.SetActive(true);

                    break;
                }
            }
            
            // 생성 시간 랜덤으로 계속 변경
            createTime = Random.Range(minTime,maxTime);
            // 현재시간 초기화
            currentTime = 0;
        }
    }
}
