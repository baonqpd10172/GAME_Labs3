
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BuletController : MonoBehaviour
{
    public PlayerData playerData;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public int scoreValue = 10;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Circle"))
        {
            playerData.playerScore++;
            PlayerPrefs.SetInt("PlayerScore", playerData.playerScore);
            Destroy(collision.gameObject); // Đối tượng bị bắn
            Destroy(gameObject); // Viên đạn
        }
        if (collision.gameObject.tag.Equals("Pinwheel"))
        {
            playerData.playerScore++;
            PlayerPrefs.SetInt("PlayerScore", playerData.playerScore);
            Destroy(collision.gameObject); // Đối tượng bị bắn
            Destroy(gameObject); // Viên đạn
        }
        if (collision.gameObject.tag.Equals("Box")) // Kiểm tra xem collider khác có phải là viền bản đồ không
        {

            Debug.Log("xx111");
            // Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("MapEdge")) // Kiểm tra xem collider khác có phải là viền bản đồ không
        {
            Destroy(gameObject);
        }

    }

}
