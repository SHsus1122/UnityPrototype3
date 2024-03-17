using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;

    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private float startDelay = 2;
    private float repeateRate = 2;

    // Start is called before the first frame update
    void Start()
    {
        // SpawnObstacle 함수를 시작하고 2초 뒤부터 2초마다 계속해서 호출
        InvokeRepeating("SpawnObstacle", startDelay, repeateRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle ()
    {
        // 스폰 설정 : 스폰할 프리팹, 스폰할 좌표, 스폰할 인스턴스의 회전값
        Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
    }
}
