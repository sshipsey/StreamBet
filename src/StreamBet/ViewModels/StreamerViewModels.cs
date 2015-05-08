using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Mvc.Rendering;

namespace StreamBet.ViewModels
{
    public class EditViewModel
    {
        [Required]
        [Display(Name ="Name")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Url)]
        [Display(Name = "Link to stream")]
        public string StreamLink { get; set; }
    }

    public class NewViewModel
    {
        [Required]
        [Display(Name ="Name")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Url)]
        [Display(Name = "Link to stream")]
        public string StreamLink { get; set; }
    }
}
