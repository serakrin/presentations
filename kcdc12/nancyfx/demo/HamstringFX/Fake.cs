using System;
using System.Collections.Generic;
using System.Linq;
using HamstringFX.data;

namespace HamstringFX {
  internal static class Fake {



    private class Route {
      public Guid Id { get; set; }
    }

    public static dynamic HamstringModel (IHamstringData db) {

      var model = new {
        RunningRoutes = db.Routes.OrderBy(r => r.Name),
        Runs = new List<dynamic>(),
        Playlists = new List<dynamic>()
      };

      model.Playlists.Add(new {
        Name = "Thump Pop",
        Length = "07:24:03",
        Image = "playlist1.png"
      });

      model.Playlists.Add(new {
        Name = "Groove",
        Length = "25:40",
        Image = "playlist2.png"
      });

      model.Playlists.Add(new {
        Name = "Again With Feeling",
        Length = "02:00:30",
        Image = "playlist3.png"
      });

      model.Playlists.Add(new {
        Name = "Noise Canon",
        Length = "23:27",
        Image = "playlist4.png"
      });

      return model;
    }
  }
}