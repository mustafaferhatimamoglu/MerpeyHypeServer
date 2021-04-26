using System;
using System.Collections.Generic;

#nullable disable

namespace MerpeyHypeServer.ModelUser
{
    public partial class UsersExt
    {
        public int Fid { get; set; }
        public DateTime CreateDate { get; set; }
        public string Email { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Street { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Adress { get; set; }
        public string Zip { get; set; }
        public string CountryCode { get; set; }
        public string Phone { get; set; }

        public virtual User FidNavigation { get; set; }
    }
}
