using UnityEngine;

public class ShooterBehavior : MonoBehaviour {

    public float range;
    public GameObject ball;
    public float speed;
    private int direction;

    private void Start()
    {
        direction = -1;
    }

    void Update () {


        if (Time.frameCount%40==0){
            GameObject newBall = Instantiate(ball, transform.position, transform.rotation) as GameObject;
            direction++;
            switch (direction)
            {
                case 0:
                    newBall.GetComponent<Rigidbody>().velocity = new Vector3(-1, 0, 1).normalized * speed;
                    break;

                case 1:
                    newBall.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 1).normalized * speed;
                    break;

                case 2:
                    newBall.GetComponent<Rigidbody>().velocity = new Vector3(1, 0, 1).normalized * speed;
                    break;

                case 3:
                    newBall.GetComponent<Rigidbody>().velocity = new Vector3(1, 0, 0).normalized * speed;
                    break;

                case 4:
                    newBall.GetComponent<Rigidbody>().velocity = new Vector3(1, 0, -1).normalized * speed;
                    break;

                case 5:
                    newBall.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -1).normalized * speed;
                    break;

                case 6:
                    newBall.GetComponent<Rigidbody>().velocity = new Vector3(-1, 0, -1).normalized * speed;
                    break;

                case 7:
                    newBall.GetComponent<Rigidbody>().velocity = new Vector3(-1, 0, 0).normalized * speed;
                    direction = -1;
                    break;

            }
            newBall.transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);newBall.AddComponent<DamagePlayer>();
            var destroyTime = 0.5f;
            Destroy(newBall, destroyTime);
        }
    }
}