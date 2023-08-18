using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class Enemy : MonoBehaviour
{
    public float speed = 5;
    GameObject Player;
    // 폭발 공장 주소( 외부에서 값을 넣음 )
    public GameObject explosionFactory;
    // Start is called before the first frame update
    Vector3 dir;
    void Start()
    {
    }

    // 활성화 됐을때 호출
    private void OnEnable() {
        // 30%는 플레이어 방향으로 따라옴 ( 생성 시 벡터 방향이 성성 당시 플레어어의 위치를 바라보는 방향 )
        // 0~99까지 100개의 값 중 하나 랜덤하게 생성
        int randValue = Random.Range(0,10);

        // 만약 랜덤 값이 25보다 작으면 플레이어 방향 ( 25% 확률로 플레이어 추적 )
        if (randValue < 3)
        {
            // 플레이어를 찾아 타겟으로 설정
            GameObject target = GameObject.Find("Player");
            if (target != null) // 만약 플레이어가 있다면
            {
                // 플레이어로 가는 방향 구하기( 상대방-나 )
                dir = target.transform.position-transform.position;
                // 벡터 크기 1로 지정
                dir.Normalize();
            }
            else{
                dir = Vector3.down;
            }
           
        }
        else
        { 
            // 75% 확률로 그냥 아래로 이동
            dir = Vector3.down;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // 정해진 방향으로 이동한다.
        transform.position += dir * speed * Time.deltaTime;
        // 만약 start함수에 있는 플레이어 방향 구하는 코드를 update에 넣으면 플레이어 방향으로 계속 추적할까? 
    }

    // 출돌 시 발생할 이벤트
    private void OnCollisionEnter(Collision other) 
    {
        // // Scene 에서 ScoreManager객체를 대려온다
        // GameObject smObject = GameObject.Find("ScoreManager");
        // // ScoreManager 게임 오브젝트에서 대려온다
        // ScoreManager sm = smObject.GetComponent<ScoreManager>();
        // // ScoreManager의 Get/Set함수로 점수 수정
        // sm.SetScore(sm.GetScore() + 1);

        // 위 코드는 싱글톤을 활용해서 아래 한줄 코드로 바뀜. 

        // // 적을 잡을 때마다 현재 점수를 표시하고 싶다.
        // ScoreManager.Instance.SetScore(ScoreManager.Instance.GetScore()+1);


        // 이 부분은 ScoreManager script로 이동함. 프로그래밍의 캡슐화를 통해 기존에 적이 죽으면 점수가 증가하고 수정되는 작업을 Enemy 스크립트에서 적 객체 각각 진행했다면, 
        // 아래 코드를 ScoreManager로 옮김으로서 적은 충돌할 경우 본인이 죽었다는 표시만 하면 되는것이고, 점수 관리 스크립트가 점수를 관리하는 절차를 이루게 된 것.
        // 또한 ScoreManager를 sm으로 변수로 불러와서 코드를 작성해야 하는 것에 반해 ScoreManager 내부에서 코드가 실행되기 때문에 sm변수를 참조해서 사용하지 않아도 된다. 

        // // ScoreManager 클래스의 속성에 값을 할당한다
        // sm.currentScore++;
        // // 화면에 점수를 표시해준다
        // sm.currentScoreUI.text = "현재 점수 :" + sm.currentScore; // 텍스트와 현재점수 변수값을 합쳐서 같이 표시

        // // 최고 점수 표시
        // if (sm.currentScore > sm.bestScore) // 현재 점수가 최고 점수보다 높으면
        // {
        //     sm.bestScore = sm.currentScore;    // 현재 점수를 최고 점수로 갱신
        //     sm.bestScoreUI.text="최고 점수 : " + sm.bestScore; // 표시
        //     PlayerPrefs.SetInt("Best Score", sm.bestScore); // 최고 점수를 저장하고 싶다
        // } 

        ScoreManager.Instance.Score++; // 적을 잡을 때마다 현재 점수 증가 및 표시

        // 폭발 효과 공장에서 폭발 효과 하나 생성
        GameObject explosion = Instantiate(explosionFactory);
        // 폭발 효과 발생 위치/발생 시킴
        explosion.transform.position = transform.position;

        // 만약 부딪힌 물체가 총알이라면 비활성화 시켜서 탄창에 넣음
        if  (other.gameObject.name.Contains("Bullet")) 
        {
            other.gameObject.SetActive(false); 
            Player_fire_bullet.bulletObjectPool.Add(other.gameObject);
        }
        else
        {
            Destroy(other.gameObject);  // 너죽고
        }
    
        gameObject.SetActive(false);
        
    }
}
