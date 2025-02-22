using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityHousingSystem.Data.Entities
{
    public class DocumentType
    {
        public int DocumentTypeID { get; set; }
        public string DocumentTypeName { get; set; }
        public ICollection<Document> Documents { get; set; }
    }
}
