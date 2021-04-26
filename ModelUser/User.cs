using System;
using System.Collections.Generic;

#nullable disable

namespace MerpeyHypeServer.ModelUser
{
    public partial class User
    {
        public int Id { get; set; }
        public string MainUser { get; set; }
        public string UserName { get; set; }
        public bool Enable { get; set; }
        public string Password { get; set; }

        public virtual UsersExt UsersExt { get; set; }
    }
}
