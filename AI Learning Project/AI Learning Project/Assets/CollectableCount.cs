using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCount : MonoBehaviour
{
	public GameObject m_containerCollectable;
	private int m_collectableGot;
    // Start is called before the first frame update
    void Start()
    {
		m_collectableGot = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.activeSelf == false)
		{
			m_collectableGot++;

			if(m_collectableGot == 4)
			{
				m_containerCollectable.GetComponent<CollectableWin>().SetWinGame(true);
				Debug.Log("Victory");
			}
		}
    }
}
