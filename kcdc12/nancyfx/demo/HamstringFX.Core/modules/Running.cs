﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nancy;
using PetaPoco;

namespace HamstringFX.Core.modules {
  public class Running : NancyModule {
    private readonly Database _db;

    public Running(Database db) {

      Get["/run"] = p => {
        return HttpStatusCode.NotFound;
      };

      Post["/run"] = p => {
        try {
          Guid newId = Guid.NewGuid();
      

          return HttpStatusCode.OK;
        } catch (Exception ex) {

          return HttpStatusCode.InternalServerError;
        }
      };

      Get["/runs"] = p => {
        return HttpStatusCode.NotFound;
      };
    }
  }
}