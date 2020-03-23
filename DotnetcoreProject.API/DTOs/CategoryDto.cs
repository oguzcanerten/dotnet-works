using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; //required
using System.Linq;
using System.Threading.Tasks;

namespace DotnetcoreProject.API.DTOs
{
    public class CategoryDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
