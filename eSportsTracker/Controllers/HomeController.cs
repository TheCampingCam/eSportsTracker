using eSportsTracker.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace eSportsTracker.Controllers
{
    public class HomeController : Controller
    {
        private EsportsTrackerEntities1 db = new EsportsTrackerEntities1();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "CSSE 333 Database Project: eSportsTracker";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Email:";

            return View();
        }

        public ActionResult Import()
        {
            ViewBag.Message = "Import Data";

            return View();
        }

        [HttpPost]
        public ActionResult Import(HttpPostedFileBase file)
        {
            
            try {
                DataSet ds = new DataSet();
                if (Request.Files["file"].ContentLength > 0)
                {
                    string fileExtension = System.IO.Path.GetExtension(Request.Files["file"].FileName);

                    if (fileExtension == ".xls" || fileExtension == ".xlsx")
                    {
                        string fileLocation = Server.MapPath("~/Content/") + Request.Files["file"].FileName;
                        if (System.IO.File.Exists(fileLocation))
                        {
                            System.IO.File.Delete(fileLocation);
                        }
                        Request.Files["file"].SaveAs(fileLocation);
                        string excelConnectionString = string.Empty;
                        excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                        fileLocation + ";Extended Properties=\"Excel 12.0;HDR=No;IMEX=1\"";
                        //connection String for xls file format.
                        if (fileExtension == ".xls")
                        {
                            excelConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" +
                            fileLocation + ";Extended Properties=\"Excel 8.0;HDR=No;IMEX=1\"";
                        }
                        //connection String for xlsx file format.
                        else if (fileExtension == ".xlsx")
                        {
                            excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                            fileLocation + ";Extended Properties=\"Excel 12.0;HDR=No;IMEX=1\"";
                        }
                        //Create Connection to Excel work book and add oledb namespace
                        OleDbConnection excelConnection = new OleDbConnection(excelConnectionString);
                        excelConnection.Open();
                        DataTable dt = new DataTable();

                        dt = excelConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                        if (dt == null)
                        {
                            return null;
                        }

                        String[] excelSheets = new String[dt.Rows.Count];
                        int t = 0;
                        //excel data saves in temp file here.
                        foreach (DataRow row in dt.Rows)
                        {
                            excelSheets[t] = row["TABLE_NAME"].ToString();
                            t++;
                        }
                        OleDbConnection excelConnection1 = new OleDbConnection(excelConnectionString);

                        List<String> properOrder = new List<string> {"Team", "Player", "VideoGame", "User", "Organization", "Match", "SoloMatch", "TeamMatch", "Tournament", "Owns", "ParticipatesIn", "PartOf", "PlaysIn", "PlaysOn", "SponsoredBy", "MatchOf", "Enters", "CompetesIn", "AttributesTable", "MatchAttribute" };
                        
                        foreach (string tab in properOrder)
                        {
                            if (excelSheets.Contains(tab))
                            {
                                int i = Array.IndexOf(excelSheets, tab);

                                string query = string.Format("Select * from [{0}]", excelSheets[i]);
                                using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, excelConnection1))
                                {
                                    string dbQueryBase = "";
                                    ds = new DataSet();
                                    dataAdapter.Fill(ds);
                                    if (tab.Equals("Team") || tab.Equals("Player") || tab.Equals("VideoGame") || tab.Equals("AttributesTable") || tab.Equals("Match") || tab.Equals("Organization") || tab.Equals("SponsoredBy") || tab.Equals("Tournament")) 
                                    {
                                        dbQueryBase = dbQueryBase + "Set IDENTITY_INSERT [" + excelSheets[i] + "] ON; ";
                                    }
                                    dbQueryBase = dbQueryBase + "Insert into [" + excelSheets[i] + "] (";
                                    var columns = ds.Tables[0].Rows[0].ItemArray;
                                    for (int l = 0; l < columns.Length; l++)
                                    {
                                        if (l == columns.Length - 1)
                                        {
                                            dbQueryBase = dbQueryBase + "[" + columns[l].ToString() + "])";
                                        }
                                        else
                                        {
                                            dbQueryBase = dbQueryBase + "[" + columns[l].ToString() + "], ";
                                        }
                                    }

                                    for (int j = 1; j < ds.Tables[0].Rows.Count; j++)
                                    {

                                        int size = columns.Length;
                                        string dbQuery = dbQueryBase + " Values('";
                                        for (int k = 0; k < size; k++)
                                        {
                                            if (k == size - 1)
                                            {
                                                dbQuery = dbQuery + ds.Tables[0].Rows[j][k].ToString() + "'); ";
                                            }
                                            else
                                            {
                                                dbQuery = dbQuery + ds.Tables[0].Rows[j][k].ToString() + "','";
                                            }

                                        }

                                        if (tab.Equals("Team") || tab.Equals("Player") || tab.Equals("VideoGame") || tab.Equals("AttributesTable") || tab.Equals("Match") || tab.Equals("Organization") || tab.Equals("SponsoredBy") || tab.Equals("Tournament"))
                                        {
                                            dbQuery = dbQuery + "Set IDENTITY_INSERT [" + excelSheets[i] + "] OFF;";
                                        }
                                        db.Database.ExecuteSqlCommand(dbQuery);
                                    }

                                }
                                ds.Clear();
                            }
                        }
                        db.SaveChanges();
                        ViewBag.Error = "Import Was Successful";
                    }
                    else
                    {
                        return null;
                    }
                }
            } catch (Exception e)
            {
                ViewBag.Error = "Import Was not Successful";
                // do nothing rn :(
            }

            return View();
        }
    }
}