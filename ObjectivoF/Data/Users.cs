using System;
namespace ObjectivoF
{
	public class Users
	{
		private static string uid;

		public static string UserName
		{
			get {
				return uid;
			}
			set
			{
				uid = value;
			}
		}


		private Users(){}

	}
}
