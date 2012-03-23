﻿using Nancy;

namespace HamstringFX.Core.modules {
  public class Hamstring : NancyModule {
    private readonly dynamic _db;

    public Hamstring(IDataStore db) {
      _db = db.Open();

      Get["/"] = parameters => {
        return View["hamstring.sshtml", Fake.HamstringModel ()];
      };
    }
  }
}