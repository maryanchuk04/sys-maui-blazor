using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui_sys_app.Models
{
    internal class DeleteForm
    {
        [Required(ErrorMessage = "Choose type of delete!")]
        public string SelectedType { get; set; }
    }
}
