
public class FightLogic
{
	public void acttackProcessAndOverrideFormat (ref FightFormat format)
	{
		format.HurtCharacter.Blood -= format.AttactCharacter.Attack;
		AniFormat aniFormat = new AniFormat ();
		aniFormat.AttackInfo.AttackName = format.AttactCharacter.Name;
		aniFormat.AttackInfo.HurtNames = new string[]{ format.HurtCharacter.Name };

		if( 0 >= format.HurtCharacter.Blood ){
			aniFormat.DeadInfo = new AniFormat.DeadAniInfo ();
			aniFormat.DeadInfo.Names = new string[]{ format.HurtCharacter.Name };
		}

		format.FinishFormat = aniFormat;
	}
}
