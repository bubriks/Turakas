﻿using System;
using System.Runtime.Serialization;

namespace DataTier
{
    [DataContract]
    public class Login
    {
        [DataMember]
        public int LoginId { get; set; }
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string Email { get; set; }
    }
}