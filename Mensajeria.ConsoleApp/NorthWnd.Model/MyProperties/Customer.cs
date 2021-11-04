using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWnd.Model.MyModels
{
    public partial class Customer
    {
        [NotMapped]
        public string FullName
        {
            get
            {
                var title = string.Empty;
                if (this.Title != null)
                {
                    title = this.Title + " ";
                }
                var firstName = this.FirstName + " ";
                var middleName = string.Empty;
                if (this.MiddleName != null)
                {
                    middleName = this.MiddleName + " ";
                }
                var lastName = this.LastName + " ";
                var suffix = string.Empty;
                if (this.Suffix != null)
                {
                    suffix = this.Suffix;
                }
                var resultado = $"{title}{firstName}{middleName}{lastName}{suffix}";

                return resultado;
            }
            set { }
        }
    }
}
