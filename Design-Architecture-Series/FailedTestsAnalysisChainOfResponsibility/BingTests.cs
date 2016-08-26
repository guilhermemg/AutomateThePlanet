﻿// <copyright file="BingTests.cs" company="Automate The Planet Ltd.">
// Copyright 2016 Automate The Planet Ltd.
// Licensed under the Apache License, Version 2.0 (the "License");
// You may not use this file except in compliance with the License.
// You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// <author>Anton Angelov</author>
// <site>http://automatetheplanet.com/</site>

using HybridTestFramework.UITests.Core;
using HybridTestFramework.UITests.Core.Behaviours;
using HybridTestFramework.UITests.Core.Behaviours.TestsEngine.Attributes;
using HybridTestFramework.UITests.Core.Behaviours.TestsEngine.Enums;
using HybridTestFramework.UITests.Core.Behaviours.VideoRecording.Attributes;
using HybridTestFramework.UITests.Core.Behaviours.VideoRecording.Enums;
using HybridTestFramework.UITests.Core.Controls;
using HybridTestFramework.UITests.Core.Extensions;
using HybridTestFramework.UITests.Core.Utilities.ExceptionsAnalysis.ChainOfResponsibility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Practices.Unity;

namespace FailedTestsAnalysisChainOfResponsibility
{
    [TestClass,
    ExecutionEngineAttribute(ExecutionEngineType.TestStudio, Browsers.Firefox),
    VideoRecordingAttribute(VideoRecordingMode.DoNotRecord)]
    public class BingTests : BaseTest
    {
        private IExceptionAnalyzer exceptionAnalyzer;
 
        public override void TestInit()
        {
            base.TestInit();
            this.exceptionAnalyzer = this.Container.Resolve<IExceptionAnalyzer>();
        }

        [TestMethod]
        public void TryToLoginTelerik()
        {
            this.Driver.NavigateByAbsoluteUrl("https://www.telerik.com/login/");
            this.exceptionAnalyzer.AddNewHandler<EmptyEmailValidationExceptionHandler>();
            var loginButton = this.Driver.FindByIdEndingWith<IButton>("LoginButton");
            loginButton.Click();
            var logoutButton = this.Driver.FindByIdEndingWith<IButton>("LogoutButton");
            logoutButton.Click();
            this.exceptionAnalyzer.RemoveLastHandler();
        }
    }
}