using System;
using System.Collections.Generic;

#nullable disable

namespace MerpeyHypeServer.ModelUser
{
    public partial class LogUsersLogin
    {
        public int Id { get; set; }
        public DateTime AttemptTime { get; set; }
        public bool? IsSuccess { get; set; }
        public string TriedPassword { get; set; }
        public string TriedMainUser { get; set; }
        public string TriedUsername { get; set; }
    }
}
