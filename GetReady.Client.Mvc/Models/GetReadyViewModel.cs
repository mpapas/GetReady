using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace GetReady.Client.Mvc.Models
{
    public class GetReadyViewModel
    {
        [Required(ErrorMessage = "Please enter a valid command string")]
        [DisplayName("Command String")]
        public string InputCommandString { get; set; }

        public string OutputResult { get; set; }
    }
}