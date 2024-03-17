using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;   // 배경 반복 시작 지점 좌표
    private float repeatWidth;  // 반복이 이루어지는 너비

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        // GetComponent 를 통해서 BoxColiider 의 x 사이즈의 절반값을 가져옵니다.
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        // 배경이 되는 SpriteRenderer 의 좌표가(여기서는 X좌표) 특정 시점보다 작아지는 경우
        // 초기 좌표로 지정해놓은 startPos 로 돌아가게 해서 계속해서 반복되는 배경을 구현합니다.
        // 분기문은 현재 x 좌표가 시작점 기준으로 절반미만일 때 반복하게 됩니다.
        if (transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;  
        }
    }
}
