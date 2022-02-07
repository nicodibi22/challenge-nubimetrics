using NHibernate;
using System;
using System.Collections.Generic;
using System.Text;

namespace challenge_nubimetrics_data.Utils
{
    public interface IHelper
    {
        public ISession GetCurrentSession();
        public void CloseSession();
        public ISessionFactory FluentConfigure();
    }
}
