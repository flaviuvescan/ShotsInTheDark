using UnityEngine;
using System.Collections;

public class PlaySong : MonoBehaviour {
	
	private static PlaySong instance = null;
	public static PlaySong Instance {
		get { return instance; }
	}
	void Awake() 
	{
		if (instance != null && instance != this) 
		{
			Destroy(this.gameObject);
			return;
		} 
		else 
		{
			instance = this;
		}
		DontDestroyOnLoad(this.gameObject);
	}	
}
