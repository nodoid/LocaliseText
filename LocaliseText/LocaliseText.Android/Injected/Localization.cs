﻿using System;
using Xamarin.Forms;
using System.Globalization;
using System.Threading;
using mvvm.Interfaces;
using LocaliseText.Droid;

[assembly: Dependency(typeof(Localize))]
namespace LocaliseText.Droid
{
    public class Localize : ILocalize
    {
        public void SetLocale()
        {

            var androidLocale = Java.Util.Locale.Default;
            var netLocale = androidLocale.ToString().Replace("_", "-");
            var ci = new CultureInfo(netLocale);
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
        }

        public string GetCurrent()
        {
            var androidLocale = Java.Util.Locale.Default;
            var netLanguage = androidLocale.Language.Replace("_", "-");
            var netLocale = androidLocale.ToString().Replace("_", "-");

#if DEBUG
            Console.WriteLine("android:  " + androidLocale.ToString());
            Console.WriteLine("netlang:  " + netLanguage);
            Console.WriteLine("netlocale:" + netLocale);
#endif

            var ci = new System.Globalization.CultureInfo(netLocale);
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;

#if DEBUG
            Console.WriteLine("thread:  " + Thread.CurrentThread.CurrentCulture);
            Console.WriteLine("threadui:" + Thread.CurrentThread.CurrentUICulture);
#endif

            return netLocale;
        }
    }
}

