using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    private Rigidbody targetRb;
    private GameManager gameManager;
    private float minSpeed = 12.0f;
    private float maxSpeed = 16.0f;
    private float maxTorque = 10.0f;
    private float xRange = -4.0f;
    private float ySpawnPos = -6.0f;
    public int pointValue;

    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        transform.position = RandomSpawnPos();
    }

    // Update is called once per frame
    void Update()
    {
        DestroyObject();
    }

    private void DestroyObject()
    {
        //Loops through an array that gets multiple touches
        for(int i = 0;i < Input.touchCount;i++)
        {
            //test for touch input/if a touch is detected
            if(Input.touchCount > 0)
            {
                //Loops through the 
                if(Input.touches[i].phase == TouchPhase.Began)
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.touches[i].position);

                    RaycastHit hit;

                    if(Physics.Raycast(ray, out hit))
                    {
                        if(hit.collider != null)
                        {
                            gameManager.UpdateScore(pointValue);
                            Destroy(hit.collider.gameObject);
                            //Color color = new Color(Random.value, Random.value, Random.value);
                            //hit.collider.gameObject.GetComponent<MeshRenderer>().material.color = color;
                        }
                        
                    }
                    
                }
            }

            
            //Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.touches[i].position);
            //Debug.DrawLine(Vector3.zero, touchPosition, Color.green);
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        FindObjectOfType<GameManager>().GameOver();
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange,xRange), ySpawnPos);
    }
}
