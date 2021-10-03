﻿using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

namespace GrandiaRandomizer
{
    public class InternetBrowser
    {
        public static Boolean OpenInDefaultBrowser(String pathOrUrl)
        {
            // Trim any surrounding quotes and spaces.
            pathOrUrl = pathOrUrl.Trim().Trim('"').Trim();
            // Default protocol to "http"
            String protocol = Uri.UriSchemeHttp;
            // Correct the protocol to that in the actual url
            if (Regex.IsMatch(pathOrUrl, "^[a-z]+" + Regex.Escape(Uri.SchemeDelimiter), RegexOptions.IgnoreCase))
            {
                Int32 schemeEnd = pathOrUrl.IndexOf(Uri.SchemeDelimiter, StringComparison.Ordinal);
                if (schemeEnd > -1)
                    protocol = pathOrUrl.Substring(0, schemeEnd).ToLowerInvariant();
            }
            // Surround with quotes
            pathOrUrl = "\"" + pathOrUrl + "\"";
            Object fetchedVal;
            String defBrowser = null;
            // Look up user choice translation of protocol to program id
            using (RegistryKey userDefBrowserKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\Shell\Associations\UrlAssociations\" + protocol + @"\UserChoice"))
                if (userDefBrowserKey != null && (fetchedVal = userDefBrowserKey.GetValue("Progid")) != null)
                    // Programs are looked up the same way as protocols in the later code, so we just overwrite the protocol variable.
                    protocol = fetchedVal as String;
            // Look up protocol (or programId from UserChoice) in the registry, in priority order.
            // Current User registry
            using (RegistryKey defBrowserKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Classes\" + protocol + @"\shell\open\command"))
                if (defBrowserKey != null && (fetchedVal = defBrowserKey.GetValue(null)) != null)
                    defBrowser = fetchedVal as String;
            // Local Machine registry
            if (defBrowser == null)
                using (RegistryKey defBrowserKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Classes\" + protocol + @"\shell\open\command"))
                    if (defBrowserKey != null && (fetchedVal = defBrowserKey.GetValue(null)) != null)
                        defBrowser = fetchedVal as String;
            // Root registry
            if (defBrowser == null)
                using (RegistryKey defBrowserKey = Registry.ClassesRoot.OpenSubKey(protocol + @"\shell\open\command"))
                    if (defBrowserKey != null && (fetchedVal = defBrowserKey.GetValue(null)) != null)
                        defBrowser = fetchedVal as String;
            // Nothing found. Return.
            if (String.IsNullOrEmpty(defBrowser))
                return false;
            String defBrowserProcess;
            // Parse browser parameters. This code first assembles the full command line, and then splits it into the program and its parameters.
            Boolean hasArg = false;
            if (defBrowser.Contains("%1"))
            {
                // If url in the command line is surrounded by quotes, ignore those; our url already has quotes.
                if (defBrowser.Contains("\"%1\""))
                    defBrowser = defBrowser.Replace("\"%1\"", pathOrUrl);
                else
                    defBrowser = defBrowser.Replace("%1", pathOrUrl);
                hasArg = true;
            }
            Int32 spIndex;
            if (defBrowser[0] == '"')
                defBrowserProcess = defBrowser.Substring(0, defBrowser.IndexOf('"', 1) + 2).Trim();
            else if ((spIndex = defBrowser.IndexOf(" ", StringComparison.Ordinal)) > -1)
                defBrowserProcess = defBrowser.Substring(0, spIndex).Trim();
            else
                defBrowserProcess = defBrowser;

            String defBrowserArgs = defBrowser.Substring(defBrowserProcess.Length).TrimStart();
            // Not sure if this is possible / allowed, but better support it anyway.
            if (!hasArg)
            {
                if (defBrowserArgs.Length > 0)
                    defBrowserArgs += " ";
                defBrowserArgs += pathOrUrl;
            }
            // Run the process.
            defBrowserProcess = defBrowserProcess.Trim('"');
            if (!File.Exists(defBrowserProcess))
                return false;
            ProcessStartInfo psi = new ProcessStartInfo(defBrowserProcess, defBrowserArgs);
            psi.WorkingDirectory = Path.GetDirectoryName(defBrowserProcess);
            Process.Start(psi);
            return true;
        }
    }
}
