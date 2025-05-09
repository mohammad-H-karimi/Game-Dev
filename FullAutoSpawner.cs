
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullAutoSpawner : MonoBehaviour
{
    private GameObject character;
    private List<GameObject> balls = new List<GameObject>();

    public float distanceInFront = 2f;
    public float spawnInterval = 0.5f;
    public float destroyInterval = 0.5f;

    void Start()
    {
        CreateCharacter();
        StartCoroutine(SpawnAndDestroyBalls());
    }

    void CreateCharacter()
    {
        character = GameObject.CreatePrimitive(PrimitiveType.Cube);
        character.name = "PlayerCharacter";
        character.transform.position = new Vector3(0, 0.5f, 0);
    }

    IEnumerator SpawnAndDestroyBalls()
    {
        for (int i = 0; i < 10; i++)
        {
            Vector3 spawnPos = character.transform.position + character.transform.forward * distanceInFront;
            spawnPos.y = 0.5f;

            GameObject ball = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            ball.transform.position = spawnPos;
            ball.name = "Ball_" + i;

            balls.Add(ball);

            yield return new WaitForSeconds(spawnInterval);
        }

        for (int i = 0; i < balls.Count; i++)
        {
            Destroy(balls[i]);
            yield return new WaitForSeconds(destroyInterval);
        }
    }
}
