using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PfadBehaviour : MonoBehaviour
{
    private Vector2[] EckPoints;

    private int anzEckPoints = 4;
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
        EckPoints[0]= new Vector2(, 0);
        EckPoints[1]= new Vector2(2, 1);
        EckPoints[2]= new Vector2(0, 1);
        EckPoints[3] = new Vector2(0, 0);

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