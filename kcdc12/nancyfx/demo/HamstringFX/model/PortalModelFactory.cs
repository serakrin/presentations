using System;
using System.Linq;
using HamstringFX.data;

namespace HamstringFX.model {
  internal class PortalModelFactory : IModelFactory {
    public PortalModelFactory(IHamstringData db, Member member) {
      _db = db;
      _member = member;
    }

    private readonly IHamstringData _db;
    private readonly Member _member;

    public dynamic Create() {
      var model = new {
        BestRouteTime = TimeSpan.FromMinutes(25).ToString(),
        RunningRoutes = _db.Routes.OrderBy(r => r.Name),
        Runs = _db.Runs
          .Where(r => r.MemberId == _member.Id)
          .OrderByDescending(r => r.ScheduledAt)
          .Select(r => new {
            r.Id,
            r.Duration,
            r.ScheduledAt,
            RouteName = r.Route.Name,
            r.Route.Distance
          }).ToList(),
        Playlists = _db.Playlists
          .Where(p => p.MemberId == _member.Id)
          .OrderBy(p => p.Name)
          .Select(p => new {
            p.Name,
            p.Duration,
            p.SongCount,
            p.Image
          }).ToList(),
        IsLoggedIn = true,
        MemberName = _member.Handle
      };

      return model;
    }
  }
}