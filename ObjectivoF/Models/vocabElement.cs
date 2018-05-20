using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ObjectivoF.Models
{
	public class vocabElement:INotifyPropertyChanged
    {
		public event PropertyChangedEventHandler PropertyChanged;

		private string _translated;
        private string _original;

		public string translated { get { return _translated; } set { OnPropertyChanged(); _translated = value; } }
		public string original { get { return _original; } set { OnPropertyChanged(); _original = value; } }

        public vocabElement()
        {
        }
		public vocabElement( string translated, string original)
        {
			this._translated = translated;
			this._original = original;
          
        }

		void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

}
