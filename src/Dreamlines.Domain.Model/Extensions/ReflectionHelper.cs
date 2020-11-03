﻿using System;

namespace Dreamlines.Domain.Extensions
{
	public static class ReflectionHelper
	{
		public static T GetAttribute<T>(this Enum value) where T : Attribute
		{
			var type = value.GetType();
			var memberInfo = type.GetMember(value.ToString());
			var attributes = memberInfo[0].GetCustomAttributes(typeof(T), false);
			return attributes.Length > 0
			  ? (T)attributes[0]
			  : null;
		}


		public static T GetAttribute<T>(this Type type) where T : Attribute
		{
			var attributes = type.GetCustomAttributes(typeof(T), false);
			return attributes.Length > 0
			  ? (T)attributes[0]
			  : null;
		}
	}
}