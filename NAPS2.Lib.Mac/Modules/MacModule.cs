﻿using Autofac;
using NAPS2.EtoForms;
using NAPS2.EtoForms.Mac;
using NAPS2.EtoForms.Ui;
using NAPS2.ImportExport;
using NAPS2.ImportExport.Email;

namespace NAPS2.Modules;

public class MacModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<MacApplicationLifecycle>().As<ApplicationLifecycle>();
        builder.RegisterType<MacScannedImagePrinter>().As<IScannedImagePrinter>();
        builder.RegisterType<AppleMailEmailProvider>().As<IAppleMailEmailProvider>();
        builder.RegisterType<MacIconProvider>().As<IIconProvider>();
        builder.RegisterType<MacServiceManager>().As<IOsServiceManager>();
        builder.RegisterType<MacOpenWith>().As<IOpenWith>();
        builder.RegisterType<AppleMailEmailProvider>().As<IEmailProvider>().WithParameter("systemDefault", true);
        builder.RegisterType<StubSystemEmailClients>().As<ISystemEmailClients>();

        builder.RegisterType<MacDesktopForm>().As<DesktopForm>();
        builder.RegisterType<MacPreviewForm>().As<PreviewForm>();
    }
}
