using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    // Start is called before the first frame update


    public int scoreValue = 10;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Circle"))
        {

            ScoreController.Instance.IncreaseScore(scoreValue);
            Destroy(collision.gameObject); // Đối tượng bị bắn
            Destroy(gameObject); // Viên đạn



        }


    }
}