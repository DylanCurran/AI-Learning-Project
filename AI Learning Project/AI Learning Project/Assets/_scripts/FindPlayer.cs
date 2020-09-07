using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPlayer : MonoBehaviour
{
	public GameObject player;
	private float roomWidth;
	private float roomHeight;
	private int m_randomNum;
	private Vector3[] wanderPos = new[] { new Vector3(0f, 0f, 0f), new Vector3(10f, 0f, 0f),
		new Vector3(10f, 0f, 10f), new Vector3(0f, 0f, 10f)};
	private float ScoreAI = 0;
	bool notColliding;
	[SerializeField] float m_speed;
	Vector3 target;
	Random m_random = new Random();
	// Start is called before the first frame update
	private void Start()
	{
		
		roomWidth = 5;
		roomHeight = 5;
		notColliding = true;

		target = wanderPos[1];
	}

	// Update is called once per frame
	void Update()
    {


		float tempX = transform.position.x - player.transform.position.x;
		float tempZ = transform.position.z - player.transform.position.z;
		if (Mathf.Sqrt((tempX * tempX) + (tempZ * tempZ)) <= Mathf.Sqrt((roomWidth * roomWidth) + (roomHeight * roomHeight)))
		{
			target = player.transform.position;
			ScoreAI += 0.1f;
		}
		else
		{
			for (int i = 0; i < 4; i++)
			{
				if(transform.position.x - wanderPos[i].x <= 0.1 && transform.position.x - wanderPos[i].x >= -.1 &&
					transform.position.z - wanderPos[i].z <= 0.1 && transform.position.z - wanderPos[i].z >= -.1)
				{
					if (i != 3)
					{
						m_randomNum = Random.Range(0, 10);
						if (m_randomNum == 7)
						{
							if(i != 0)
							{
								target = wanderPos[i - 1];
							}
							else
							{
								target = wanderPos[i + 3];
							}
						}
						else
						{
							target = wanderPos[i + 1];
						}
						Debug.Log(target);
						ScoreAI -= .1f;
						
					}
					else
					{
						m_randomNum = Random.Range(0, 10);
						if (m_randomNum == 7)
						{
							target = wanderPos[i + 1];
						}
						else
						{
							target = wanderPos[i - 3];
						}
						ScoreAI -= 0.1f;
					}
				}
			}
		}
		transform.position += (target - transform.position) * Time.deltaTime * m_speed;
		
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Player")
		{
			Debug.Log("PLayer hit");
			ScoreAI += 1;

		}
	}

}
