using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupCollectable : MonoBehaviour
{
	public GameObject m_player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	private void OnCollisionEnter(Collision other)
	{
		if(other.rigidbody.tag == m_player.tag)
		{
			Destroy(gameObject);
		}
	}
}
