using HSALeadershipWebApp.Pages.Leadership;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace HSALeadershipWebApp.Pages.Leadership
{
    [Authorize]
    public class IndexModel : PageModel
    {
        public List<LeadershipInfo> listLeadership = new List<LeadershipInfo>();
        public void OnGet()
        {
            try
            {
                String connectionString = "Data Source=******;Initial Catalog=******;Persist Security Info=True;User ID=******;Password=******";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "select employee_id, first_name, last_name, isnull(mobile_phone,'') as mobile_phone, email_address, title, company_name, company_id, office_id, office_address, isnull(office_phone,'') as office_phone, is_active from ******;";
                    //string sql = "select employee_id, first_name, last_name, email_address, title, company_name, from hsa_leadership;";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                LeadershipInfo leadershipInfo = new LeadershipInfo();

                                leadershipInfo.Employee_id = "" + reader.GetInt32(0);
                                leadershipInfo.First_name = reader.GetString(1);
                                leadershipInfo.Last_name = reader.GetString(2);
                                leadershipInfo.Mobile_phone = "" + reader.GetString(3);
                                leadershipInfo.Email_address = reader.GetString(4);
                                leadershipInfo.Title = reader.GetString(5);
                                leadershipInfo.Company_name = reader.GetString(6);
                                leadershipInfo.Company_id = reader.GetString(7);
                                leadershipInfo.Office_id = reader.GetString(8);
                                leadershipInfo.Office_address = reader.GetString(9);
                                leadershipInfo.Office_phone = reader.GetString(10);
                                leadershipInfo.Is_active = reader.GetString(11);

                                listLeadership.Add(leadershipInfo);

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


    public class LeadershipInfo
    {
        public string Employee_id { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public string Mobile_phone { get; set; }
        public string Email_address { get; set; }
        public string Title { get; set; }
        public string Company_name { get; set; }
        public string Company_id { get; set; }
        public string Office_id { get; set; }
        public string Office_address { get; set; }
        public string Office_phone { get; set; }
        public string Is_active { get; set; }
    }
}
