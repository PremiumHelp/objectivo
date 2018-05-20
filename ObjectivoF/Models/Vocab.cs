using System;
namespace ObjectivoF.Models
{
    public class Vocab
	{
		public string Id { get; set; }

        public string UserId { get; set; }
        public string Original { get; set; }
        public string Translated { get; set; }
        
		public Vocab()
        {
        }
    }
}
