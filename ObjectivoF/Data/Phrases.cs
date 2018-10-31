using System;

namespace ObjectivoF.Data
{
    /// <summary>
    /// This Phrases class is used to deserialize an XML file and display the resulting data in a list.
    /// </summary>
    /// <remarks>
    /// The code used to load the XML into this class is shown here 
    /// </remarks>
    public class Phrases
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string Details { get; set; }

        public override string ToString()
        {
            return Name;
      
        }
      
    }
}