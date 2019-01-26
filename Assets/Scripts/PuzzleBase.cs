using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleBase : MonoBehaviour
{
	public List<House> houses;

    public bool IsSolved()
	{
		foreach (House h in houses)
		{
			foreach (Person p in h.inhabitants)
			{
				if (!p.WantsFulfilled())
					return false;
			}
		}
		return true;
	}

	public bool MovePerson(Person person, House target, House source)
	{
		if (target.inhabitants.Count < target.capacity)
		{
			source.inhabitants.Remove(person);
			target.AddPerson(person);
			return true;
		}
		return false;
	}

	// Person a is from the source house, person b is from the target house
	public void SwapPerson(Person persona, Person personb, House target, House source)
	{
		source.inhabitants.Remove(persona);
		source.AddPerson(personb);
		target.inhabitants.Remove(personb);
		target.AddPerson(persona);
	}
}
