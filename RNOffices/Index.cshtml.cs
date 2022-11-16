using HSALeadershipWebApp.Pages.RNOffices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace HSALeadershipWebApp.Pages.RNOffices
{
    [Authorize]
    public class IndexModel : PageModel
    {
        public List<RNofficeInfo> listRnoffices = new List<RNofficeInfo>();
        public void OnGet()
        {
            try
            {
                String connectionString = "Data Source=******;Initial Catalog=******;Persist Security Info=True;User ID=******;Password=******";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "select company_name, company_id, office_name, office_id, agent_count, is_open, formatted_address, isnull(office_phone_number,'') as office_phone_number, " +
                                 "isnull(mb_first_name,'') as mb_first_name, isnull(mb_last_name,'') as mb_last_name, isnull(mb_email_address,'') as mb_email_address, isnull(mb_mobile_phone,'') as mb_mobile_phone, " +
                                 "isnull(mb_id,'') as mb_id, isnull(admin_first_name,'') as admin_first_name, isnull(admin_last_name,'') as admin_last_name, isnull(admin_email_address,'') as admin_email_address, " +
                                 "isnull(admin_mobile_phone,'') as admin_mobile_phone, isnull(admin_id,'') as admin_id from ******;";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                RNofficeInfo rnofficeInfo = new RNofficeInfo();

                                rnofficeInfo.Company_name = reader.GetString(0);
                                rnofficeInfo.Company_id = reader.GetString(1);
                                rnofficeInfo.Office_name = reader.GetString(2);
                                rnofficeInfo.Office_id = reader.GetString(3);
                                rnofficeInfo.Agent_count = "" + reader.GetInt32(4);
                                rnofficeInfo.Is_open = reader.GetString(5);
                                rnofficeInfo.Formatted_address = reader.GetString(6);
                                rnofficeInfo.Office_phone_number = reader.GetString(7);
                                rnofficeInfo.Mb_first_name = reader.GetString(8);
                                rnofficeInfo.Mb_last_name = reader.GetString(9);
                                rnofficeInfo.Mb_email_address = reader.GetString(10);
                                rnofficeInfo.Mb_mobile_phone = reader.GetString(11);
                                rnofficeInfo.Mb_id = "" + reader.GetInt32(12);
                                rnofficeInfo.Admin_first_name = reader.GetString(13);
                                rnofficeInfo.Admin_last_name = reader.GetString(14);
                                rnofficeInfo.Admin_email_address = reader.GetString(15);
                                rnofficeInfo.Admin_mobile_phone = reader.GetString(16);
                                rnofficeInfo.Admin_id = "" + reader.GetInt32(17);

                                listRnoffices.Add(rnofficeInfo);

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Exception: " + ex.ToString());
            }
        }
    }


    public class RNofficeInfo
    {
        public string Company_name { get; set; }
        public string Company_id { get; set; }
        public string Office_name { get; set; }
        public string Office_id { get; set; }
        public string Agent_count { get; set; }
        public string Is_open { get; set; }
        public string Formatted_address { get; set; }
        public string Office_phone_number { get; set; }
        public string Mb_first_name { get; set; }
        public string Mb_last_name { get; set; }
        public string Mb_email_address { get; set; }
        public string Mb_mobile_phone { get; set; }
        public string Mb_id { get; set; }
        public string Admin_first_name { get; set; }
        public string Admin_last_name { get; set; }
        public string Admin_email_address { get; set; }
        public string Admin_mobile_phone { get; set; }
        public string Admin_id { get; set; }


    }
}