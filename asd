[1mdiff --git a/EcommerceBackend/EcommerceBackend.csproj b/EcommerceBackend/EcommerceBackend.csproj[m
[1mindex 2b9178f..7d755b5 100644[m
[1m--- a/EcommerceBackend/EcommerceBackend.csproj[m
[1m+++ b/EcommerceBackend/EcommerceBackend.csproj[m
[36m@@ -12,7 +12,7 @@[m
     <AppDesignerFolder>Properties</AppDesignerFolder>[m
     <RootNamespace>EcommerceBackend</RootNamespace>[m
     <AssemblyName>EcommerceBackend</AssemblyName>[m
[31m-    <TargetFrameworkVersion>v4.5.2</TargetFrameworkVersion>[m
[32m+[m[32m    <TargetFrameworkVersion>v4.7.2</TargetFrameworkVersion>[m
     <FileAlignment>512</FileAlignment>[m
     <ProjectTypeGuids>{3AC096D0-A1C2-E12C-1390-A8335801FDAB};{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}</ProjectTypeGuids>[m
     <VisualStudioVersion Condition="'$(VisualStudioVersion)' == ''">15.0</VisualStudioVersion>[m
[36m@@ -79,6 +79,8 @@[m
     <Reference Include="nunit.framework, Version=3.12.0.0, Culture=neutral, PublicKeyToken=2638cd05610744eb, processorArchitecture=MSIL">[m
       <HintPath>..\packages\NUnit.3.12.0\lib\net45\nunit.framework.dll</HintPath>[m
     </Reference>[m
[32m+[m[32m    <Reference Include="PresentationCore" />[m
[32m+[m[32m    <Reference Include="PresentationFramework" />[m
     <Reference Include="RazorEngine, Version=3.10.0.0, Culture=neutral, PublicKeyToken=9ee697374c7e744a, processorArchitecture=MSIL">[m
       <HintPath>..\packages\RazorEngine.3.10.0\lib\net45\RazorEngine.dll</HintPath>[m
     </Reference>[m
[36m@@ -162,6 +164,7 @@[m
     <Reference Include="System.Web.Razor, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, processorArchitecture=MSIL">[m
       <HintPath>..\packages\Microsoft.AspNet.Razor.3.0.0\lib\net45\System.Web.Razor.dll</HintPath>[m
     </Reference>[m
[32m+[m[32m    <Reference Include="System.Xaml" />[m
     <Reference Include="System.Xml" />[m
     <Reference Include="TechTalk.SpecFlow, Version=3.1.0.0, Culture=neutral, PublicKeyToken=0778194805d6db41, processorArchitecture=MSIL">[m
       <HintPath>..\packages\SpecFlow.3.1.67\lib\net45\TechTalk.SpecFlow.dll</HintPath>[m
[36m@@ -182,6 +185,10 @@[m
     <Compile Include="models\Loyalty\ModelMenus.cs" />[m
     <Compile Include="models\Loyalty\ModelBenefits.cs" />[m
     <Compile Include="models\Loyalty\ModelLoyalty.cs" />[m
[32m+[m[32m    <Compile Include="models\Order\ModelAppInfo.cs" />[m
[32m+[m[32m    <Compile Include="models\Order\ModelGeolocation.cs" />[m
[32m+[m[32m    <Compile Include="models\Order\ModelPayment.cs" />[m
[32m+[m[32m    <Compile Include="models\Order\ModelStartOrder.cs" />[m
     <Compile Include="models\Order\ModelAccount.cs" />[m
     <Compile Include="models\Order\ModelOrderResgate .cs" />[m
     <Compile Include="models\Order\ModelOrderLast.cs" />[m
[36m@@ -189,6 +196,9 @@[m
     <Compile Include="models\Order\ModelTickets .cs" />[m
     <Compile Include="models\Order\ModelProduct .cs" />[m
     <Compile Include="models\Order\ModelOrder.cs" />[m
[32m+[m[32m    <Compile Include="models\Order\UserControl1.xaml.cs">[m
[32m+[m[32m      <DependentUpon>UserControl1.xaml</DependentUpon>[m
[32m+[m[32m    </Compile>[m
     <Compile Include="models\SeatMap\ModelSeatMap.cs" />[m
     <Compile Include="models\Social\ModelSocial.cs" />[m
     <Compile Include="models\Social\SocialResponse.cs" />[m
[36m@@ -206,6 +216,7 @@[m
     <Compile Include="models\Users\ModelState.cs" />[m
     <Compile Include="models\Users\ModelUsers.cs" />[m
     <Compile Include="tests\SnackBar.cs" />[m
[32m+[m[32m    <Compile Include="tests\StartOrder.cs" />[m
     <Compile Include="tests\Support.cs" />[m
     <Compile Include="tests\Marketing.cs" />[m
     <Compile Include="tests\Theaters.cs" />[m
[36m@@ -226,7 +237,12 @@[m
     <None Include="app.config" />[m
     <None Include="packages.config" />[m
   </ItemGroup>[m
[31m-  <ItemGroup />[m
[32m+[m[32m  <ItemGroup>[m
[32m+[m[32m    <Page Include="models\Order\UserControl1.xaml">[m
[32m+[m[32m      <SubType>Designer</SubType>[m
[32m+[m[32m      <Generator>MSBuild:Compile</Generator>[m
[32m+[m[32m    </Page>[m
[32m+[m[32m  </ItemGroup>[m
   <Import Project="$(VSToolsPath)\TeamTest\Microsoft.TestTools.targets" Condition="Exists('$(VSToolsPath)\TeamTest\Microsoft.TestTools.targets')" />[m
   <Import Project="$(MSBuildToolsPath)\Microsoft.CSharp.targets" />[m
   <Target Name="EnsureNuGetPackageBuildImports" BeforeTargets="PrepareForBuild">[m
[1mdiff --git a/EcommerceBackend/Models/Order/ModelAppInfo.cs b/EcommerceBackend/Models/Order/ModelAppInfo.cs[m
[1mnew file mode 100644[m
[1mindex 0000000..d5f33a0[m
[1m--- /dev/null[m
[1m+++ b/EcommerceBackend/Models/Order/ModelAppInfo.cs[m
[36m@@ -0,0 +1,20 @@[m
[32m+[m[32m﻿using System;[m
[32m+[m[32musing System.Collections.Generic;[m
[32m+[m[32musing System.Linq;[m
[32m+[m[32musing System.Text;[m
[32m+[m[32musing System.Threading.Tasks;[m
[32m+[m
[32m+[m[32mnamespace EcommerceBackend.models.Order[m
[32m+[m[32m{[m
[32m+[m[32m   public class ModelAppInfo[m
[32m+[m[32m    {[m
[32m+[m[32m        public string Fingerprint { get; set; }[m[41m [m
[32m+[m[32m        public string deviceModel { get; set; }[m[41m [m
[32m+[m[32m        public string devicePlatform { get; set; }[m[41m [m
[32m+[m[32m        public string deviceUUID { get; set; }[m[41m [m
[32m+[m[32m        public ModelGeolocation geolocation { get; set; }[m[41m [m
[32m+[m[32m        public string version { get; set; }[m[41m [m
[32m+[m
[32m+[m
[32m+[m[32m    }[m
[32m+[m[32m}[m
[1mdiff --git a/EcommerceBackend/Models/Order/ModelFee.cs b/EcommerceBackend/Models/Order/ModelFee.cs[m
[1mindex dc4d1e4..e895e89 100644[m
[1m--- a/EcommerceBackend/Models/Order/ModelFee.cs[m
[1m+++ b/EcommerceBackend/Models/Order/ModelFee.cs[m
[36m@@ -8,7 +8,7 @@[m [mnamespace DemoRestSharp.models.Order[m
 {[m
     public class ModelFee[m
     {[m
[31m-        public int price { get; set; }[m
[32m+[m[32m        public double price { get; set; }[m
  [m
     }[m
 }[m
[1mdiff --git a/EcommerceBackend/Models/Order/ModelGeolocation.cs b/EcommerceBackend/Models/Order/ModelGeolocation.cs[m
[1mnew file mode 100644[m
[1mindex 0000000..eeee5fb[m
[1m--- /dev/null[m
[1m+++ b/EcommerceBackend/Models/Order/ModelGeolocation.cs[m
[36m@@ -0,0 +1,13 @@[m
[32m+[m[32m﻿using System;[m
[32m+[m[32musing System.Collections.Generic;[m
[32m+[m[32musing System.Linq;[m
[32m+[m[32musing System.Text;[m
[32m+[m[32musing System.Threading.Tasks;[m
[32m+[m
[32m+[m[32mnamespace EcommerceBackend.models.Order[m
[32m+[m[32m{[m
[32m+[m[32m    public class ModelGeolocation {[m[41m [m
[32m+[m[32m        public double latitude { get; set; }[m
[32m+[m[32m        public double longitude { get; set; }[m
[32m+[m[32m    }[m
[32m+[m[32m}[m
[1mdiff --git a/EcommerceBackend/Models/Order/ModelPayment.cs b/EcommerceBackend/Models/Order/ModelPayment.cs[m
[1mnew file mode 100644[m
[1mindex 0000000..5ec283b[m
[1m--- /dev/null[m
[1m+++ b/EcommerceBackend/Models/Order/ModelPayment.cs[m
[36m@@ -0,0 +1,20 @@[m
[32m+[m[32m﻿using System;[m
[32m+[m[32musing System.Collections.Generic;[m
[32m+[m[32musing System.Linq;[m
[32m+[m[32musing System.Text;[m
[32m+[m[32musing System.Threading.Tasks;[m
[32m+[m
[32m+[m[32mnamespace EcommerceBackend.models.Order[m
[32m+[m[32m{[m
[32m+[m[32m   public class ModelPayment {[m[41m [m
[32m+[m
[32m+[m
[32m+[m[32m        public string number { get; set; }[m
[32m+[m[32m        public string cpf { get; set; }[m
[32m+[m[32m        public string cvc { get; set; }[m
[32m+[m[32m        public string expiryMonth { get; set; }[m
[32m+[m[32m        public string expiryYear { get; set; }[m
[32m+[m[32m        public string holderName { get; set; }[m
[32m+[m[32m        public bool saveCardInformation { get; set; }[m
[32m+[m[32m    }[m
[32m+[m[32m}[m
[1mdiff --git a/EcommerceBackend/Models/Order/ModelProduct .cs b/EcommerceBackend/Models/Order/ModelProduct .cs[m
[1mindex 5cb681f..189ade4 100644[m
[1m--- a/EcommerceBackend/Models/Order/ModelProduct .cs[m	
[1m+++ b/EcommerceBackend/Models/Order/ModelProduct .cs[m	
[36m@@ -8,6 +8,7 @@[m [mnamespace DemoRestSharp.models.Order[m
 {[m
     public class ModelProduct[m
     {[m
[32m+[m[32m        public  string fee { get; set; }[m
         public string name { get; set; }[m
         public string theaterName { get; set; }[m
         public string theaterAddress { get; set; }[m
[1mdiff --git a/EcommerceBackend/Models/Order/ModelStartOrder.cs b/EcommerceBackend/Models/Order/ModelStartOrder.cs[m
[1mnew file mode 100644[m
[1mindex 0000000..af6ab32[m
[1m--- /dev/null[m
[1m+++ b/EcommerceBackend/Models/Order/ModelStartOrder.cs[m
[36m@@ -0,0 +1,84 @@[m
[32m+[m[32m﻿//using System;[m
[32m+[m[32m//using System.Collections.Generic;[m
[32m+[m[32m//using System.Linq;[m
[32m+[m[32m//using System.Text;[m
[32m+[m[32m//using System.Threading.Tasks;[m
[32m+[m[32m//using DemoRestSharp.models.Order;[m
[32m+[m
[32m+[m
[32m+[m[32m//namespace EcommerceBackend.models.Order[m
[32m+[m[32m//{[m
[32m+[m[32m//    public class ModelStartOrder[m
[32m+[m[32m//    {[m
[32m+[m[32m//        public Account account { get; set; }[m
[32m+[m[32m//        public AppInfo appInfo { get; set; }[m
[32m+[m[32m//        public int theaterId { get; set; }[m
[32m+[m[32m//        public Fee fee { get; set; }[m
[32m+[m[32m//        public int movieId { get; set; }[m
[32m+[m[32m//        public Payment payment { get; set; }[m
[32m+[m[32m//        public IList<Product> products { get; set; }[m
[32m+[m[32m//        public double total { get; set; }[m
[32m+[m[32m//    }[m
[32m+[m[32m//        public class Account[m
[32m+[m[32m//        {[m
[32m+[m[32m//            public string email { get; set; }[m
[32m+[m[32m//            public string identification { get; set; }[m
[32m+[m[32m//            public string name { get; set; }[m
[32m+[m[32m//        }[m
[32m+[m
[32m+[m[32m//        public class Geolocation[m
[32m+[m[32m//        {[m
[32m+[m[32m//            public double latitude { get; set; }[m
[32m+[m[32m//            public double longitude { get; set; }[m
[32m+[m[32m//        }[m
[32m+[m
[32m+[m[32m//        public class AppInfo[m
[32m+[m[32m//        {[m
[32m+[m[32m//            public string Fingerprint { get; set; }[m
[32m+[m[32m//            public string deviceModel { get; set; }[m
[32m+[m[32m//            public string devicePlatform { get; set; }[m
[32m+[m[32m//            public string deviceUUID { get; set; }[m
[32m+[m[32m//            public Geolocation geolocation { get; set; }[m
[32m+[m[32m//            public string version { get; set; }[m
[32m+[m[32m//        }[m
[32m+[m
[32m+[m[32m//        public class Fee[m
[32m+[m[32m//        {[m
[32m+[m[32m//            public double price { get; set; }[m
[32m+[m[32m//        }[m
[32m+[m
[32m+[m[32m//        public class Payment[m
[32m+[m[32m//        {[m
[32m+[m[32m//            public string number { get; set; }[m
[32m+[m[32m//            public string cpf { get; set; }[m
[32m+[m[32m//            public string cvc { get; set; }[m
[32m+[m[32m//            public string expiryMonth { get; set; }[m
[32m+[m[32m//            public string expiryYear { get; set; }[m
[32m+[m[32m//            public string holderName { get; set; }[m
[32m+[m[32m//            public bool saveCardInformation { get; set; }[m
[32m+[m[32m//        }[m
[32m+[m
[32m+[m[32m//        public class Product[m
[32m+[m[32m//        {[m
[32m+[m[32m//        public fee { get; set; }[m
[32m+[m[32m//        public int id { get; set; }[m
[32m+[m[32m//        public string name { get; set; }[m
[32m+[m[32m//        public int quantity { get; set; }[m
[32m+[m[32m//        public int subTotal { get; set; }[m
[32m+[m[32m//        public string theaterAddress { get; set; }[m
[32m+[m[32m//        public string theaterName { get; set; }[m
[32m+[m[32m//        public int theaterPOS { get; set; }[m
[32m+[m[32m//        public int unitPrice { get; set; }[m
[32m+[m[32m//        public string urlImagem { get; set; }[m
[32m+[m[32m//    }[m
[32m+[m
[32m+[m[41m   [m
[32m+[m[41m        [m
[32m+[m[32m//    }[m
[32m+[m
[32m+[m
[32m+[m
[32m+[m
[32m+[m
[32m+[m
[32m+[m
[1mdiff --git a/EcommerceBackend/Models/Order/UserControl1.xaml b/EcommerceBackend/Models/Order/UserControl1.xaml[m
[1mnew file mode 100644[m
[1mindex 0000000..11bce1a[m
[1m--- /dev/null[m
[1m+++ b/EcommerceBackend/Models/Order/UserControl1.xaml[m
[36m@@ -0,0 +1,12 @@[m
[32m+[m[32m﻿<UserControl x:Class="EcommerceBackend.models.Order.UserControl1"[m
[32m+[m[32m             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"[m
[32m+[m[32m             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"[m
[32m+[m[32m             xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"[m[41m [m
[32m+[m[32m             xmlns:d="http://schemas.microsoft.com/expression/blend/2008"[m[41m [m
[32m+[m[32m             xmlns:local="clr-namespace:EcommerceBackend.models.Order"[m
[32m+[m[32m             mc:Ignorable="d"[m[41m [m
[32m+[m[32m             d:DesignHeight="450" d:DesignWidth="800">[m
[32m+[m[32m    <Grid>[m
[32m+[m[41m            [m
[32m+[m[32m    </Grid>[m
[32m+[m[32m</UserControl>[m
[1mdiff --git a/EcommerceBackend/Models/Order/UserControl1.xaml.cs b/EcommerceBackend/Models/Order/UserControl1.xaml.cs[m
[1mnew file mode 100644[m
[1mindex 0000000..49f9ecb[m
[1m--- /dev/null[m
[1m+++ b/EcommerceBackend/Models/Order/UserControl1.xaml.cs[m
[36m@@ -0,0 +1,28 @@[m
[32m+[m[32m﻿using System;[m
[32m+[m[32musing System.Collections.Generic;[m
[32m+[m[32musing System.Linq;[m
[32m+[m[32musing System.Text;[m
[32m+[m[32musing System.Threading.Tasks;[m
[32m+[m[32musing System.Windows;[m
[32m+[m[32musing System.Windows.Controls;[m
[32m+[m[32musing System.Windows.Data;[m
[32m+[m[32musing System.Windows.Documents;[m
[32m+[m[32musing System.Windows.Input;[m
[32m+[m[32musing System.Windows.Media;[m
[32m+[m[32musing System.Windows.Media.Imaging;[m
[32m+[m[32musing System.Windows.Navigation;[m
[32m+[m[32musing System.Windows.Shapes;[m
[32m+[m
[32m+[m[32mnamespace EcommerceBackend.models.Order[m
[32m+[m[32m{[m
[32m+[m[32m    /// <summary>[m
[32m+[m[32m    /// Interação lógica para UserControl1.xam[m
[32m+[m[32m    /// </summary>[m
[32m+[m[32m    public partial class UserControl1 : UserControl[m
[32m+[m[32m    {[m
[32m+[m[32m        public UserControl1()[m
[32m+[m[32m        {[m
[32m+[m[32m            InitializeComponent();[m
[32m+[m[32m        }[m
[32m+[m[32m    }[m
[32m+[m[32m}[m
[1mdiff --git a/EcommerceBackend/app.config b/EcommerceBackend/app.config[m
[1mindex c62e3f4..d46dff6 100644[m
[1m--- a/EcommerceBackend/app.config[m
[1m+++ b/EcommerceBackend/app.config[m
[36m@@ -40,4 +40,4 @@[m
       </providers>[m
     </roleManager>[m
   </system.web>[m
[31m-<startup><supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.5.2"/></startup></configuration>[m
[32m+[m[32m<startup><supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.7.2"/></startup></configuration>[m
[1mdiff --git a/EcommerceBackend/packages.config b/EcommerceBackend/packages.config[m
[1mindex 7599e49..c1a56e0 100644[m
[1m--- a/EcommerceBackend/packages.config[m
[1m+++ b/EcommerceBackend/packages.config[m
[36m@@ -21,21 +21,21 @@[m
   <package id="RestSharp" version="106.6.10" targetFramework="net472" />[m
   <package id="SpecFlow" version="3.1.67" targetFramework="net472" />[m
   <package id="System.Buffers" version="4.3.0" targetFramework="net472" />[m
[31m-  <package id="System.Configuration.ConfigurationManager" version="4.7.0" targetFramework="net472" requireReinstallation="true" />[m
[31m-  <package id="System.IO" version="4.3.0" targetFramework="net472" requireReinstallation="true" />[m
[31m-  <package id="System.Net.Http" version="4.3.4" targetFramework="net472" requireReinstallation="true" />[m
[32m+[m[32m  <package id="System.Configuration.ConfigurationManager" version="4.7.0" targetFramework="net472" />[m
[32m+[m[32m  <package id="System.IO" version="4.3.0" targetFramework="net472" />[m
[32m+[m[32m  <package id="System.Net.Http" version="4.3.4" targetFramework="net472" />[m
   <package id="System.Reflection.Emit" version="4.3.0" targetFramework="net472" />[m
   <package id="System.Reflection.Emit.Lightweight" version="4.3.0" targetFramework="net472" />[m
[31m-  <package id="System.Runtime" version="4.3.0" targetFramework="net472" requireReinstallation="true" />[m
[32m+[m[32m  <package id="System.Runtime" version="4.3.0" targetFramework="net472" />[m
   <package id="System.Runtime.InteropServices.RuntimeInformation" version="4.0.0" targetFramework="net472" />[m
[31m-  <package id="System.Security.AccessControl" version="4.7.0" targetFramework="net472" requireReinstallation="true" />[m
[31m-  <package id="System.Security.Cryptography.Algorithms" version="4.3.0" targetFramework="net472" requireReinstallation="true" />[m
[31m-  <package id="System.Security.Cryptography.Encoding" version="4.3.0" targetFramework="net472" requireReinstallation="true" />[m
[31m-  <package id="System.Security.Cryptography.Primitives" version="4.3.0" targetFramework="net472" requireReinstallation="true" />[m
[31m-  <package id="System.Security.Cryptography.X509Certificates" version="4.3.0" targetFramework="net472" requireReinstallation="true" />[m
[31m-  <package id="System.Security.Permissions" version="4.7.0" targetFramework="net472" requireReinstallation="true" />[m
[31m-  <package id="System.Security.Principal.Windows" version="4.7.0" targetFramework="net472" requireReinstallation="true" />[m
[31m-  <package id="System.Threading.Tasks.Extensions" version="4.4.0" targetFramework="net472" requireReinstallation="true" />[m
[31m-  <package id="System.ValueTuple" version="4.4.0" targetFramework="net472" requireReinstallation="true" />[m
[31m-  <package id="Utf8Json" version="1.3.7" targetFramework="net472" requireReinstallation="true" />[m
[32m+[m[32m  <package id="System.Security.AccessControl" version="4.7.0" targetFramework="net472" />[m
[32m+[m[32m  <package id="System.Security.Cryptography.Algorithms" version="4.3.0" targetFramework="net472" />[m
[32m+[m[32m  <package id="System.Security.Cryptography.Encoding" version="4.3.0" targetFramework="net472" />[m
[32m+[m[32m  <package id="System.Security.Cryptography.Primitives" version="4.3.0" targetFramework="net472" />[m
[32m+[m[32m  <package id="System.Security.Cryptography.X509Certificates" version="4.3.0" targetFramework="net472" />[m
[32m+[m[32m  <package id="System.Security.Permissions" version="4.7.0" targetFramework="net472" />[m
[32m+[m[32m  <package id="System.Security.Principal.Windows" version="4.7.0" targetFramework="net472" />[m
[32m+[m[32m  <package id="System.Threading.Tasks.Extensions" version="4.4.0" targetFramework="net472" />[m
[32m+[m[32m  <package id="System.ValueTuple" version="4.4.0" targetFramework="net472" />[m
[32m+[m[32m  <package id="Utf8Json" version="1.3.7" targetFramework="net472" />[m
 </packages>[m
\ No newline at end of file[m
[1mdiff --git a/EcommerceBackend/tests/Order.cs b/EcommerceBackend/tests/Order.cs[m
[1mindex becd4ca..4f781a9 100644[m
[1m--- a/EcommerceBackend/tests/Order.cs[m
[1m+++ b/EcommerceBackend/tests/Order.cs[m
[36m@@ -8,6 +8,8 @@[m [musing DemoRestSharp.models.Order;[m
 using System.Collections.Generic;[m
 using EcommerceBackend.utils;[m
 using Newtonsoft.Json;[m
[32m+[m[32musing System.Reflection;[m
[32m+[m[32musing EcommerceBackend.models.Order;[m
 [m
 namespace EcommerceBackend[m
 [m
[36m@@ -16,6 +18,7 @@[m [mnamespace EcommerceBackend[m
     [TestFixture][m
     public class Order[m
     {[m
[32m+[m
         ExtentReports extent = null;[m
 [m
         [OneTimeSetUp][m
[36m@@ -177,14 +180,14 @@[m [mnamespace EcommerceBackend[m
                 utils.Utils.setAuthorizationToken(request, authorizationToken);[m
 [m
                 var response = client.Execute<List<ModelOrderLast>>(request);[m
[31m-[m
[32m+[m[41m              [m
                 //Início das validações[m
                 test.Log(Status.Info, "Validando se o Status Code de retorno da requisição é 200.");[m
                 Assert.That((int)response.StatusCode, Is.EqualTo(200), "Status Code divergente.");[m
 [m
                 if ((int)response.StatusCode == 200 && authorizationToken != null)[m
                 {[m
[31m-[m
[32m+[m[32m                    //testes realizados de forma unitaria[m
                     test.Log(Status.Info, "Início de validações de propriedades e valores.");[m
                     Assert.That(response.Data[0].id, Is.EqualTo("26a33aed-a360-451b-8f6d-a9ff00fc1118"), "Status Code divergente.");[m
                     Assert.That(response.Data[0].account[0].userId, Is.EqualTo(5640490), "Status Code divergente.");[m
[36m@@ -216,47 +219,117 @@[m [mnamespace EcommerceBackend[m
             }[m
         }[m
 [m
[31m-        // procurando solução no momento para o caso abaixo[m
[31m-[m
[31m-        //[Test][m
[31m-        //public void ValidaRealizaResgateIngresso()[m
[31m-        //{[m
[31m-        //    ExtentTest test = null;[m
[31m-        //    test = extent.CreateTest("ValidaRealizaResgateIngresso").Info("Início do teste.");[m
[31m-        //    try[m
[31m-        //    {[m
[31m-[m
[31m-        //        //Criando e enviando requisição[m
[31m-        //        test.Log(Status.Info, "Criando requisição responsável por realizar login.");[m
[31m-        //        var client = new RestClient(ConfigurationManager.AppSettings["dnsSensedia"]);[m
[31m-        //        var requestResgataIngresso = new RestRequest("order/v1/updateticketstatus", Method.POST);[m
[31m-        //        requestResgataIngresso.RequestFormat = DataFormat.Json;[m
[31m-        //        test.Log(Status.Info, "Setando headers necessários para realizar a requisição.");[m
[31m-        //        utils.Utils.setCisToken(requestResgataIngresso);[m
[31m-[m
[31m-        //        requestResgataIngresso.AddJsonBody(new[m
[31m-        //        {[m
[31m-        //            orderId = "363aa89c-2d6d-4ad5-9955-f9c71977bbd4",[m
[31m-        //            barCode = "8332249503394278478139",[m
[31m-        //            status = 1[m
[31m-        //        }[m
[31m-        //        );[m
[31m-           [m
[31m-        //        test.Log(Status.Info, "Enviando requisição.");[m
[31m-        //        var response = client.Execute<ModelOrderResgate>(requestResgataIngresso);[m
[31m-[m
[31m-        //        //Início das validações[m
[31m-        //        test.Log(Status.Info, "Validando se o Status Code de retorno da requisição é 200.");[m
[31m-        //        Assert.That((int)response.StatusCode, Is.EqualTo(200), "Status Code divergente.");[m
[31m-[m
[31m-[m
[31m-        //    }[m
[31m-        //    catch (Exception e)[m
[31m-        //    {[m
[31m-        //        test.Log(Status.Fail, e.ToString());[m
[31m-        //        throw new Exception("Falha ao validar resgate de ingresso supersaver: " + e.Message);[m
[31m-        //    }[m
[31m-        //}[m
[31m-     }[m
[32m+[m
[32m+[m
[32m+[m[32m        [Test][m
[32m+[m[32m        public void ValidaRealizaPedidoSnack()[m
[32m+[m[32m        {[m
[32m+[m[32m            ExtentTest test = null;[m
[32m+[m[32m            test = extent.CreateTest("ValidaRealizaPedidoSnack").Info("Início do teste.");[m
[32m+[m
[32m+[m[32m            try[m
[32m+[m[32m            {[m
[32m+[m
[32m+[m[32m                string authorizationToken = utils.Utils.getAuthorization("alexandre.ksss@gmail.com", "batata@1010");[m
[32m+[m[32m                //Criando e enviando requisição[m
[32m+[m[32m                test.Log(Status.Info, "Criando requisição responsável por realizar login.");[m
[32m+[m[32m                var client = new RestClient(ConfigurationManager.AppSettings["dnsSensedia"]);[m
[32m+[m[32m                var request = new RestRequest("order/v2/startorder", Method.POST);[m
[32m+[m[32m                request.RequestFormat = DataFormat.Json;[m
[32m+[m[32m                utils.Utils.setCisToken(request);[m
[32m+[m[32m                test.Log(Status.Info, "Setando headers necessários para realizar a requisição.");[m
[32m+[m[32m                utils.Utils.setAuthorizationToken(request, authorizationToken);[m
[32m+[m
[32m+[m[32m                //json original (do postman) foi alterado de aspas dupla para aspas simples[m[41m [m
[32m+[m[32m                //site https://csvjson.com/json_beautifier[m
[32m+[m[41m                [m
[32m+[m[32m                string json = @"{[m
[32m+[m[32m                                  'account': {[m
[32m+[m[32m                                    'email': 'alexandre.ksss@gmail.com',[m
[32m+[m[32m                                    'name': 'Alexandre Kenji Shimizu',[m
[32m+[m[32m                                    'userId': 7365872[m
[32m+[m[32m                                  },[m
[32m+[m[32m                                  'appInfo': {[m
[32m+[m[32m                                    'Fingerprint': 'atmxcmqlyqyydanpimtf94ysv91uunvy',[m
[32m+[m[32m                                    'deviceModel': 'SM-J701MT',[m
[32m+[m[32m                                    'devicePlatform': 'Android',[m
[32m+[m[32m                                    'deviceUUID': '75e73711-71ae-41c8-b883-b12c4151898c',[m
[32m+[m[32m                                    'geolocation': {[m
[32m+[m[32m                                      'latitude': -23.577729,[m
[32m+[m[32m                                      'longitude': -46.7969339[m
[32m+[m[32m                                    },[m
[32m+[m[32m                                    'version': '4.1.9'[m
[32m+[m[32m                                  },[m
[32m+[m[32m                                  'theaterId': 785,[m
[32m+[m[32m                                  'fee': {[m
[32m+[m[32m                                    'price': 10[m
[32m+[m[32m                                  },[m
[32m+[m[32m                                  'movieId': 0,[m
[32m+[m[32m                                  'payment': {[m
[32m+[m[32m                                    'number': 'mTSBDAgF/PbX+jicDGuqOEjpWAMo7rOuQ/LuLGGIesg=',[m
[32m+[m[32m                                    'cpf': '35074705940',[m
[32m+[m[32m                                    'cvc': '737',[m
[32m+[m[32m                                    'expiryMonth': '02',[m
[32m+[m[32m                                    'expiryYear': '2025',[m
[32m+[m[32m                                    'holderName': 'Tggg Hhhhh',[m
[32m+[m[32m                                    'saveCardInformation': true[m
[32m+[m[32m                                  },[m
[32m+[m[32m                                  'products': [[m
[32m+[m[32m                                    {[m
[32m+[m[32m                                      'fee': {[m
[32m+[m[32m                                        'price': 5[m
[32m+[m[32m                                      },[m
[32m+[m[32m                                      'id': 3375,[m
[32m+[m[32m                                      'name': 'Coca-Cola Grande',[m
[32m+[m[32m                                      'quantity': 1,[m
[32m+[m[32m                                      'subTotal': 26,[m
[32m+[m[32m                                      'theaterAddress': 'Av. Dr. Chucri Zaidan, 920 - Vila Cordeiro',[m
[32m+[m[32m                                      'theaterName': 'Market Place',[m
[32m+[m[32m                                      'theaterPOS': 3,[m
[32m+[m[32m                                      'unitPrice': 21,[m
[32m+[m[32m                                      'urlImagem': 'https://cdnim.hml.cineticket.com.br/snackbar/product/product_3375_20170605164929.png'[m
[32m+[m[32m                                    }[m
[32m+[m[32m                                  ],[m
[32m+[m[32m                                  'total': 27[m
[32m+[m[32m                                }";[m
[32m+[m
[32m+[m[41m             [m
[32m+[m[32m                request.AddParameter("application /json", json , ParameterType.RequestBody);[m
[32m+[m[41m  [m
[32m+[m[32m                var response = client.Execute(request);[m
[32m+[m[32m                test.Log(Status.Info, "Enviando requisição.");[m
[32m+[m[32m                Console.WriteLine(response);[m
[32m+[m[41m                [m
[32m+[m[41m              [m
[32m+[m
[32m+[m[32m                //Início das validações[m
[32m+[m[32m                test.Log(Status.Info, "Validando se o Status Code de retorno da requisição é 200.");[m
[32m+[m[32m                Assert.That((int)response.StatusCode, Is.EqualTo(200), "Status Code divergente.");[m
[32m+[m
[32m+[m
[32m+[m
[32m+[m
[32m+[m
[32m+[m[32m            }[m
[32m+[m[32m            catch (Exception e)[m
[32m+[m[32m            {[m
[32m+[m[32m                test.Log(Status.Fail, e.ToString());[m
[32m+[m[32m                throw new Exception("Falha ao validar geracao do pedido: " + e.Message);[m
[32m+[m[32m            }[m
[32m+[m[32m        }[m
[32m+[m
[32m+[m
[32m+[m
[32m+[m
[32m+[m
[32m+[m
[32m+[m
[32m+[m
[32m+[m
[32m+[m
[32m+[m
[32m+[m
[32m+[m[32m    }[m
[32m+[m[41m    [m
 [m
 }[m
[1mdiff --git a/EcommerceBackend/tests/StartOrder.cs b/EcommerceBackend/tests/StartOrder.cs[m
[1mnew file mode 100644[m
[1mindex 0000000..be0ec35[m
[1m--- /dev/null[m
[1m+++ b/EcommerceBackend/tests/StartOrder.cs[m
[36m@@ -0,0 +1,91 @@[m
[32m+[m[32m﻿//using System.Configuration;[m
[32m+[m[32m//using System;[m
[32m+[m[32m//using NUnit.Framework;[m
[32m+[m[32m//using RestSharp;[m
[32m+[m[32m//using AventStack.ExtentReports;[m
[32m+[m[32m//using AventStack.ExtentReports.Reporter;[m
[32m+[m[32m//using DemoRestSharp.models.Order;[m
[32m+[m[32m//using System.Collections.Generic;[m
[32m+[m[32m//using EcommerceBackend.utils;[m
[32m+[m[32m//using Newtonsoft.Json;[m
[32m+[m[32m//using System.Reflection;[m
[32m+[m[32m//using Dynamitey.DynamicObjects;[m
[32m+[m
[32m+[m
[32m+[m[32m//    public class StartOrder[m
[32m+[m[32m//{[m
[32m+[m[32m//    public string Email { get; set }[m
[32m+[m[32m//    public string Identification { get; set; }[m
[32m+[m[32m//    public int MyProperty { get; set; }[m
[32m+[m
[32m+[m[32m//}[m
[32m+[m
[32m+[m
[32m+[m
[32m+[m[32m//{[m[41m   [m
[32m+[m[32m//    [TestFixture][m
[32m+[m[32m//public class StartOrder[m
[32m+[m[32m//{[m
[32m+[m[32m//    ExtentReports extent = null;[m
[32m+[m
[32m+[m[32m//    [OneTimeSetUp][m
[32m+[m[32m//    public void StartReport()[m
[32m+[m[32m//    {[m
[32m+[m[32m//        extent = new ExtentReports();[m
[32m+[m[32m//        var htmlReporter = new ExtentHtmlReporter(@"C:\AutomationTools\EcommerceBackendReports\Reports\StartOrder\");[m
[32m+[m[32m//        extent.AttachReporter(htmlReporter);[m
[32m+[m
[32m+[m[32m//    }[m
[32m+[m
[32m+[m[32m//    [OneTimeTearDown][m
[32m+[m[32m//    public void CloseReport()[m
[32m+[m[32m//    {[m
[32m+[m[32m//        extent.Flush();[m
[32m+[m[32m//    }[m
[32m+[m
[32m+[m[32m//    [Test][m
[32m+[m[32m//    public void ValidaRealizaPedidoSnack()[m
[32m+[m[32m//    {[m
[32m+[m[32m//        ExtentTest test = null;[m
[32m+[m[32m//        test = extent.CreateTest("ValidaRealizaPedidoSnack").Info("Início do teste.");[m
[32m+[m
[32m+[m
[32m+[m
[32m+[m[32m//        try[m
[32m+[m[32m//        {[m
[32m+[m
[32m+[m[32m//            string authorizationToken = utils.Utils.getAuthorization("listadepedidos@mailinator.com", "112233");[m
[32m+[m
[32m+[m[32m//            //Criando e enviando requisição[m
[32m+[m[32m//            test.Log(Status.Info, "Criando requisição responsável por realizar login.");[m
[32m+[m[32m//            var client = new RestClient(ConfigurationManager.AppSettings["dnsSensedia"]);[m
[32m+[m[32m//            var request = new RestRequest("order/v2/startorder", Method.POST);[m
[32m+[m[32m//            request.RequestFormat = DataFormat.Json;[m
[32m+[m[32m//            utils.Utils.setCisToken(request);[m
[32m+[m[32m//            test.Log(Status.Info, "Setando headers necessários para realizar a requisição.");[m
[32m+[m[32m//            utils.Utils.setAuthorizationToken(request, authorizationToken);[m
[32m+[m
[32m+[m[32m//            request.AddJsonBody(body);[m
[32m+[m[32m//            request.AddParameter("application/json", body, ParameterType.RequestBody);[m
[32m+[m
[32m+[m
[32m+[m
[32m+[m[32m//            }[m
[32m+[m[32m//        catch (Exception e)[m
[32m+[m[32m//        {[m
[32m+[m[32m//            test.Log(Status.Fail, e.ToString());[m
[32m+[m[32m//            throw new Exception("Falha ao validar dados de consulta de ingresso: " + e.Message);[m
[32m+[m[32m//        }[m
[32m+[m
[32m+[m
[32m+[m
[32m+[m
[32m+[m
[32m+[m
[32m+[m
[32m+[m
[32m+[m[32m//    }[m
[32m+[m
[32m+[m
[32m+[m[32m//}[m
[32m+[m
[1mdiff --git a/EcommerceBackend/tests/Users.cs b/EcommerceBackend/tests/Users.cs[m
[1mindex e49adfa..c8f6f48 100644[m
[1m--- a/EcommerceBackend/tests/Users.cs[m
[1m+++ b/EcommerceBackend/tests/Users.cs[m
[36m@@ -42,12 +42,25 @@[m [mnamespace EcommerceBackend[m
                 var client = new RestClient(ConfigurationManager.AppSettings["dnsSensedia"]);[m
                 var request = new RestRequest("bus/v1/users/login/byapp", Method.POST);[m
                 request.RequestFormat = DataFormat.Json;[m
[31m-                request.AddJsonBody(new[m
[31m-                {[m
[31m-                    Email = "automaticusers@mailinator.com",[m
[31m-                    Password = "112233"[m
[31m-                }[m
[31m-                );[m
[32m+[m
[32m+[m[32m                //metodo que o andre fazia, era necessario atribuir um valor aos campos criados na model[m
[32m+[m[32m                //criar uma model[m[41m [m
[32m+[m
[32m+[m[32m                //request.AddJsonBody(new[m
[32m+[m[32m                //{[m
[32m+[m[32m                //    Email = "automaticusers@mailinator.com",[m
[32m+[m[32m                //    Password = "112233"[m
[32m+[m[32m                //}[m
[32m+[m[32m                //);[m
[32m+[m
[32m+[m
[32m+[m[41m     [m
[32m+[m[32m                string json = @"{[m
[32m+[m[32m                              'email': 'automaticusers@mailinator.com',[m
[32m+[m[32m                              'password': '112233'[m
[32m+[m[32m                                 }";[m
[32m+[m[41m                    [m
[32m+[m[32m                request.AddParameter("application/json", json, ParameterType.RequestBody);[m
                 test.Log(Status.Info, "Setando headers necessários para realizar a requisição.");[m
                 utils.Utils.setCisToken(request);[m
                 test.Log(Status.Info, "Enviando requisição.");[m
[1mdiff --git a/EcommerceBackend/utils/ResponseProperties.cs b/EcommerceBackend/utils/ResponseProperties.cs[m
[1mnew file mode 100644[m
[1mindex 0000000..110cb16[m
[1m--- /dev/null[m
[1m+++ b/EcommerceBackend/utils/ResponseProperties.cs[m
[36m@@ -0,0 +1,21 @@[m
[32m+[m[32m﻿using System;[m
[32m+[m[32musing System.Collections.Generic;[m
[32m+[m[32musing System.Linq;[m
[32m+[m[32musing System.Text;[m
[32m+[m[32musing System.Threading.Tasks;[m
[32m+[m
[32m+[m[32mnamespace EcommerceBackend.utils[m
[32m+[m[32m{[m
[32m+[m[32m    public static class ResponseProperties[m
[32m+[m[32m    {[m
[32m+[m[32m        public static string[] orderProperties = new string[][m
[32m+[m[32m         {"\"id\":", "\"externalId\":", "\"status\":", "\"orderDate\":",[m
[32m+[m[32m            "\"expirationDate\":", "\"theaterId\":", "\"movieId\":", "\"movieId\":", "\"account\":", "\"userId\":",[m[41m [m
[32m+[m[32m            "\"applicationUserId\":","\"identification\":", "\"email\":", "\"name\":", "\"phone\":", "\"type\":",[m
[32m+[m[32m            "\"ticketCode\":", "\"tickets\":", "\"products\":", "\"name\":", "\"unitPrice\":", "\"status\":",[m
[32m+[m[32m            "\"integrationCode\":", "\"integrationTracking\":", "\"total\":", "\"order\":", "\"localizationType\":",[m[41m [m
[32m+[m[32m            "\"rating\":", "\"sessionType\":"};[m
[32m+[m
[32m+[m[41m       [m
[32m+[m[32m    }[m
[32m+[m[32m}[m
