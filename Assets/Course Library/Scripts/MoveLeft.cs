using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 30.0f;
    private PlayerController playerControllerSripts;
    private float leftBound = -10;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerSripts = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerSripts.gameOver == false)
        {
            if (playerControllerSripts.doubleSpeed)
            {
                transform.Translate(Vector3.left * Time.deltaTime * 2 * speed);
            }
            else
            {
                transform.Translate(Vector3.left * Time.deltaTime * speed);
            }
        }

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }

    }
}
