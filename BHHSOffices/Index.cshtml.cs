using HSALeadershipWebApp.Pages.RNOffices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace HSALeadershipWebApp.Pages.BHHSOffices
{
    [Authorize]
    public class IndexModel : PageModel
    {
        public List<BHHSofficeInfo> listBhhsoffices = new List<BHHSofficeInfo>();
        public void OnGet()
        {
            try
            {
                String connectionString = "Data Source=******;Initial Catalog=******;Persist Security Info=True;User ID=******;Password=******";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "select company_name, company_id, office_name, office_id, isnull(agent_count,'') as agent_count, is_open, formatted_address, isnull(office_phone_number,'') as office_phone_number, " +
                                 "isnull(mb_first_name,'') as mb_first_name, isnull(mb_last_name,'') as mb_last_name, isnull(mb_email_address,'') as mb_email_address, isnull(mb_mobile_phone,'') as mb_mobile_phone, " +
                                 "isnull(mb_id,'') as mb_id, isnull(admin_first_name,'') as admin_first_name, isnull(admin_last_name,'') as admin_last_name, isnull(admin_email_address,'') as admin_email_address, " +
                                 "isnull(admin_mobile_phone,'') as admin_mobile_phone, isnull(admin_id,'') as admin_id from ******;";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                BHHSofficeInfo bhhsofficeInfo = new BHHSofficeInfo();

                                bhhsofficeInfo.Company_name = reader.GetString(0);
                                bhhsofficeInfo.Company_id = reader.GetString(1);
                                bhhsofficeInfo.Office_name = reader.GetString(2);
                                bhhsofficeInfo.Office_id = reader.GetString(3);
                                bhhsofficeInfo.Agent_count = "" + reader.GetInt32(4);
                                bhhsofficeInfo.Is_open = reader.GetString(5);
                                bhhsofficeInfo.Formatted_address = reader.GetString(6);
                                bhhsofficeInfo.Office_phone_number = reader.GetString(7);
                                bhhsofficeInfo.Mb_first_name = reader.GetString(8);
                                bhhsofficeInfo.Mb_last_name = reader.GetString(9);
                                bhhsofficeInfo.Mb_email_address = reader.GetString(10);
                                bhhsofficeInfo.Mb_mobile_phone = reader.GetString(11);
                                bhhsofficeInfo.Mb_id = "" + reader.GetInt32(12);
                                bhhsofficeInfo.Admin_first_name = reader.GetString(13);
                                bhhsofficeInfo.Admin_last_name = reader.GetString(14);
                                bhhsofficeInfo.Admin_email_address = reader.GetString(15);
                                bhhsofficeInfo.Admin_mobile_phone = reader.GetString(16);
                                bhhsofficeInfo.Admin_id = "" + reader.GetInt32(17);

                                listBhhsoffices.Add(bhhsofficeInfo);

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


    public class BHHSofficeInfo
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