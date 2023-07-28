using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "OriginStatus", menuName = "Status/OriginStatus", order = 0)]
public class OriginStatus : ScriptableObject
{
	[SerializeField] private List<StatusData> status = new List<StatusData>();

	public void AutoGenerator()
	{
		var statusTypeList = Enum.GetValues(typeof(StatusType)).Cast<StatusType>();

		foreach (var statusType in statusTypeList)
		{
			if (statusType is StatusType.NONE or StatusType.MAX ||
				HasStatus(statusType))
			{
				continue;
			}
			status.Add(new StatusData(statusType));
		}
	}

	public List<StatusData> GetStatus()
	{
		return status;
	}

	public bool HasStatus(StatusType type)
	{
		var element = status.Find((x) => x.type == type);

		return status.Contains(element);
	}

	public StatusData GetElement(StatusType type)
	{
		if (!HasStatus(type))
		{
			// Warping Debug Logger 필요
			return null;
		}

		return status.Find((x) => x.type == type);

	}
}