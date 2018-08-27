using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace App.Books
{
    public class Books_DTO
    {
        public long id { get; set; }

        [Display(Name = "Nome")]
        public string name { get; set; }

        [Display(Name = "Paginas")]
        public int pages { get; set; }

        [Display(Name = "Data Registro")]
        public string create_date { get; set; }

        [Display(Name = "Data Atualização")]
        public string update_date { get; set; }

        [Display(Name = "Autor")]
        public string author { get; set; }

        [Display(Name = "Quantidade")]
        public int quantity { get; set; }

    }
}
