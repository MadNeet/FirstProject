using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 暫時用的Label腳本 : MonoBehaviour {

	[SerializeField]private string 角色名字 = string.Empty;
	//[SerializeField]private UILabel label = null;

	public string 代表的角色名字
	{
		get
		{
			return 角色名字;
		}
	}

	public void setText(string Text)
	{
		string s = 角色名字 + " : " + Text;
		//label.text = s;
	}
}
