using Cirrious.CrossCore.IoC;
using Cirrious.MvvmCross.Plugins.JsonLocalisation;
using SmartDocTestApp.Core.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SmartDocTestApp.Core.Services
{
    public class TextProviderBuilder : MvxTextProviderBuilder
    {
        public TextProviderBuilder() : base(SmartDockConstants.GeneralNamespace, SmartDockConstants.RootFolderForResources)
        {
        }

        protected override IDictionary<string, string> ResourceFiles
        {
            get
            {
                var dic = this.GetType()
                    .GetTypeInfo()
                    .Assembly
                    .CreatableTypes()
                    .Where(t => t.Name.EndsWith("ViewModel"))
                    .ToDictionary(t => t.Name, t => t.Name);

                dic.Add(SmartDockConstants.ErrorsResource, SmartDockConstants.ErrorsResource);
                return dic;
            }
        }
    }
}
