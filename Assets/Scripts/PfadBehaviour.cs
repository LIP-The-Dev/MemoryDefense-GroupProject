using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PfadBehaviour : MonoBehaviour
{
    private Vector2[] EckPoints;

    private int anzEckPoints = 12;
    private static PfadBehaviour instance;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        instance = this;
    }

    public static PfadBehaviour GetInstance()
    {
        return instance;
    }
    void Start()
    {
        EckPoints = new Vector2[anzEckPoints];
        EckPoints[0]= new Vector2(5, 10);
        EckPoints[1]= new Vector2(5, 6);
        EckPoints[2]= new Vector2(3, 6);
        EckPoints[3] = new Vector2(3, 3);
        EckPoints[4] = new Vector2(10, 3);
        EckPoints[5] = new Vector2(10, 12);
        EckPoints[6] = new Vector2(17, 12);
        EckPoints[7] = new Vector2(17, 6);
        EckPoints[8] = new Vector2(20, 6);
        EckPoints[9] = new Vector2(20,9);
        EckPoints[10] = new Vector2(24, 9);
        EckPoints[11] = new Vector2(24, 3);
        

    }

    public Vector2 getNextEckPoint(int eckPointsPassed)
    {
        return EckPoints[eckPointsPassed];
    }

    public int directionToTurnTo(int onEckPointIndex)
    {
        Vector2 directionVector = EckPoints[onEckPointIndex+1] - EckPoints[onEckPointIndex];
        if (directionVector.y > 0)
        {
            return 1;
        }
        if (directionVector.x > 0)
        {
            return 2;
        }
        if (directionVector.y < 0)
        {
            return 3;
        }
        if (directionVector.x < 0)
        {
            return 4;
        }

        return -1;
    }

    // Update is called once per frame
    void Update()
    {

    }
}