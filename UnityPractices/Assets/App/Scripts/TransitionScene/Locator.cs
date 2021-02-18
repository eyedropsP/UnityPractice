using System;
using System.Collections.Generic;
using UnityEngine;

namespace App.Scripts.TransitionScene
{
	public static class Locator
	{
		/// <summary>
		/// 単一インスタンス用Dictionary
		/// </summary>
		private static readonly Dictionary<Type, object> instanceDictionary = new Dictionary<Type, object>();

		/// <summary>
		/// 都度インスタンス生成用Dictionary
		/// </summary>
		private static readonly Dictionary<Type, Type> typeDictionary = new Dictionary<Type, Type>();

		/// <summary>
		/// 単一インスタンス登録
		/// 呼び出し毎に上書き登録
		/// </summary>
		/// <param name="instance"></param>
		/// <typeparam name="T"></typeparam>
		public static void Register<T>(T instance) where T : class => instanceDictionary[typeof(T)] = instance;

		/// <summary>
		/// 型で登録
		/// Resolve毎に都度インスタンス生成する
		/// </summary>
		/// <typeparam name="TContract"></typeparam>
		/// <typeparam name="TConcrete"></typeparam>
		public static void Register<TContract, TConcrete>() where TContract : class =>
			typeDictionary[typeof(TContract)] = typeof(TConcrete);

		/// <summary>
		/// インスタンスを解除
		/// </summary>
		/// <param name="instance"></param>
		/// <typeparam name="T"></typeparam>
		public static void UnRegister<T>(T instance)
		{
			if (Equals(instanceDictionary[typeof(T)], instance)) instanceDictionary[typeof(T)] = null;
		}

		/// <summary>
		/// 型を指定して登録されているインスタンスを取得する
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public static T Resolve<T>() where T : class
		{
			T instance;

			var type = typeof(T);

			if (instanceDictionary.ContainsKey(type))
			{
				instance = instanceDictionary[type] as T;
				return instance;
			}

			if (typeDictionary.ContainsKey(type))
			{
				instance = Activator.CreateInstance(typeDictionary[type]) as T;
				return instance;
			}

			Debug.LogError($"Locator: {typeof(T).Name} not found");

			return null;
		}
	}
}