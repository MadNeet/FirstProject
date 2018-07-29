using UnityEngine;

public class FightCharacter : MonoBehaviour
{
	//private UISprite sprite = null;
	private string Name;
	private bool Alive;
	private bool isAniEnd =false;

	public bool IsAlive {
		get {
			return Alive;
		}
	}

	public string CharacterName {
		get {
			return this.Name;
		}
	}

	void Start ()
	{
		//sprite = GetComponent (typeof(UISprite)) as UISprite;
	}

	public void born (string CharacterName)
	{
		if (Alive) {
			return;
		}
		this.Name = CharacterName;
		setState (true);
	}

	public void dead ()
	{
		if (!Alive) {
			return;
		}
		this.Name = string.Empty;
		setState (false);
	}

	public void attack ()
	{
		if (!Alive) {
			return;
		}

		if (!isAniEnd) {
			//sprite.color = Color.green;
			Invoke ("resetSprite", 0.1f);
			isAniEnd = true;
		}
	}

	public void hurt ()
	{
		if (!Alive) {
			return;
		}

		if (!isAniEnd) {
			//sprite.color = Color.red;
			Invoke ("resetSprite", 0.1f);
			isAniEnd = true;
		}
	}

	private void resetSprite()
	{
		isAniEnd = false;
		//sprite.color = Color.white;
	}

	private void setState (bool isAlive)
	{
		this.Alive = isAlive;
		gameObject.SetActive (isAlive);
	}
}
