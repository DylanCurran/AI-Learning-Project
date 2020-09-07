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
		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");

		m_movement = transform.right * x + transform.forward * z;
		GetComponent<Rigidbody>().position += m_movement * m_speed * Time.deltaTime; 
		//if(Input.GetKey(KeyCode.W))
		//{
		//	m_movement = new Vector3((m_speed * Mathf.Cos(m_currentRotation * degToRad)), 0.0f, (m_speed * Mathf.Sin(m_currentRotation * degToRad)));
		//	GetComponent<Rigidbody>().position += m_movement * Time.deltaTime;
		//}
		//else if(Input.GetKey(KeyCode.S))
		//{
		//	m_movement = new Vector3((m_speed * Mathf.Cos((m_currentRotation- 180) * degToRad)), 0.0f, (m_speed * Mathf.Sin((m_currentRotation - 180) * degToRad)));
		//	GetComponent<Rigidbody>().position += m_movement * Time.deltaTime;
		//}
		 
		//if(Input.GetKey(KeyCode.A))
		//{
		//	m_currentRotation += m_turnSpeed;
		//	m_isTurning = true;
		//}
		//else if(Input.GetKey(KeyCode.D))
		//{
		//	m_currentRotation -= m_turnSpeed;
		//	m_isTurning = true;
		//}
		//else
		//{
		//	m_isTurning = false;
		//}
		
	}

	public bool checkTurning()
	{
		return m_isTurning;
	}
}



