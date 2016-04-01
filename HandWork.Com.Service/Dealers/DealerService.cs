using HandWork.Com.Model.Dealers;
using HandWork.Com.Provider.Contexts;
using HandWork.Com.Provider.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;


namespace HandWork.Com.Service.Dealers
{
    public static class DealerService
    {
        //private string connstr = WebConfigurationManager.ConnectionStrings["connstring"].ToString();

        public static void Insert(Dealer dealer)
        {
            //string ins = string.Format("INSERT INTO delear_info (Name) VALUES ('{0}')", dealer.Name);
            //using (MySqlConnection mycon = new MySqlConnection(connstr))
            //{
            //    using (MySqlCommand cmd = new MySqlCommand(ins, mycon))
            //    {
            //        mycon.Open();
            //        int a = cmd;
            //      }
            //}
            Repository<Dealer> re = new Repository<Dealer>(new EntityContext());
            re.Insert(dealer);


        }
        public static void Alert(Dealer de)
        {
            Repository<Dealer> re = new Repository<Dealer>(new EntityContext());
            re.Update(de);


        }
        public static Dealer Get(long id)
        {
            Repository<Dealer> re = new Repository<Dealer>(new EntityContext());
            Dealer dealer=re.GetEntity(id);

            return dealer;
        }
        public static void SendMsg()
        {


        }
        public static void DelMsg()
        {


        }
    }
}