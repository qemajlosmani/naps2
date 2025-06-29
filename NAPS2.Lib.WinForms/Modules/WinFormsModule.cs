﻿using Autofac;
using NAPS2.EtoForms.Ui;
using NAPS2.ImportExport;
using NAPS2.ImportExport.Email;
using NAPS2.ImportExport.Email.Mapi;
using NAPS2.Platform.Windows;

namespace NAPS2.Modules;

public class WinFormsModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<WindowsApplicationLifecycle>().As<ApplicationLifecycle>();
        builder.RegisterType<PrintDocumentPrinter>().As<IScannedImagePrinter>();
        builder.RegisterType<WindowsServiceManager>().As<IOsServiceManager>().SingleInstance();
        builder.RegisterType<WindowsOpenWith>().As<IOpenWith>();
        builder.RegisterType<MapiEmailProvider>().As<IEmailProvider>().WithParameter("systemDefault", true);
        builder.RegisterType<MapiEmailClients>().As<ISystemEmailClients>();

        builder.RegisterType<WinFormsDesktopForm>().As<DesktopForm>();
        builder.RegisterType<WinFormsPreviewForm>().As<PreviewForm>();

        // TODO: Can we add a test for this?
        builder.RegisterBuildCallback(ctx =>
            Log.EventLogger = ctx.Resolve<WindowsEventLogger>());
    }
}