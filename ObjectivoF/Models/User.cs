﻿using System;
namespace ObjectivoF
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string[] SavedPhrases { get; set; }

        public User()
        {}
     }
    }

