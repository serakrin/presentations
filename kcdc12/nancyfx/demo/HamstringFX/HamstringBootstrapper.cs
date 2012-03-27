﻿using HamstringFX.data;
using Nancy;
using Nancy.Conventions;
using Nancy.Hosting.Aspnet;

namespace HamstringFX {
  public class HamstringBootstrapper : DefaultNancyBootstrapper {

    protected override void ConfigureConventions (NancyConventions conventions) {
      base.ConfigureConventions (conventions);

      conventions.StaticContentsConventions.Add (
        StaticContentConventionBuilder.AddDirectory ("scripts", @"content\scripts"));
      conventions.StaticContentsConventions.Add (
        StaticContentConventionBuilder.AddDirectory ("styles", @"content\styles"));
      conventions.StaticContentsConventions.Add (
        StaticContentConventionBuilder.AddDirectory ("img", @"content\img"));
    }

    protected override void ConfigureRequestContainer(TinyIoC.TinyIoCContainer container, NancyContext context) {
      base.ConfigureRequestContainer(container, context);

      container.Register<IHamstringData, HamstringData>().AsPerRequestSingleton();
    }
  }
}