using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; //required
using System.Linq;
using System.Threading.Tasks;

namespace DotnetcoreProject.Web.DTOs
{
    public class CategoryDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="{0} alanı boş olamaz")]
        public string Name { get; set; }
    }
}
