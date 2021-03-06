﻿using System;
using System.Globalization;
using System.Threading;

using Foundation;
using Xamarin.Forms;
using mvvm.Interfaces;
using LocaliseText.iOS;

[assembly: Dependency(typeof(Localize))]

namespace LocaliseText.iOS
{
    public class Localize : ILocalize
    {
        public void SetLocale()
        {
            var ci = new CultureInfo(GetCurrent());
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
        }

        public string GetCurrent()
        {
            var iosLocaleAuto = NSLocale.AutoUpdatingCurrentLocale.LocaleIdentifier;    // en_FR
            var iosLanguageAuto = NSLocale.AutoUpdatingCurrentLocale.LanguageCode;      // en
            var netLocale = iosLocaleAuto.Replace("_", "-");
            var netLanguage = iosLanguageAuto.Replace("_", "-");

#if DEBUG
            Console.WriteLine("nslocaleid: {0}", iosLocaleAuto);
            Console.WriteLine("nslanguage: {0}", iosLanguageAuto);
            Console.WriteLine("ios: {0} {1}", iosLanguageAuto, iosLocaleAuto);
            Console.WriteLine("net: {0} {1}", netLanguage, netLocale);

            Console.WriteLine("thread:   {0}", Thread.CurrentThread.CurrentCulture);
            Console.WriteLine("threadui: {0}", Thread.CurrentThread.CurrentUICulture);

#endif

            const string defaultCulture = "en";

            if (NSLocale.PreferredLanguages.Length > 0)
            {
                var pref = NSLocale.PreferredLanguages[0];
                netLanguage = pref.Replace("_", "-");
                try
                {
                    var ci = CultureInfo.CreateSpecificCulture(netLanguage);
                    netLanguage = ci.Name;
                }
                catch
                {
                    netLanguage = defaultCulture;
                }
            }
            else
            {
                netLanguage = defaultCulture;
            }

#if DEBUG
            Console.WriteLine(netLanguage);
#endif

            return netLanguage;
        }
    }
}