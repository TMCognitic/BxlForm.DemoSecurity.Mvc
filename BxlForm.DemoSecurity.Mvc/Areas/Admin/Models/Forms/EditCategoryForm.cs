using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BxlForm.DemoSecurity.Mvc.Areas.Admin.Models.Forms
{
    public class EditCategoryForm
    {
        [HiddenInput]
        public int Id { get; set; }
        [DisplayName("Nom : ")]
        [Required]
        [MaxLength(125)]
        public string Name { get; set; }
    }
}
