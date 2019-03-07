// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MS-PL license.
// See the LICENSE file in the project root for more information.
using MvvmCross.IoC;
using MvvmCross.ViewModels;
using YgoProFrPatcher.Core.ViewModels;

namespace YgoProFrPatcher.Core
{
    public class App : MvxApplication
    {
        /// <summary>
        /// Breaking change in v6: This method is called on a background thread. Use
        /// Startup for any UI bound actions
        /// </summary>
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();
            RegisterAppStart<RootPageViewModel>();
        }
    }
}
