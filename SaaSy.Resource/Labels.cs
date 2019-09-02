using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaaSy.Resource
{

    public class Labels
    {
        private readonly IStringLocalizer _localizer;

        public Labels(IStringLocalizer<Labels> localizer)
        {
            _localizer = localizer;
        }

        public string this[string index]
        {
            get
            {
                return _localizer[index];
               // return Resources.Labels.ResourceManager.GetString(index);
            }
        }

        


    }
}
