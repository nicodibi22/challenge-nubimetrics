using NHibernate;
using System;
using System.Collections.Generic;
using System.Text;

namespace challenge_nubimetrics_data.Utils
{
    public class NHibernateHelper : IHelper
    {
        private const string CurrentSessionKey = "nhibernate.current_session";
        private ISessionFactory _sessionFactory;

        private DBStrategy _strategy;
        
        public NHibernateHelper(DBStrategy strategy)
        {
            if (strategy != null && _strategy == null)
            {
                _strategy = strategy;
                _sessionFactory = _strategy.BuildSessionFactory();
            }

        }

        public ISession GetCurrentSession()
        {
            return _strategy.GetCurrentSession();

        }
        public void CloseSession()
        {
            if (!_sessionFactory.IsClosed)
                _sessionFactory.Close();
        }

        public ISessionFactory FluentConfigure()
        {
            return _strategy.BuildSessionFactory();
        }

    }
}
