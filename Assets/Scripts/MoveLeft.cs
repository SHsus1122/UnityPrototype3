using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private PlayerController playerControllerScript; 
    private float speed = 30;
    private float leftBound = -15;

    // Start is called before the first frame update
    void Start()
    {
        // 계층구조에서 Player 라는 게임 오브젝트를 찾아서 모든 컴포넌트를 가져와서 그 중에 PlayerController 만 가져옵니다.
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        // 게임 오버 조건에 따라 움직임을 제어합니다.
        if (playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        // 장애물 한정으로 일정 거리 이상 멀어지면 자동으로 해당 오브젝트(장애물)을 삭제(파괴) 합니다.
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
