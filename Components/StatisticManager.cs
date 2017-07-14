using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetNuke.Data;
using DotNetNuke.Framework;
using MVCModule.Models;

namespace MVCModule.Components
{
    interface IStatisticManager
    {
        void CreateStatistic(Statistic s);
        void DeleteStatistic(int statisticId, int moduleId);
        void DeleteStatisticById(int statisticId);
        void DeleteStatistic(Statistic s);
        IEnumerable<Statistic> GetStatistics(int moduleId);
        IEnumerable<Statistic> GetAllStatistics();
        Statistic GetStatistic(int statisticId, int moduleId);
        Statistic GetStatisticById(int statisticId);
        void UpdateStatistic(Statistic s);
    }
    class StatisticManager : ServiceLocator<IStatisticManager, StatisticManager>, IStatisticManager
    {
        public void CreateStatistic(Statistic s)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Statistic>();
                rep.Insert(s);
            }
        }

        public void DeleteStatistic(int productId, int moduleId)
        {
            var s = GetStatistic(productId, moduleId);
            DeleteStatistic(s);
        }

        public void DeleteStatisticById(int productId)
        {
            var s = GetStatisticById(productId);
            DeleteStatistic(s);
        }

        public void DeleteStatistic(Statistic s)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Statistic>();
                rep.Delete(s);
            }
        }

        public IEnumerable<Statistic> GetStatistics(int moduleId)
        {
            IEnumerable<Statistic> s;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Statistic>();
                s = rep.Get(moduleId);
            }
            return s;
        }

        public IEnumerable<Statistic> GetAllStatistics()
        {
            IEnumerable<Statistic> s;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Statistic>();
                s = rep.Get();
            }
            return s;
        }

        public Statistic GetStatistic(int productId, int moduleId)
        {
            Statistic s;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Statistic>();
                s = rep.GetById(productId, moduleId);
            }
            return s;
        }

        public Statistic GetStatisticById(int productId)
        {
            Statistic s;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Statistic>();
                s = rep.GetById(productId);
            }
            return s;
        }

        public void UpdateStatistic(Statistic s)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Statistic>();
                rep.Update(s);
            }
        }

        protected override System.Func<IStatisticManager> GetFactory()
        {
            return () => new StatisticManager();
        }
    }
}