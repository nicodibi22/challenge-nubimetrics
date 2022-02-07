using challenge_nubimetrics_models.Entities;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace challenge_nubimetrics_data.Utils
{
    public class MSSQLStrategy : DBStrategy
    {
        private ISessionFactory _sessionFactory;
        private NHibernate.ISession _session;
        public ISessionFactory BuildSessionFactory()
        {
            _sessionFactory = Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2012
                        //.ConnectionString("Server=.\\;initial catalog=nubimetrics;Integrated Security=True")
                        .ConnectionString(ConfigurationManager.ConnectionStrings["nubimetrics"].ConnectionString)
                        )
                .Cache(
                    c => c.UseQueryCache()
                        .UseSecondLevelCache()
                        .ProviderClass<NHibernate.Cache.HashtableCacheProvider>())

                .Mappings(m => m.FluentMappings.AddFromAssembly(typeof(MonedaEntity).Assembly))
                .BuildSessionFactory();
            return _sessionFactory;
        }

        public NHibernate.ISession GetCurrentSession()
        {
            if (_session == null || !_session.IsOpen)
                _session = _sessionFactory.OpenSession();
            return _session;
        }
    }
}
