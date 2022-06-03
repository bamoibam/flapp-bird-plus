using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Controller : MonoBehaviour
{
    public float velocity = 3f;
    public float horizontal = 0.3f;
    public float playerdirection = 1f;
    private Rigidbody2D rigidbody;
    private int winCondititon = 0;
    public GameObject targetGameObject ;
    // Start is called before the first frame update
    void Start()
    {   
        Time.timeScale = 1;
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.localScale = new Vector3(playerdirection, 1, 1);

        if(Input.GetMouseButton(0))
        {
            rigidbody.velocity = Vector2.up * velocity;
            rigidbody.AddForce(new Vector2(horizontal * playerdirection,0f), ForceMode2D.Impulse);
        }
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Obstacle")) 
        {
            SceneManager.LoadScene("Game Over");
            Time.timeScale = 0;
        }
        else if (other.gameObject.CompareTag("Wall"))
        {
            playerdirection *= -1f;
        }
        else if (other.gameObject.CompareTag("Coin"))
        {
            winCondititon++;
            if (winCondititon == 3)
            {
                enableNextLevelButton();
            }
            else
            {
                disableNextLevelButton();
            }
        }
    }
    void enableNextLevelButton()
    {
       targetGameObject.SetActive(true);
        Time.timeScale = 0;

    }
    void disableNextLevelButton()
    {
       targetGameObject.SetActive(false);
        Time.timeScale = 1;

    }
}
