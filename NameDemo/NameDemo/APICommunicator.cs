using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NameDemo.JustWareApi;

namespace NameDemo
{
	public class APICommunicator
	{
		private JustWareApiClient _apiClient;

		public APICommunicator()
		{
			_apiClient = new JustWareApiClient();
			_apiClient.ClientCredentials.UserName.UserName = "NDT\\apiuser";
			_apiClient.ClientCredentials.UserName.Password = "NewDawn2012";
		}


		public List<Name> QueryForName(string lastName)
		{
			string query = "Last == \"" + lastName + "\"";
			List<Name> names = _apiClient.FindNames(query, null);
			return names;

		}

		public int InsertNewName(string firstName, string lastName)
		{
			Name n = new Name();
			n.Operation = OperationType.Insert;
			n.First = firstName;
			n.Last = lastName;

			List<Key> keys = _apiClient.Submit(n);
			return keys.First().NewID;
		}
	}
}
