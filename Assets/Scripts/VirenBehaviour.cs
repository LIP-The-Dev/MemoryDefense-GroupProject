using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirenBehaviour : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private int lives;

    [SerializeField] private int damage;
    private Vector2 direction = new Vector2(1, 0);
    private PfadBehaviour pfadBehaviour;
    [SerializeField] private int grantsScoreOf = 1;

    private int EckPointsPassed = 0;
    // Start is called before the first frame update
    void Start()
    {
        pfadBehaviour = PfadBehaviour.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {
            Move();
    }

    public void Move()
    {
        Vector2 nextEckPoint = pfadBehaviour.getNextEckPoint(EckPointsPassed);
        float distanceToMove = speed * Time.deltaTime;
        float distanceToEck = Vector2.Distance(this.transform.position, nextEckPoint);
        float distanceAfterEck = distanceToMove - distanceToEck;
        if (distanceToMove > distanceToEck)
        {
            transform.position = nextEckPoint;
            turn(pfadBehaviour.directionToTurnTo(EckPointsPassed));
            transform.Translate(distanceAfterEck *direction);
        }
        else
        {
            transform.Translate(direction*distanceToMove);
        }
        
    }
    
    public void turn(int directionInt)
    {
        switch (directionInt)
        {
            case 1: direction = new Vector2(0, 1); break;
            case 2: direction = new Vector2(1, 0); break;
            case 3: direction = new Vector2(0, -1); break;
            case 4: direction = new Vector2(-1, 0); break;
            
            
        }

        EckPointsPassed++;
    }

    public int getDamage()
    {
        return damage;
    }

    public void looseLife(int damage)
    {
        lives -= damage;
        if (lives <= 0)
        {
            Destroy(this.gameObject);
            GameManagerBehaviour.GetInstance().addToScore(grantsScoreOf);
        }
    }

    public void setVirus(int ilives, int idamage, float ispeed)
    {
        lives = ilives;
        speed = ispeed;
        damage = idamage;
    }
}