using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

	[SerializeField] private float m_speed;
	private Vector3 m_movement;
	private Vector3 m_playerPosition;
	private float m_currentRotation;
	private float degToRad = Mathf.Acos(-1f) / 180;
	[SerializeField] private float m_turnSpeed = 5.0f;
	private float m_turn = 0.0f;
	bool m_isTurning = false;
    // Start is called before the first frame update
    void Start()
    {
        m_movement = new Vector3( 0.0f,0.0f,0.0f);
		m_playerPosition = transform.position;
		m_currentRotation = 270f;
	}

    // Update is called once per frame
    void Update()
    {
		if(Input.GetKey(KeyCode.W))
		{
			m_movement = new Vector3((m_speed * Mathf.Cos(m_currentRotation * degToRad)), 0.0f, (m_speed * Mathf.Sin(m_currentRotation * degToRad)));
			GetComponent<Rigidbody>().position += m_movement * Time.deltaTime;
		}
		else if(Input.GetKey(KeyCode.S))
		{
			m_movement = new Vector3((m_speed * Mathf.Cos((m_currentRotation- 180) * degToRad)), 0.0f, (m_speed * Mathf.Sin((m_currentRotation - 180) * degToRad)));
			GetComponent<Rigidbody>().position += m_movement * Time.deltaTime;
		}
		 
		if(Input.GetKey(KeyCode.A))
		{
			m_currentRotation += m_turnSpeed;
			m_isTurning = true;
		}
		else if(Input.GetKey(KeyCode.D))
		{
			m_currentRotation -= m_turnSpeed;
			m_isTurning = true;
		}
		else
		{
			m_isTurning = false;
		}
		//m_input.z = Input.GetAxis(m_moveHorizontal);
		//m_input.x = Input.GetAxis(m_moveVertical);

			//m_movement.x = m_input.x * -m_speed * Time.deltaTime;
			//TurnPlayer();
			////m_movement.z = m_input.z * m_speed * Time.deltaTime;
			//GetComponent<Rigidbody>().transform.position += m_movement;

			//GetComponent<Rigidbody>().MovePosition(transform.position + m_movement);
	}

	//void TurnPlayer()
	//{
	//	m_turn =   m_turnSpeed * Time.deltaTime;

	//	Quaternion turnRotation = Quaternion.Euler(0f, m_turn, 0f);
	//	GetComponent<Rigidbody>().MoveRotation(GetComponent<Rigidbody>().rotation * turnRotation);

	//	if(m_input.z != 0)
	//	{
	//		m_isTurning = true;
	//	}
	//	else
	//	{
	//		m_isTurning = false;
	//	}
	//}
	public bool checkTurning()
	{
		return m_isTurning;
	}
}



