using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstacleGeneration : MonoBehaviour
{
    public GameObject mediumHeight;
    public GameObject tallHeight;
    public GameObject playerObject;
    public int playerDistance;
    public Text distanceText;
    public float baseScoreTimer;
    private float scoreTimer;
    public float playerSpeed;
    private Vector3[] laneNumber;
    public GameObject groundObject;
    public float obsDist;
    public float baseObsDist;
    private Vector3 finalObsPos;
    public int numberOfInitialObs;

    // Start is called before the first frame update
    void Start()
    {
        playerSpeed = 1;
        playerDistance = 0;
        laneNumber = new Vector3[3];
        laneNumber[0] = new Vector3(-10, 0, 0);
        laneNumber[1] = new Vector3(0, 0, 0);
        laneNumber[2] = new Vector3(10, 0, 0);
        distanceText.text = playerDistance.ToString();
        scoreTimer = baseScoreTimer/playerSpeed;
        obsDist = baseObsDist;

        /*if (playerDistance % 2 == 0)
        {
            var mediumPrefab = Instantiate(mediumHeight, playerObject.transform.position + playerObject.transform.forward * 50f, Quaternion.identity) as GameObject;
            mediumPrefab.transform.position = new Vector3(laneNumber[0].x, mediumPrefab.transform.position.y, mediumPrefab.transform.position.z);
            var tallPrefab = Instantiate(tallHeight, playerObject.transform.position + playerObject.transform.forward * 50f, Quaternion.identity) as GameObject;
            tallPrefab.transform.position = new Vector3(laneNumber[2].x, tallPrefab.transform.position.y, tallPrefab.transform.position.z);

        }*/

        for(int i = 0;i<numberOfInitialObs;i++)
        {
            int randomNo = Random.Range(0, 3);
            int randomNo2;
            do
            {
                randomNo2 = Random.Range(0, 3);
            }
            while (randomNo2 == randomNo);

            var mediumPrefab = Instantiate(mediumHeight, playerObject.transform.position + playerObject.transform.forward * obsDist, Quaternion.identity) as GameObject;
            mediumPrefab.transform.position = new Vector3(laneNumber[randomNo].x, mediumPrefab.transform.position.y, mediumPrefab.transform.position.z);
            Destroy(mediumPrefab.gameObject, 60);


            var tallPrefab = Instantiate(tallHeight, playerObject.transform.position + playerObject.transform.forward * obsDist, Quaternion.identity) as GameObject;
            tallPrefab.transform.position = new Vector3(laneNumber[randomNo2].x, tallPrefab.transform.position.y, tallPrefab.transform.position.z);
            Destroy(tallPrefab.gameObject, 60);

            obsDist += baseObsDist;

            if (i == numberOfInitialObs - 1)
                finalObsPos = mediumPrefab.transform.position;

            finalObsPos = new Vector3(0, 0, finalObsPos.z);
        }

    }

    // Update is called once per frame
    void Update()
    {
         if (scoreTimer >= 0)
             scoreTimer -= Time.deltaTime;
         else
         {
             playerDistance += 1;
            if (playerDistance % 1 == 0)
            {
                
                int randomNo = Random.Range(0, 3);
                int randomNo2;
                do
                {
                    randomNo2 = Random.Range(0, 3);
                }                  
                while (randomNo2 == randomNo);

                var mediumPrefab = Instantiate(mediumHeight, finalObsPos + playerObject.transform.forward * baseObsDist, Quaternion.identity) as GameObject;
                mediumPrefab.transform.position = new Vector3(laneNumber[randomNo].x, mediumPrefab.transform.position.y, mediumPrefab.transform.position.z);
                Destroy(mediumPrefab.gameObject, 60);
                var tallPrefab = Instantiate(tallHeight, finalObsPos + playerObject.transform.forward * baseObsDist, Quaternion.identity) as GameObject;
                tallPrefab.transform.position = new Vector3(laneNumber[randomNo2].x, tallPrefab.transform.position.y, tallPrefab.transform.position.z);
                Destroy(mediumPrefab.gameObject, 60);
                finalObsPos = mediumPrefab.transform.position;

            }

            if(playerDistance %5 == 0)
            {
                var newGround = Instantiate(groundObject, playerObject.transform.position + playerObject.transform.forward * 100f, Quaternion.identity) as GameObject;
                newGround.transform.position = new Vector3(0, 0, newGround.transform.position.z);

            }
            distanceText.text = playerDistance.ToString();
            scoreTimer = baseScoreTimer / playerSpeed;
         }


       

    }
}
