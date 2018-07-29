using System.Collections.Generic;

public class CharacterMgr
{
	private CharacterRule CharacterRule = null;
	private List<CharacterData> AllCharacters = null;

	public CharacterMgr ()
	{
		this.CharacterRule = new CharacterRule ();
		this.AllCharacters = new List<CharacterData> ();
	}

	public bool checkIsOneTeamOut ()
	{
		int Justice = 0; 
		int Injustice = 0;
		for(int i = 0 ; i < AllCharacters.Count ; ++i){
			if (AllCharacters [i].Name.Equals ("魔王")) {
				Injustice ++;
			} else {
				Justice ++;
			}
		}
		return !(Justice > 0 && Injustice >0);
	}

	public void createCharacters (string[] TargetNames)
	{
		for (int i = 0; i < TargetNames.Length; ++i) {
			createCharacters (TargetNames [i]);
		}
	}

	public void createCharacters (string TargetName)
	{
		CharacterRule.CharacterInfo info = this.CharacterRule.getCharacterInfo (TargetName);
		CharacterData data = createData (info);
		this.AllCharacters.Add (data);
	}

	public void overrideCharacterInfo (ref AniFormat aniFormat)
	{
		int characterCount = AllCharacters.Count;
		List<AniFormat.CharacterAniInfo> allShowCharacter = new List<AniFormat.CharacterAniInfo> ();
		CharacterData characterData = null;

		for (int i = 0; i < characterCount; ++i) {
			characterData = AllCharacters [i];
			AniFormat.CharacterAniInfo aniInfo = new AniFormat.CharacterAniInfo ();
			aniInfo.Name = characterData.Name;
			aniInfo.Speed = characterData.Speed;
			allShowCharacter.Add (aniInfo);
		}
		aniFormat.AllCharacters = allShowCharacter.ToArray ();
	}

	public CharacterData[] getCharacterInfors (string[] names)
	{
		int namesCount = names.Length;
		CharacterData[] datas = new CharacterData[namesCount];

		for (int i = 0; i < namesCount; ++i) {
			datas [i] = getChacterInfor (names [i]);
		}

		return datas;
	}

	public CharacterData getChacterInfor (string name)
	{
		CharacterData characterData = null;

		if (tryGetCharacterData (name, out characterData)) {
			return characterData.clone ();	
		}

		return null;
	}

	public FightFormat getFightCharactersFormat (string FightName)
	{
		FightFormat format = null;
		CharacterData AttactCharacter;
		CharacterData HurtCharacter;
		if (FightName.Equals ("魔王")) {
			if (tryGetCharacterData (FightName, out AttactCharacter)) {
				overrideFightFormat (out format, AttactCharacter, getNotBossData ());
			}
		} else {
			if (tryGetCharacterData (FightName, out AttactCharacter) && tryGetCharacterData ("魔王", out HurtCharacter)) {
				overrideFightFormat (out format, AttactCharacter, HurtCharacter);
			}
		}
		return format;
	}

	private CharacterData getNotBossData ()
	{
		for (int i = AllCharacters.Count-1 ; i >= 0 ; --i) {
			if (!AllCharacters [i].Name.Equals ("魔王")) {
				return AllCharacters [i];
			}
		}
		return null;
	}

	public void overrideDataByFightFormat (FightFormat format)
	{
		CharacterData character;
		if (tryGetCharacterData (format.AttactCharacter.Name, out character)) {
			overrideData (character, format.AttactCharacter);
		}

		if (tryGetCharacterData (format.HurtCharacter.Name, out character)) {
			overrideData (character, format.HurtCharacter);
		}
	}

	private void overrideData (CharacterData Character, CharacterData NewCharacter)
	{
		if (NewCharacter.Blood > 0) {
			Character = NewCharacter;
		} else {
			AllCharacters.Remove (Character);
		}
	}

	private void overrideFightFormat (out FightFormat format, CharacterData AttactCharacter, CharacterData HurtCharacter)
	{
		format = new FightFormat ();
		format.AttactCharacter = AttactCharacter.clone ();
		format.HurtCharacter = HurtCharacter.clone ();
	}

	private bool tryGetCharacterData (string name, out CharacterData characterData)
	{
		characterData = this.AllCharacters.Find (c => c.Name.Equals (name));

		return (characterData != null);
	}

	private CharacterData createData (CharacterRule.CharacterInfo info)
	{
		CharacterData newData = new CharacterData ();
		newData.Name = info.Name;
		newData.Speed = info.Speed;
		newData.Blood = info.Blood;
		newData.Attack = info.Attack;
		return newData;
	}

}
