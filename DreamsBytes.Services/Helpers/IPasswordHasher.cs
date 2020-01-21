﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DreamsBytes.Services.Helpers
{
    public interface IPasswordHasher
    {
        string Hash(string password);

        (bool Verified, bool NeedsUpgrade) Check(string hash, string password);
    }
}
