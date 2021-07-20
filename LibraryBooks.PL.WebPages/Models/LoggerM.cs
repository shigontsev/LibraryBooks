using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryBooks.PL.WebPages.Models
{
    public static class LoggerM
    {
        public static Logger logger = LogManager.GetCurrentClassLogger();
    }
}