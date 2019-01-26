using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Want<T>
{
	public T want;
	public bool required = true;
}

[System.Serializable]
public class FriendWant : Want<Person>
{
}

[System.Serializable]
public class Locations : Want<List<House>>
{
}