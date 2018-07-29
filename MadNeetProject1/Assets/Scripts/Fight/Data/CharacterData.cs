
public class CharacterData {
	public string Name;
	public float Speed;
	public int Blood;
	public int Attack;
	public bool IsInStage;

	public CharacterData clone()
	{
		CharacterData cloneData = new CharacterData ();
		cloneData.Name = this.Name;
		cloneData.Attack = this.Attack;
		cloneData.Blood = this.Blood;
		cloneData.Speed = this.Speed;

		return cloneData;
	}
}
