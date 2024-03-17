using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;

    private PlayerController playerControllerScript;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private float startDelay = 2;
    private float repeateRate = 2;

    // Start is called before the first frame update
    void Start()
    {
        // 계층구조에서 Player 라는 게임 오브젝트를 찾아서 모든 컴포넌트를 가져와서 그 중에 PlayerController 만 가져옵니다.
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        // SpawnObstacle 함수를 시작하고 2초 뒤부터 2초마다 계속해서 호출
        InvokeRepeating("SpawnObstacle", startDelay, repeateRate);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnObstacle()
    {
        // 게임 오버 조건에 따라 움직임을 제어합니다.
        if (playerControllerScript.gameOver == false)
        {
            // 스폰 설정 : 스폰할 프리팹, 스폰할 좌표, 스폰할 인스턴스의 회전값
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
    }
}
