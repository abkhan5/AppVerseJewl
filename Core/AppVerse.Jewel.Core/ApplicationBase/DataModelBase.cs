using System;
using System.Collections.Generic;
using System.ComponentModel;
using Prism.Mvvm;

namespace AppVerse.Jewel.Core.ApplicationBase
{
    public abstract class DataModelBase : BindableBase, IDataErrorInfo  
    {
        protected readonly Dictionary<string, Func<string>> ErrorDictionary;

        protected DataModelBase()
        {
            ErrorDictionary=new Dictionary<string, Func<string>>();
            Error = "";
        }

        public string this[string columnName]
        {
            get
            {
                if (ErrorDictionary.ContainsKey(columnName))
                {
                    return ErrorDictionary[columnName]();
                }

                return "";
            }
        }


        public string Error { get; }
    }
}