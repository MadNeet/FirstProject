using UnityEngine;

public class FightControl : MonoBehaviour
{
	[SerializeField]private FightCharacter[] AllCharacter = null;

	public void showCharacter (string name)
	{
		FightCharacter character;
		if (!tryGetCharacter (name, out character)) {
			character = getLastEmptyCharacter ();
			character.born (name);
		}
	}

	public void showAttack (string AttackName, string[] HurtNames)
	{
		FightCharacter AttackCharacter;
		FightCharacter[] HurtCharacters;
		if (tryGetCharacter (AttackName, out AttackCharacter) && tryGetCharacter (HurtNames, out HurtCharacters)) {
			AttackCharacter.attack ();
			for (int i = 0; i < HurtCharacters.Length; ++i) {
				HurtCharacters [i].hurt ();
			}
		}
	}

	public void showDead (string[] DeadNames)
	{
		for (int i = 0; i < DeadNames.Length; ++i) {
			showDead (DeadNames [i]);
		}
	}

	public void showDead (string DeadName)
	{
		FightCharacter character;
		if (tryGetCharacter (DeadName, out character)) {
			character.dead ();
		}
	}

	private bool tryGetCharacter (string[] names, out FightCharacter[] characters)
	{
		FightCharacter[] AllFightCharacter = new FightCharacter[names.Length];
		for (int i = 0; i < names.Length; ++i) {
			if (tryGetCharacter (names [i], out AllFightCharacter [i])) {
				if ((i + 1) == names.Length) {
					characters = AllFightCharacter;
					return true;
				}
			} else {
				break;
			}
		}
		characters = null;
		return false;
	}

	private bool tryGetCharacter (string name, out FightCharacter character)
	{
		for (int i = 0; i < this.AllCharacter.Length; ++i) {
			if (!string.IsNullOrEmpty (this.AllCharacter [i].CharacterName) && this.AllCharacter [i].CharacterName.Equals (name)) {
				character = this.AllCharacter [i];
				return true;
			}
		}
		character = null;
		return false;
	}

	private FightCharacter getLastEmptyCharacter ()
	{
		for (int i = 0; i < this.AllCharacter.Length ; ++i) {
			if (string.IsNullOrEmpty (this.AllCharacter [i].CharacterName)) {
				return this.AllCharacter [i];
			}
		}
		return null;
	}
}
