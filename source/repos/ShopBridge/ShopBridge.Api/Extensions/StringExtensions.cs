﻿using ShopBridge.Models.AppSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.Extensions
{
    public static class StringExtensions
    {
        public static string DatabaseConnectionString(this DatabaseConfiguration db, bool isProduction)
        {
            if (isProduction)
                return $"Server={db.ServerName};Database={db.DatabaseName};User ID={db.UserId};Password={db.Password};Encrypt=true;";
            return $"server={db.ServerName};database={db.DatabaseName};trusted_connection=true;Encrypt=false;";
        }
    }
}
