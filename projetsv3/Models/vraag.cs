using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace projetsv3.Models
{
    [MetadataType(typeof(VraagProperties))]
    public partial class vraag
    {
     
    }


    public class VraagProperties
    {
        public DateTime date
        {
            get
            {
                return DateTime.Now.Date;
            }
        }
    }


}