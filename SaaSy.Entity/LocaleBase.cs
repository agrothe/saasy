using System;
using System.Collections.Generic;
using System.Text;

namespace SaaSy.Entity
{
    public class LocaleBase : ModelBase
    {
        public string LanguageCode { get; set; }
        public bool IsInputLanguage { get; set; }
    }
}
