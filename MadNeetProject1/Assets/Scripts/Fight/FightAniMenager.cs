using UnityEngine;

public class FightAniMenager : MonoBehaviour
{
	[SerializeField]private TimerControl Timer = null;
	[SerializeField]private BrandControl Brand = null;
	[SerializeField]private FightControl FightAni = null;

	public delegate void CreateCharacterCallBack (string name);

	public delegate void CharacterAttackCallBack (string Name);

	private CharacterAttackCallBack characterMoveCallBack = null;
	private CreateCharacterCallBack createCharacterCallBack = null;

	void Start ()
	{
		/*Brand.init (clickShowBtn);
		Timer.init (timeoutCharacterAction);*/
		new FightMenager (this);
	}

	public void setCharacterAttackCallBack (CharacterAttackCallBack callBack)
	{
		this.characterMoveCallBack = callBack;
	}

	public void setCreateCharacterCallBack (CreateCharacterCallBack callBack)
	{
		this.createCharacterCallBack = callBack;
	}

	public void showGameOver(){
		this.Timer.IsNeedStop = true;
		Debug.Log ("GameOver");
	}

	public void showCurrentAni (AniFormat format)
	{
		if (format.AllCharacters != null) {
			for (int i = 0; i < format.AllCharacters.Length; i++) {
				showCharacter (format.AllCharacters [i].Name, format.AllCharacters [i].Speed);
			}
		}

		if (!string.IsNullOrEmpty(format.AttackInfo.AttackName)) {
			showAttack (format.AttackInfo.AttackName, format.AttackInfo.HurtNames);
		}

		if (format.DeadInfo.Names != null) {
			showDead (format.DeadInfo.Names);
		}
	}

	private void timeoutCharacterAction (string moveName)
	{
		this.characterMoveCallBack (moveName);
	}

	private void clickShowBtn (string name)
	{
		if (createCharacterCallBack != null) {
			createCharacterCallBack (name);
		}
	}

	private void showCharacter (string Name, float Speed)
	{
		this.FightAni.showCharacter (Name);
		this.Timer.addCharacterTimer (Name, Speed);
	}

	private void showAttack (string AttackName, string[] HurtNames)
	{
		this.FightAni.showAttack (AttackName, HurtNames);
		this.Timer.reflashCharacterTimer (AttackName);
	}

	private void showDead (string[] DeadNames)
	{
		this.FightAni.showDead (DeadNames);
		this.Timer.removeCharacterTimer (DeadNames);
	}

}