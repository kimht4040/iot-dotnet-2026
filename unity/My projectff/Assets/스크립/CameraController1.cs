using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player; // 따라다닐 플레이어 공
    private Vector3 offset;   // 카메라와 공 사이의 고정된 거리

    void Start()
    {
        // 게임이 시작될 때, 현재 카메라 위치와 공 위치의 차이(거리)를 계산해서 저장합니다.
        offset = transform.position - player.transform.position;
    }

    // LateUpdate는 플레이어가 먼저 움직인 '직후'에 실행되는 함수입니다.
    // 카메라가 공을 쫓아갈 때 화면이 떨리는 현상을 막아줍니다.
    void LateUpdate()
    {
        // 공의 현재 위치에 처음에 저장해둔 거리(offset)를 더해서 카메라를 이동시킵니다.
        transform.position = player.transform.position + offset;
    }
}