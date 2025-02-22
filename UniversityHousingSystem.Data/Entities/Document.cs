using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace UniversityHousingSystem.Data.Entities
{
    public class Document
    {
        public int DocumentID { get; set; }
        public string Path { get; set; }
        public int StudentID { get; set; }
        public int DocTypeID { get; set; }

        // Navigation Properties
        public Student Student { get; set; }
        public DocumentType DocumentTypes { get; set; }
    }
}
