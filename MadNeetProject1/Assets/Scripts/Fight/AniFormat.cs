
public class AniFormat {
	public struct CharacterAniInfo{
		public string Name;
		public float Speed;
	}

	public struct AttackAniInfo{
		public string AttackName;
		public string[] HurtNames;
	}

	public struct DeadAniInfo{
		public string[] Names;
	}

	public CharacterAniInfo[] AllCharacters;
	public AttackAniInfo AttackInfo;
	public DeadAniInfo DeadInfo;
}
