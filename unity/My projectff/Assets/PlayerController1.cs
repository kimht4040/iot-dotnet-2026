using UnityEngine;
using TMPro; // UI 텍스트(TextMeshPro)를 조작하기 위해 꼭 추가해야 합니다.

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public TextMeshProUGUI scoreText; // 점수를 띄울 화면의 텍스트 칸

    private Rigidbody rb;
    private int score = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        UpdateScoreText(); // 게임 시작 시 "점수: 0"으로 표시
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // W(moveVertical)를 누르면 X축 방향으로, D(moveHorizontal)를 누르면 Z축 방향으로 움직이게 자리를 바꿨습니다.
Vector3 movement = new Vector3(-moveVertical, 0.0f, moveHorizontal);
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
            score = score + 1;
            UpdateScoreText(); // 동전을 먹을 때마다 점수 글자를 업데이트
        }
    }

    // 점수 글자를 바꿔주는 역할을 하는 함수
// 점수 글자를 바꿔주는 역할을 하는 함수
    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;

        // 만약 점수가 5점(맵에 있는 동전 개수) 이상이 되면
        if (score >= 8)
        {
            scoreText.text = "Game Clear!!!"; // 텍스트를 클리어 메시지로 바꿈
        }
    }
}