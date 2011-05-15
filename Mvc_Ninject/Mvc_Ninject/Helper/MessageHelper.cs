using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mvc_Ninject.Helper.Interfaces;

namespace Mvc_Ninject.Helper
{
    public class MessageHelper : IMessageHelper
    {
        public string GetWelcomeMessage()
        {
            return "Dependency injection with Ninject and welcome:D";
        }
    }
}