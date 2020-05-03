using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableWin : MonoBehaviour
{
	private bool m_winGame;
    // Start is called before the first frame update
    void Start()
    {
		m_winGame = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(m_winGame)
		{
			Debug.Log("Victory Noises");
		}
    }

	public void SetWinGame(bool t_winState)
	{
		m_winGame = t_winState;
	}

	public bool GetWinGame()
	{
		return m_winGame;
	}
}
