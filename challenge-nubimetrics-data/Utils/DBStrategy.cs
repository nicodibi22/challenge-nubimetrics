using NHibernate;
using System;
using System.Collections.Generic;
using System.Text;

namespace challenge_nubimetrics_data.Utils
{
    public interface DBStrategy
    {
        ISessionFactory BuildSessionFactory();
        ISession GetCurrentSession();
    }
}
