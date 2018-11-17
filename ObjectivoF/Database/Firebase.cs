using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Firebase.Xamarin.Database;

namespace ObjectivoF
{
	public class Firebase
	{

		FirebaseClient fbClient;

		public Firebase()
		{
			fbClient = new FirebaseClient("https://objectivo-fe34c.firebaseio.com/");
		}

		public async Task<List<Group>> getGroupList()
		{
			return (await fbClient.Child("Chat").OnceAsync<Group>()).Select((item) =>
				new Group
				{
					Key = item.Key,
					Name = item.Object.Name
				}

					   ).ToList();

		}

		public async Task saveGroup(Group gm)
		{
			await fbClient.Child("Chat")
                          .PostAsync(gm);

		}


		public async Task saveMessage(Chat _chat, string _group)
		{
			await fbClient.Child("Chat/" + _group + "/Message")
                          .PostAsync(_chat);
		}

		public ObservableCollection<Chat> subChat(string _groupkey)
		{
			
			return fbClient.Child("Chat/"+_groupkey+"/Message")
				           .AsObservable<Chat>()
				           .AsObservableCollection<Chat>();
		}


	}
}
