using UnityEngine;
using System.Collections.Generic;

public class TimerControl : MonoBehaviour
{

	public struct TimerFormat
	{
		public string Name;
		public float UpdateCdTime;
        public float OrginalCdTime;
	}

	private List<TimerFormat> AllTimerCharacter = null;

    private float updateTime = 0f;
    private float NextMoveTime = 0f;
	private float BaseRunTime = 0.1f;
	private bool TimeStop = false;

	public delegate void ActiveCallBack (string[] activeName);

	private ActiveCallBack activeCallBack;

	#region 外部使用

	public bool IsUnused {
		get {
			return (AllTimerCharacter.Count == 0);
		}
	}

	public bool IsNeedStop {
		set {
			TimeStop = value;
		}
	}

	public void init (ActiveCallBack ActiveCallBack)
	{
		AllTimerCharacter = new List<TimerFormat> ();
		this.activeCallBack = ActiveCallBack;
		InvokeRepeating ("runTime", 0, BaseRunTime);
	}

	public void addCharacterTimer (string name,float CdTime)
	{
		TimerFormat oldFormat = AllTimerCharacter.Find (x => x.Name.Equals (name));
		if(oldFormat.Name == null){
			TimerFormat newTimer = new TimerFormat ();
			newTimer.Name = name;
			newTimer.UpdateCdTime = CdTime;
            newTimer.OrginalCdTime = CdTime;
			AllTimerCharacter.Add (newTimer);
            updateMoveTimeChacracter();
		}
	}

	public void removeCharacterTimer (string[] names)
	{
		for(int i = 0 ; i < names.Length ; ++i){
			removeCharacterTimer (names[i]);
		}
	}

	public void removeCharacterTimer (string name)
	{
		TimerFormat format = AllTimerCharacter.Find (x => x.Name.Equals (name));
		if (!string.IsNullOrEmpty (format.Name)) {
			AllTimerCharacter.Remove (format);
		}
	}

	public void reflashCharacterTimer (string name)
	{
		for (int i = 0; i < AllTimerCharacter.Count; ++i) {
			if(AllTimerCharacter[i].Name.Equals(name)){
				TimerFormat format =  AllTimerCharacter [i];
				format.UpdateCdTime = format.OrginalCdTime;
				AllTimerCharacter [i] = format;
				break;
			}
		}
	}

    #endregion

    private void updateMoveTimeChacracter()
    {
        if (2 > AllTimerCharacter.Count)
        {
            return;
        }

        NextMoveTime = AllTimerCharacter[0].UpdateCdTime;
        for (int i = 1; i < AllTimerCharacter.Count; ++i)
        {
            updateMinCdCharacter(i);
        }
    }

    private void updateMinCdCharacter(int checkIndex)
    {
        if (AllTimerCharacter[checkIndex].OrginalCdTime < NextMoveTime)
        {
            NextMoveTime = AllTimerCharacter[checkIndex].OrginalCdTime;
        }
    }

	private void runTime ()
	{
		if (TimeStop) {
			return;
		}
			
		float reduceTime = 0f;
        updateTime += reduceTime;

        if (updateTime >= NextMoveTime)
        {
            updateTime = 0f;
            detectCharacterComplete();
        }
	}

	private void detectCharacterComplete ()
	{
        List<string> moveCharacters = new List<string>();
        TimerFormat TimeFormat;

        for (int i = 0; i < AllTimerCharacter.Count; ++i)
        {
            TimeFormat = AllTimerCharacter[i];
            TimeFormat.UpdateCdTime -= updateTime;
            AllTimerCharacter[i] = TimeFormat;
            addMoveCharacter(TimeFormat, ref moveCharacters);
        }
        reportCharacterState(moveCharacters.ToArray());
    }

    private void addMoveCharacter(TimerFormat TimerFormat,ref List<string> moveCharacters)
    {
        if (0 >= TimerFormat.UpdateCdTime)
        {
            moveCharacters.Add(TimerFormat.Name);
        }
    }

    private void reportCharacterState(string[] moveCharacters)
    {
        updateMoveTimeChacracter();

        if (this.activeCallBack != null)
        {
            this.activeCallBack(moveCharacters);
        }
    }
}
