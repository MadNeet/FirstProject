using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrandControl : MonoBehaviour {

	public delegate void ClickCallBack(string name);
	private ClickCallBack clickCallBack = null;

	public void init(ClickCallBack clickCallBack)
	{
		this.clickCallBack = clickCallBack;
	}

	public void onClickBtn1()
	{
		clickCallBack ("護衛A");
	}


	public void onClickBtn2()
	{
		clickCallBack ("護衛B");
	}

	public void onClickBtn3()
	{
		clickCallBack ("護衛C");
	}
}
