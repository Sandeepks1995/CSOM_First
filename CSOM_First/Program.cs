using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint.Client;
namespace CSOM_First
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //SiteConnect();
            //GetLists();
            //CreateListItem();
            //UpdateListItem();
            DelListItem();
            Console.ReadLine();
        }
        static void SiteConnect()
        {
            using (var ctx = new PnP.Framework.AuthenticationManager().GetACSAppOnlyContext(System.Configuration.ConfigurationManager.AppSettings["O365site"], System.Configuration.ConfigurationManager.AppSettings["ClientId"], System.Configuration.ConfigurationManager.AppSettings["ClientSecret"]))
            {
                Web _web = ctx.Web;
                ctx.Load(_web);
                ctx.ExecuteQuery();
                Console.WriteLine(_web.Title);
            }
        }

        static void GetLists()
        {
            using (var ctx = new PnP.Framework.AuthenticationManager().GetACSAppOnlyContext(System.Configuration.ConfigurationManager.AppSettings["O365site"], System.Configuration.ConfigurationManager.AppSettings["ClientId"], System.Configuration.ConfigurationManager.AppSettings["ClientSecret"]))
            {
                Web _web = ctx.Web;
                ListCollection _AllList = _web.Lists;
                ctx.Load(_AllList);
                ctx.ExecuteQuery();
                foreach (List _list in _AllList)
                    Console.WriteLine(_list.Title);
            }
        }

        static void CreateListItem()
        {
            using (var ctx = new PnP.Framework.AuthenticationManager().GetACSAppOnlyContext(System.Configuration.ConfigurationManager.AppSettings["O365site"], System.Configuration.ConfigurationManager.AppSettings["ClientId"], System.Configuration.ConfigurationManager.AppSettings["ClientSecret"]))
            {
                Web _web = ctx.Web;
                List _List = _web.GetListByTitle("INQUIRY");
                ListItemCreationInformation _LICI = new ListItemCreationInformation();
                ListItem _Item = _List.AddItem(_LICI);
                _Item["Inquiry"] = "JSOM";
                _Item["Inquiry_x0020_for"] = "SharePoint";
                _Item["Phone"] = "9044906769";
                _Item["Way_x0020_of_x0020_communication"] = "Phone";
                _Item["EMail"] = "sss@gmail.com";
                _Item.Update();
                ctx.Load(_Item);
                ctx.ExecuteQuery();
                Console.WriteLine(" Item Created At.." + _Item.Id);
            }
        }
        static void UpdateListItem()
        {
            using (var ctx = new PnP.Framework.AuthenticationManager().GetACSAppOnlyContext(System.Configuration.ConfigurationManager.AppSettings["O365site"], System.Configuration.ConfigurationManager.AppSettings["ClientId"], System.Configuration.ConfigurationManager.AppSettings["ClientSecret"]))
            {
                Web _web = ctx.Web;
                List _List = _web.GetListByTitle("INQUIRY");
                ListItem _Item = _List.GetItemById(3);
                _Item["Inquiry_x0020_for"] = "Web Development";
                _Item["Way_x0020_of_x0020_communication"] = "Email";
                _Item.Update();
                ctx.ExecuteQuery();
                Console.WriteLine("Updated Item Id... ");

            }
        }
        static void DelListItem()
        {
            using (var ctx = new PnP.Framework.AuthenticationManager().GetACSAppOnlyContext(System.Configuration.ConfigurationManager.AppSettings["O365site"], System.Configuration.ConfigurationManager.AppSettings["ClientId"], System.Configuration.ConfigurationManager.AppSettings["ClientSecret"]))
            {
                Web _web = ctx.Web;
                List _List = _web.GetListByTitle("INQUIRY");
                ListItem _Item = _List.GetItemById(1);
                _Item.DeleteObject();
                ctx.ExecuteQuery();
                Console.WriteLine(_Item.Id + " Item Id Deleted..");

            }
        }
    }
}
