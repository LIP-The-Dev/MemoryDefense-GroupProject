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
        EckPoints[0]= new Vector2(5.5f, 10.5f);
        EckPoints[1]= new Vector2(5.5f, 6.5f);
        EckPoints[2]= new Vector2(3.5f, 6.5f);
        EckPoints[3] = new Vector2(3.5f, 3.5f);
        EckPoints[4] = new Vector2(10.5f, 3.5f);
        EckPoints[5] = new Vector2(10.5f, 12.5f);
        EckPoints[6] = new Vector2(17.5f, 12.5f);
        EckPoints[7] = new Vector2(17.5f, 6.5f);
        EckPoints[8] = new Vector2(20.5f, 6.5f);
        EckPoints[9] = new Vector2(20.5f,9.5f);
        EckPoints[10] = new Vector2(24.5f, 9.5f);
        EckPoints[11] = new Vector2(24.5f, -1.5f);
        

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