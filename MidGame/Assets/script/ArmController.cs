using UnityEngine;

public class ArmController : MonoBehaviour
{
    public Rigidbody2D armRigidbody; // 팔의 물리 컴포넌트 연결
  
   

    // Update is called once per frame
    void Update()
    {
        // 1. 마우스의 화면 좌표를 게임 세상 좌표로 바꿉니다.
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f; // 2D 게임이니까 Z축 깊이는 0으로 고정!

        // 2. 어깨(현재 팔 오브젝트)에서 마우스를 향하는 방향을 구합니다.
        Vector3 direction = mousePos - transform.position;

        // 3. Atan2 함수로 방향을 '각도(Degree)'로 변환합니다.
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // 4. 물리 엔진을 이용해 팔을 해당 각도로 회전시킵니다.
        // (단순히 transform.rotation을 쓰면 벽을 통과해버릴 수 있어서 MoveRotation을 써야 해요!)
        armRigidbody.MoveRotation(angle);
    }
}
