using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPlayer : MonoBehaviour
{
	public GameObject player;

	bool notColliding;
	// Start is called before the first frame update
	private void Start()
	{
		notColliding = true;
	}

	// Update is called once per frame
	void Update()
    {
		if (notColliding)
		{
			this.transform.position += (player.transform.position - this.transform.position) / 10 * 1 / 60.0f;
		}
		else
		{
			Debug.Log("colliding");
		}
    }

	void OnColliderEnter(Collider other)
	{
		Debug.Log("Collision Entered");
		//if (other.tag == "Wall")
		//{
			notColliding = false;
			this.transform.position += new Vector3(0.0f, 0.0f, 10.0f);

		//}
	}

	void OnColliderExit(Collider other)
	{
		Debug.Log("Collision Exited");
		notColliding = true;
	}
}
