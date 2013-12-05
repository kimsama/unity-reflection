using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class MonsterPattern : MonoBehaviour 
{


	public enum Pattern
	{
		Rush,
		HowAmI,
		SpeedStar,
		ShieldFairy,
		BlockMover,
		Revival,
		Division,
		ShieldEnforce,
		Hide,
		Jump,
		Summon,
	}
	
	public Pattern currentPattern;
	

	void OnEnable()
	{
		foreach (Pattern p in Enum.GetValues(typeof(Pattern)))
		{
			ConfigureDelegate<Action>(p, DoNothing);
		}
	}

	
	static void DoNothing()
	{
		// empty
	}

	public void OnEvent()
	{
		Action action = _lookup[currentPattern] as Action;
		if (action != null)
			action();
	}

	/// <summary>
	/// A cache of the delegates for a particular state and method
	/// </summary>
	Dictionary<object, Delegate> _lookup = new Dictionary<object, Delegate>();

	T ConfigureDelegate<T>(object states, T Default) where T : class
	{
		Delegate returnValue;
		if(!_lookup.TryGetValue(states, out returnValue))
		{
			var mtd = GetType().GetMethod("On" + states.ToString(), System.Reflection.BindingFlags.Instance 
			                              | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.InvokeMethod);
			
			if(mtd != null)
			{
				if(typeof(T) == typeof(Func<IEnumerator>) && mtd.ReturnType != typeof(IEnumerator))
				{
					Action a = Delegate.CreateDelegate(typeof(Action), this, mtd) as Action;
					Func<IEnumerator> func = () => { a(); return null; };
					returnValue = func;
				}
				else
					returnValue = Delegate.CreateDelegate(typeof(T), this, mtd);
			}
			else
			{
				returnValue = Default as Delegate;
			}
			_lookup[states] = returnValue;
		}
		return returnValue as T;
	}

	void OnRush()
	{
		Debug.Log("OnRush");
	}
	
	void OnHowAmI()
	{
		Debug.Log("HowAmI");
	}
	
	void OnSpeedStar()
	{
		Debug.Log("SpeedStar");
	}
		
	void OnShieldFairy()
	{
		Debug.Log("ShieldFairy");
	}
		
	void OnBlockMover()
	{
		Debug.Log("BlockMover");
	}
		
	void OnRevival()
	{
		Debug.Log("Revival");
	}
		
	void OnDivision()
	{
		Debug.Log("Division");
	}
		
	void OnShieldEnforce()
	{
		Debug.Log("ShieldEnforce");
	}
		
	void OnHide()
	{
		Debug.Log("Hide");
	}
		
	void OnJump()
	{
		Debug.Log("Jump");
	}
		
	void OnSummon()
	{
		Debug.Log("Summon");
	}
	

}
