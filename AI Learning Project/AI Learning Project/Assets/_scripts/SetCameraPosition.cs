using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCameraPosition : MonoBehaviour
{
	public GameObject m_player;
	
	bool m_turnCamera = false;
	private Vector3 differenceOffset;
	private Vector3 compareDifference;
    // Start is called before the first frame update
    void Start()
    {
		differenceOffset = m_player.transform.position - transform.position;
		compareDifference = m_player.transform.position - transform.position;
	}

    // Update is called once per frame
    void Update()
    {
		m_turnCamera = m_player.GetComponent<PlayerController>().checkTurning();
		if (m_turnCamera)
		{
			if (Input.GetKey(KeyCode.A))
			{
				transform.RotateAround(m_player.transform.position, new Vector3(0f, -1f, 0f), 2.5f);
			
			}
			else
			{
				transform.RotateAround(m_player.transform.position, new Vector3(0f, 1f, 0f), 2.5f);
			}
		}
		//else
		//{
		//	transform.RotateAround(m_player.transform.position, new Vector3(0f, 1f, 0f), 0);
		//}


		differenceOffset = m_player.transform.position - transform.position;
    }

	private void LateUpdate()
	{
		if(compareDifference != differenceOffset)
		{
			transform.position += differenceOffset - compareDifference;
		}
	}
}
