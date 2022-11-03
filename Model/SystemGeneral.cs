using System;
using System.IO;

namespace PaymentsReconciliation.Model
{
    public static class SystemGeneral
    {
        public static string GetWorkingDirectory()
        {
            return Environment.CurrentDirectory;
        }

        public static string GetProjectDirectory()
        {
            return Directory.GetParent(GetWorkingDirectory()).Parent.FullName;
        }
    }
}
