using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    // 배경 객체
    public Material bgMaterial;
    // 배경 스크롤 속도
    public float scrollspeed = 0.2f;

    // Update is called once per frame
    void Update()
    {
        // 스크롤 방향
        Vector2 direction = Vector2.up;         // vector2는 vector3와 다르게 2차원적 설정만 가능, X축과 Y축만 있음. 
        // 스크롤 한다
        bgMaterial.mainTextureOffset += direction * scrollspeed * Time.deltaTime;
        
    }
}
