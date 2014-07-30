using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.ComponentModel;

namespace ActiLifeAPILibrary.Models.Actions
{
	/// <summary>
	/// ActionBase constructs all class properties in an Action and sets values based on DefaultValue attributes.
	/// </summary>
	public class ActionBase
	{
		public ActionBase()
		{
			//find all properties that have classes and construct them.
			foreach (PropertyInfo item in (from prop in this.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)
										   where prop.CanWrite && prop.GetType().IsClass && prop.PropertyType.GetConstructor(Type.EmptyTypes) != null
											   select prop))
			{
				var constructor = item.PropertyType.GetConstructor(Type.EmptyTypes);

				item.SetValue(this, constructor.Invoke(Type.EmptyTypes), null);
			}


			//now set all default values from DefaultValue attribute
			foreach (PropertyInfo item in (from prop in this.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)
										   where prop.GetCustomAttributes(typeof(System.ComponentModel.DefaultValueAttribute), true).Length != 0
										   select prop))
			{
				foreach (var attribute in item.GetCustomAttributes(typeof(System.ComponentModel.DefaultValueAttribute), true))
				{
					item.SetValue(this, ((DefaultValueAttribute)attribute).Value, null);
				}
			}
		}
	}
}
