using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text currentScoreUI; // 현재 점수 UI
    private int currentScore;    // 현재 점수 
    public Text bestScoreUI;    // 최고 점수 UI
    private int bestScore;       // 최고 점수

    public static ScoreManager Instance = null; // 싱글톤 객체 (SingleTon Desing Pattern) 

    // 싱글톤 객체란 : 임의의 크래스에서 내가 만든 싱글톤 인스턴스를 사용할 수 있다. 프로그램의 규모가 커지면 다른 클래스를 참조하는 변수가 너무 많아지고
    // public 변수를 자체가 메모리를 사용하는 것이고, 클래스를 변경하거나 삭제할 때 일일히 다 바꿔줘야 하기 때문에 시간낭비가 된다. 이를 위해 공통적으로 사용하는 
    // 전역변수나 리소스, 데이터, 아님 게임 전체를 관장하는 매니저 클래스는 싱글톤으로 따로 빼서 쓰는게 유용함. 
    
    // 싱글톤 객체에 값이 없으면 생성된 자신을 할당
    void Awake() {
        if (Instance == null)
        {
            Instance =this;
        }    
    }

    public int Score
    {
        get{
            return currentScore;
        }
        set{
            // ScoreManager 클래스의 속성에 값을 할당한다
            currentScore = value;
            // 화면에 점수를 표시해준다
            currentScoreUI.text = "현재 점수 :" + currentScore; // 텍스트와 현재점수 변수값을 합쳐서 같이 표시

            // 최고 점수 표시
            if (currentScore > bestScore) // 현재 점수가 최고 점수보다 높으면
            {
                bestScore = currentScore;    // 현재 점수를 최고 점수로 갱신
                bestScoreUI.text="최고 점수 : " + bestScore; // 표시
                PlayerPrefs.SetInt("Best Score", bestScore); // 최고 점수를 저장하고 싶다
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // 최고 점수를 불러와서 bestScore에 넣어주기
        bestScore = PlayerPrefs.GetInt("Best Score", 0); // 뒤에 있는 0은 만약 불러온 값이 없을 경우 나타낼 값
        // 최고 점수를 화면에 표시하기
        bestScoreUI.text="최고 점수 : " + bestScore;
    }

    // // currentScore에 값을 넣고 화면에 표시
    // public void SetScore(int value)
    // {
    //     // ScoreManager 클래스의 속성에 값을 할당한다
    //     currentScore+=10;
    //     // 화면에 점수를 표시해준다
    //     currentScoreUI.text = "현재 점수 :" + currentScore; // 텍스트와 현재점수 변수값을 합쳐서 같이 표시

    //     // 최고 점수 표시
    //     if (currentScore > bestScore) // 현재 점수가 최고 점수보다 높으면
    //     {
    //         bestScore = currentScore;    // 현재 점수를 최고 점수로 갱신
    //         bestScoreUI.text="최고 점수 : " + bestScore; // 표시
    //         PlayerPrefs.SetInt("Best Score", bestScore); // 최고 점수를 저장하고 싶다
    //     }

    // }

    // // currentScore 값 불러오기
    // public int GetScore()
    // {
    //     return currentScore;
    // }

    // Update is called once per frame
    void Update()
    {
        
    }
}
