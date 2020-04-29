using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPlayer : MonoBehaviour
{
	public GameObject player;
	private float roomWidth;
	private float roomHeight;
	private Vector3[] wanderPos;
	private float ScoreAI = 0;
	bool notColliding;
	Vector3 target;
	// Start is called before the first frame update
	private void Start()
	{
		
		roomWidth = 5;
		roomHeight = 5;
		notColliding = true;
		wanderPos[0] = new Vector3(0f, 0f, 0f);
		wanderPos[1] = new Vector3(10f, 0f, 0f);
		wanderPos[2] = new Vector3(10f, 0f, 10f);
		wanderPos[3] = new Vector3(0f, 0f, 10f);

		target = wanderPos[0];
	}

	// Update is called once per frame
	void Update()
    {
		
		transform.position += (target - transform.position) / 30.0f;
		float tempX = transform.position.x - player.transform.position.x;
		float tempZ = transform.position.z - player.transform.position.z;
		if (Mathf.Sqrt((tempX * tempX) + (tempZ * tempZ)) <= Mathf.Sqrt((roomWidth * roomWidth) + (roomHeight * roomHeight)))
		{
			target = player.transform.position;
			ScoreAI += 0.1f;
		}
		else
		{
			for(int i = 0; i < 4; i++)
			{
				if(transform.position.x - wanderPos[i].x <= 0.2 && transform.position.x - wanderPos[i].x >= -.2 &&
					transform.position.z - wanderPos[i].z <= 0.2 && transform.position.z - wanderPos[i].z >= -.2)
				{
					if (i != 3)
					{
						target = wanderPos[i++];
						ScoreAI -= .1f;
					}
					else
					{
						target = wanderPos[0];
						ScoreAI -= 0.1f;
					}
				}
			}
		}
    }

	void OnColliderEnter(Collider other)
	{
		Debug.Log("Collision Entered");
		if (other.tag == "Player")
		{
			ScoreAI += 1;

		}
	}

	void OnColliderExit(Collider other)
	{
		Debug.Log("Collision Exited");
		notColliding = true;
	}
}
