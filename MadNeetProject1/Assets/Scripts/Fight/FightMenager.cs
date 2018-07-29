public class FightMenager
{
	private FightAniMenager FightAniMenager = null;
    private FightProcess FightProcess = null;
    
	public FightMenager (FightAniMenager AniMgr)
	{
        this.FightAniMenager = AniMgr;
        this.FightProcess = new FightProcess(AniMgr);
	}

	
}
