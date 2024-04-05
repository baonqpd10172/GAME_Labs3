using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SquareController : MonoBehaviour
{
    // Start is called before the first frame update
    public float timeRemaining = 60;
    public Text countdownText;
    public Text scoreText;
    private int score = 0;
    public float moveSpeed = 5f;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    

    private Vector2 shootDirection;
    void Start()
    {
        StartCoroutine(Countdown());
        UpdateScoreText();
    }
    IEnumerator Countdown()

    {
        while (timeRemaining > 0)
        {
            yield return new WaitForSeconds(1);
            timeRemaining--;
            countdownText.text = "Time: " + timeRemaining.ToString();

        }
        countdownText.text = "GAME OVER";
    }
    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            shootDirection = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            shootDirection = Vector2.right;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            shootDirection = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        { 
            shootDirection = Vector2.down;
        }
        if (Input.GetKeyDown(KeyCode.Space)) 
        { 
            Shoot ();
        }
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal, vertical, 0f).normalized;
        transform.Translate(movement * 5f * Time.deltaTime);
    }
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Circle"))
        {
            Vector2 firstPosition = new Vector2(-7, 0);
            transform.position = firstPosition;
        }

        if (collision.gameObject.name.Equals("Box"))
        {
            Debug.Log("Win");
            LoadNextScene();
        }
        if (collision.gameObject.name.Equals("Pinwheel"))
        {
            Vector2 firstPosition = new Vector2(-6, -3);
            transform.position = firstPosition;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("MapEdge"))
        {
            Debug.Log("xxxxxx");
            Vector2 fistPosition = new Vector2(-6, -3);
            transform.position = fistPosition;
        }
    }
    void Shoot()
    {
        GameObject newBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Rigidbody2D bulletRb = newBullet.GetComponent<Rigidbody2D>();
        if (bulletRb != null)
        {

            bulletRb.velocity = shootDirection * bulletSpeed;  
        }
    }
}