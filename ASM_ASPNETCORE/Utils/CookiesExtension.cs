﻿using System.Text.Json;

namespace ASM_ASPNETCORE.Utils
{
	public static class CookiesExtension
	{
		public static void Append<T>(this IResponseCookies cookies, string key, T value, CookieOptions opt)
		{
			cookies.Append(key, JsonSerializer.Serialize(value), opt);
		}
		public static T? Get<T>(this IRequestCookieCollection cookies, string key)
		{
			var value = cookies[key];
			return value == null ? default : JsonSerializer.Deserialize<T>(value);
		}
	}
}
