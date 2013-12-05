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
		//foreach(string p in Enum.GetNames(typeof(Pattern)))
		//Register<Pattern>(currentPattern);


		foreach (Pattern p in Enum.GetValues(typeof(Pattern)))
		{
			//Debug.Log ("Pattern: " + p.ToString());
			//currentPattern = p;
			ConfigureDelegate<Action>(p, DoNothing);
		}

	}

	void Register<T>(object o)
	{
		foreach (T p in Enum.GetValues(typeof(T)))
		{
			Debug.Log (typeof(T).ToString() + ": " + p.ToString());
			o = p;
			ConfigureDelegate<Action>(p.ToString(), DoNothing);
		}
	}

	// Use this for initialization
	void Start () {
	
	}


	Action callback;

	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown("space"))
		{

		}
	}
	
	static void DoNothing()
	{
		// empty
	}

	public void OnEvent()
	{
		/*
			Dictionary<string, Delegate> lookup = _cache[currentPattern];

			callback = lookup[currentPattern.ToString()] as Action;
			if (callback != null)
				callback();
		*/	
		Action action = lookup[currentPattern] as Action;
		if (action != null)
			action();
	}

	/// <summary>
	/// A cache of the delegates for a particular state and method
	/// </summary>
	//Dictionary<object, Dictionary<string, Delegate>> _cache = new Dictionary<object, Dictionary<string, Delegate>>();
	
	//Creates a delegate for a particular method on the current state machine
	//if a suitable method is not found then the default is used instead

	/*
	T ConfigureDelegate<T>(string methodRoot, T Default) where T : class
	{
		
		Dictionary<string, Delegate> lookup;
		if(!_cache.TryGetValue(currentPattern, out lookup))
		{
			_cache[currentPattern] = lookup = new Dictionary<string, Delegate>();
		}
		Delegate returnValue;
		if(!lookup.TryGetValue(methodRoot, out returnValue))
		{
		
			var mtd = GetType().GetMethod("On" + currentPattern.ToString(), System.Reflection.BindingFlags.Instance 
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
			lookup[methodRoot] = returnValue;
		}
		return returnValue as T;
	}
    */

	/*
	T ConfigureDelegate<T>(object states, T Default) where T : class
	{
		
		Dictionary<string, Delegate> lookup;
		if(!_cache.TryGetValue(states, out lookup))
		{
			_cache[states] = lookup = new Dictionary<string, Delegate>();
		}
		Delegate returnValue;
		if(!lookup.TryGetValue(states.ToString(), out returnValue))
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
			lookup[states.ToString()] = returnValue;
		}
		return returnValue as T;
	}
	*/

	Dictionary<object, Delegate> lookup = new Dictionary<object, Delegate>();

	T ConfigureDelegate<T>(object states, T Default) where T : class
	{
		Delegate returnValue;
		if(!lookup.TryGetValue(states, out returnValue))
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
			lookup[states] = returnValue;
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
