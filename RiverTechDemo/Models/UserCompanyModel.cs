using System;
using System.Collections.Generic;
using System.Text;

namespace RiverTechDemo.Models
{
    public class UserCompanyModel
    {
        public UserCompanyModel(string name, string catchPhrase, string bs)
        {
            Name = name;
            CatchPhrase = catchPhrase;
            Bs = bs;
        }

        public String Name { get; set; }
        public String CatchPhrase { get; set; }
        public String Bs { get; set; }
    }
}
