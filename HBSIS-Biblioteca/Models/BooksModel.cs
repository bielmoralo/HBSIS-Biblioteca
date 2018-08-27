using App.Books;
using System.Collections.Generic;

namespace HBSIS_Biblioteca.Models.Books
{
    public class IndexModel
    {
        public List<Books_DTO> List { get; set; }

        public IndexModel()
        {
            List = new Books_BO().GetAll();
        }
    }
    public class CreateModel
    {
        public Books_DTO obj { get; set; }

        public CreateModel()
        {
            obj = new Books_DTO();
        }
    }
    public class UpdateModel
    {
        public Books_DTO obj { get; set; }

        public UpdateModel()
        {

        }

        public UpdateModel(long id)
        {
            obj = new Books_BO().Get(id);
        }
    }
}