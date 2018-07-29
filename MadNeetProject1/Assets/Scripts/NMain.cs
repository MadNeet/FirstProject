using UnityEngine;
using UnityEngine.SceneManagement;

public class NMain : MonoBehaviour
{
	private static NMain instance = null;

	private FightMenager FightMenager = null;

	public static NMain _Instance {
		get {
			return instance;
		}
	}

	public FightMenager _FightMenager {
		set {
			FightMenager = value;
		}
		get {
			return FightMenager;
		}
	}

	void Start ()
	{
		init ();
		changeSence ();
	}

	private void init ()
	{
		instance = GetComponent (typeof(NMain))as NMain;
		DontDestroyOnLoad (this);
	}

	private void changeSence ()
	{
		SceneManager.LoadScene ("GameScene");
	}
}
