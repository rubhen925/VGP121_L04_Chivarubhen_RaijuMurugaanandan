using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{

    public float bgWidth;
    public float bgHeight;
    public Player player;

    public GameObject background;
    public List<GameObject> instantiatedBgs = new List<GameObject>();

    Vector3 checkPoint1;
    Vector3 checkPoint2;

    public float parallaxScale = 0.5f;
    public float zOffset;

    // Use this for initialization
    void Start()
    {
        Vector3 startPos = player.transform.position + zOffset * Vector3.forward ;
        startPos -= 3 * bgWidth * Vector3.right / 2;
        startPos += bgWidth / 2 * Vector3.right;
        for (int i = 0; i < 3; i++)
        {
            Vector3 pos = startPos + i * bgWidth * Vector3.right;
            GameObject spawnedBg = Instantiate(background, pos, Quaternion.identity);
            instantiatedBgs.Add(spawnedBg);
            spawnedBg.transform.parent = transform;
        }
        checkPoint1 = player.transform.position;
        checkPoint1 += bgWidth * Vector3.right / 2;

        checkPoint2 = player.transform.position;
        checkPoint2 -= bgWidth * Vector3.right / 2;
    }

    // Update is called once per frame
    void Update()
    {
        checkPoint1 = instantiatedBgs[2].transform.position;
        checkPoint1 -= Vector3.right * bgWidth / 2;

        if (player.transform.position.x > checkPoint1.x)
        {
            GameObject firstBg = instantiatedBgs[0];
            instantiatedBgs.Remove(firstBg);
            firstBg.transform.position += bgWidth * 3 * Vector3.right;
            instantiatedBgs.Add(firstBg);
            //checkPoint1 += bgWidth * Vector3.right;
        }

        checkPoint2 = instantiatedBgs[0].transform.position;
        checkPoint2 += Vector3.right * bgWidth / 2;

        if (player.transform.position.x < checkPoint2.x)
        {
            GameObject lastBg = instantiatedBgs[2];
            instantiatedBgs.Remove(lastBg);
            lastBg.transform.position -= bgWidth * 3 * Vector3.right;
            instantiatedBgs.Insert(0, lastBg);
            //checkPoint1 += bgWidth * Vector3.right;
        }

        Vector3 offset = parallaxScale * player.GetHorizontalSpeed() * Vector3.right;
        transform.position += offset;

        Vector3 offsetTwo = parallaxScale * player.GetVerticalSpeed() * Vector3.up;
        transform.position += offsetTwo;
    }
}
