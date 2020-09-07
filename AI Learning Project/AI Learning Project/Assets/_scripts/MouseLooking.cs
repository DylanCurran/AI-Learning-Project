using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLooking : MonoBehaviour
{
	public float m_mouseSensitivity = 100f;

	public Transform m_player;

	float m_yView = 0;
    // Start is called before the first frame update
    void Start()
    {
		Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
		float m_mouseX = Input.GetAxis("Mouse X") * m_mouseSensitivity * Time.deltaTime;
		float m_mouseY = Input.GetAxis("Mouse Y") * m_mouseSensitivity * Time.deltaTime;

		m_yView -= m_mouseY;
		m_yView = Mathf.Clamp(m_yView, -20f, 20f);

		transform.localRotation = Quaternion.Euler(m_yView, 0f, 0f);
		m_player.Rotate(Vector3.up * m_mouseX);
    }
}
