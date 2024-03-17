using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10;    // 점프 강도
    public float gravityModifier;   // 중력 강도
    public bool isOnGround = true;  // 플레이어 착지 상태

    private Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        // transform 은 모든 게임 오브젝트가 가지기에 자동으로 액세스(접근)를 지원합니다.
        // 하지만 Rigidbody 는 별도로 추가하는 것이기에 자동으로 지원하지 않습니다.
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;     // 중력 정보를 가져와서 원하는 곱하기로 원하는 중력 강도로 설정합니다.

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            // AddForce 는 Transform.Translate 와 역할이 비슷합니다.
            // 하지만, Translate 와 다르게 이는 위치만 사용해서 무언가를 물리적으로 움직이는 것이 아니라
            // 오브젝트에 힘을 적용할 수 있습니다. 그래서 아래처럼만 하면 player에 1000만큼의 힘을 위쪽방향으로 주는 것입니다.
            // 그래서 이 상태로 시작하면 캐릭터가 위로 점프하듯이 올라간 다음 중력에 의해 떨어지게 됩니다.
            //  - 첫 번째 인자 : 힘을 줄 방향과 정도
            //  - 두 번째 인자 : 힘을 어떤식으로 주는지에 대한 설정(Impulse 의 경우 즉시 힘을 적용해서 더 빠르게 뛰는 것처럼 보입니다)
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }

    // 플레이어가 오브젝트와 충돌시에 대한 이벤트 함수
    private void OnCollisionEnter(Collision collision)
    {
        isOnGround = true;
    }
}
