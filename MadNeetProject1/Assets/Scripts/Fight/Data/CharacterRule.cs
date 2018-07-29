using System.Collections.Generic;

public class CharacterRule
{
	public struct CharacterInfo
	{
		public string Name;
		public float Speed;
		public int Blood;
		public int Attack;
	}

	string[][] datas = new string[5][] {
		new string[4]{ "廢物主人翁", "0.5", "100", "1" },
		new string[4]{ "護衛A", "0.5", "1", "1" },
		new string[4]{ "護衛B", "0.5", "5", "1" },
		new string[4]{ "護衛C", "0.5", "15", "5" },
		new string[4]{ "魔王", "2", "50", "2" }
	};

	private Dictionary<string, CharacterInfo> AllInfos = null;

	public CharacterRule ()
	{
		this.AllInfos = new Dictionary<string, CharacterInfo> ();
		readInfos (this.datas);
	}

	private void readInfos (string[][] TargetDatas)
	{
		string name = string.Empty;
		float speed = 0.0f;
		int blood = 0;
		int attack = 0;
		CharacterInfo info;

		for (int i = 0; i < TargetDatas.Length; ++i) {
			readOneInfo (TargetDatas[i], ref name, ref speed, ref blood , ref attack);
			info = createCharacterInfo (name, speed, blood , attack);
			this.AllInfos.Add (name,info);
		}
	}

	private void readOneInfo (string[] TargetData ,ref string name , ref float speed,ref int blood, ref int attack)
	{
		name = TargetData[0];
		if (float.TryParse (TargetData [1], out speed)) {
		} else {
			speed = 1.0f;
		};
		int.TryParse (TargetData [2], out blood);
		int.TryParse (TargetData [3], out attack);
	}

	private CharacterInfo createCharacterInfo(string name ,float speed,int blood,int attack){
		CharacterInfo newInfo = new CharacterInfo();
		newInfo.Name = name;
		newInfo.Speed = speed;
		newInfo.Blood = blood;
		newInfo.Attack = attack;
		return newInfo;
	}

	public CharacterInfo getCharacterInfo (string TargetName)
	{
		if (this.AllInfos.ContainsKey (TargetName)) {
			return this.AllInfos [TargetName];
		} else {
			CharacterInfo info = createCharacterInfo ("", 1, 1 ,1);
			return info;
		}
	}
}
