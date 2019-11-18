using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.User
{
    [Serializable]
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
    }
}
