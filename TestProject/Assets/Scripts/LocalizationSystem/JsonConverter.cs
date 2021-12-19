using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonConverter 
{
	public static T[] FromJson<T>(string json)
	{
		
		JsonWrap<T> result = JsonUtility.FromJson<JsonWrap<T>>(json);
		
		return result.Words;
	}


	[System.Serializable]
	private class JsonWrap<T>
	{
		public T[] Words;
	}
}
