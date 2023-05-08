using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoyobjectByTouch : MonoBehaviour
{
    // Start is called before the first frame update



    // Update is called once per frame
    void Update()
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
}
