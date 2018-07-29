using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightProcess {

    private CharacterMgr CharacterMgr = null;
    private FightLogic FightLogic = null;
    private FightAniMenager FightAniMgr = null;

    public FightProcess(FightAniMenager FightAniMgr)
    {
        this.CharacterMgr = new CharacterMgr();
        this.FightLogic = new FightLogic();
        this.FightAniMgr = FightAniMgr;

        StartFight();
    }

    public void StartFight()
    {
        AniFormat AniFormat = new AniFormat();
        this.CharacterMgr.createCharacters(new string[] { "廢物主人翁", "魔王" });
        this.CharacterMgr.overrideCharacterInfo(ref AniFormat);
        this.FightAniMgr.showCurrentAni(AniFormat);
    }

    private void addNewCharacter(string CharacterName)
    {
        AniFormat AniFormat = new AniFormat();
        this.CharacterMgr.createCharacters(CharacterName);
        this.CharacterMgr.overrideCharacterInfo(ref AniFormat);
        this.FightAniMgr.showCurrentAni(AniFormat);
    }

    private void fightCharacter(string FightName)
    {
        FightFormat format = this.CharacterMgr.getFightCharactersFormat(FightName);
        this.FightLogic.acttackProcessAndOverrideFormat(ref format);
        this.CharacterMgr.overrideDataByFightFormat(format);
        this.FightAniMgr.showCurrentAni(format.FinishFormat);
        checkForOneTeamOutProcess();
    }

    private void checkForOneTeamOutProcess()
    {
        if (this.CharacterMgr.checkIsOneTeamOut())
        {
            this.FightAniMgr.showGameOver();
        }
    }
}
