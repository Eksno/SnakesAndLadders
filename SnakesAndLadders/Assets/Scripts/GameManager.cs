using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject p1;
    public GameObject p2;

    [SerializeField] int p1Location = 1;
    [SerializeField] int p2Location = 1;

    [SerializeField] private int winner = 0;
    [SerializeField] private int move = 0;
    [SerializeField] int i;

    [SerializeField] bool moving = false;
    GameObject movingPlayer;
    Vector3 destination;

    // Start is called before the first frame update
    void Start()
    {
        p1.transform.position = new Vector3(-4.3f, 0, -4.3f);
        p2.transform.position = new Vector3(-4.7f, 0, -4.7f);
    }

    void Update()
    {
        if (winner == 0 && moving == false)
        {
            int p1CLocation = CheckLocation(p1Location);
            int p2CLocation = CheckLocation(p2Location);

            if (p1CLocation != p1Location)
            {
                moving = true;
                movingPlayer = p1;

                p1Location = p1CLocation;
                destination = GetDestination(p1Location);
            }
            else if (p2CLocation != p2Location)
            {
                moving = true;
                movingPlayer = p2;

                p2Location = p2CLocation;
                destination = GetDestination(p2Location);
            }

            else
            {
                if (move % 2 == 0)
                {
                    moving = true;
                    movingPlayer = p1;

                    i = Random.Range(1, 7);
                    p1Location = CalculateMove(i, p1Location);
                    destination = GetDestination(p1Location);
                }
                else
                {
                    moving = true;
                    movingPlayer = p2;
                    
                    i = Random.Range(1, 7);
                    p2Location = CalculateMove(i, p2Location);
                    destination = GetDestination(p2Location);
                }
                move++;
            }
        }
        if (moving == true)
        {
            movingPlayer.transform.position = Vector3.Lerp(movingPlayer.transform.position,
                                                           destination, 5 * Time.deltaTime);

            if (Vector3.Distance(movingPlayer.transform.position, destination) < 0.01f)
                moving = false;
        }
    }

    int CalculateMove(int i, int pLocation)
    {
        pLocation += i;
        if (pLocation > 100)
        {
            pLocation = 100 - (pLocation - 100);
        }
        return pLocation;
    }

    int CheckLocation(int pLocation)
    {
        switch(pLocation)
        {
            case 4:
                pLocation = 14;
                break;
            case 9:
                pLocation = 31;
                break;
            case 17:
                pLocation = 7;
                break;
            case 20:
                pLocation = 38;
                break;
            case 28:
                pLocation = 84;
                break;
            case 40:
                pLocation = 59;
                break;
            case 51:
                pLocation = 67;
                break;
            case 63:
                pLocation = 81;
                break;
            case 64:
                pLocation = 60;
                break;
            case 89:
                pLocation = 26;
                break;
            case 95:
                pLocation = 75;
                break;
            case 99:
                pLocation = 78;
                break;
            case 100:
                winner = (move % 2) + 1;
                break;
        }
        return pLocation;
    }

    Vector3 GetDestination(int pLocation)
    {
        int x = (pLocation - 1) % 10;
        int y = ((pLocation - 1) / 10) % 10;

        destination = new Vector3((x - 4.5f) * -((y % 2) * 2 - 1), 0, y - 4.5f);
        return destination;
    }
}
