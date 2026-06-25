using UnityEngine;

public class coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // 작동하는지 확인용 로그 (콘솔창에 뜸)
        Debug.Log("무언가 부딪힘: " + other.name);

        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}