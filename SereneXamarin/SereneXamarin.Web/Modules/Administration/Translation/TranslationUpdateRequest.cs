﻿using Serenity.Services;
using System.Collections.Generic;

namespace SereneXamarin.Administration
{

    public class TranslationUpdateRequest : ServiceRequest
    {
        public string TargetLanguageID { get; set; }
        public Dictionary<string, string> Translations { get; set; }
    }
}