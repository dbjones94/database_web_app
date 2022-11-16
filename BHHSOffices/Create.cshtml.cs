using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace HSALeadershipWebApp.Pages.BHHSOffices
{
    [Authorize]
    public class CreateModel : PageModel
    {
        public BHHSofficeInfo bhhsofficeInfo = new BHHSofficeInfo();
        public string errorMessage = "";
        public string successMessage = "";
        public void OnGet()
        {
        }

        public void OnPost()
        {
            bhhsofficeInfo.Company_name = Request.Form["company_name"];
            bhhsofficeInfo.Company_id = Request.Form["company_id"];
            bhhsofficeInfo.Office_name = Request.Form["office_name"];
            bhhsofficeInfo.Office_id = Request.Form["office_id"];
            bhhsofficeInfo.Agent_count = Request.Form["agent_count"];
            bhhsofficeInfo.Is_open = Request.Form["is_open"];
            bhhsofficeInfo.Formatted_address = Request.Form["formatted_address"];
            bhhsofficeInfo.Office_phone_number = Request.Form["office_phone_number"];
            bhhsofficeInfo.Mb_first_name = Request.Form["mb_first_name"];
            bhhsofficeInfo.Mb_last_name = Request.Form["mb_last_name"];
            bhhsofficeInfo.Mb_email_address = Request.Form["mb_email_address"];
            bhhsofficeInfo.Mb_mobile_phone = Request.Form["mb_mobile_phone"];
            bhhsofficeInfo.Mb_id = Request.Form["mb_id"];
            bhhsofficeInfo.Admin_first_name = Request.Form["admin_first_name"];
            bhhsofficeInfo.Admin_last_name = Request.Form["admin_last_name"];
            bhhsofficeInfo.Admin_email_address = Request.Form["admin_email_address"];
            bhhsofficeInfo.Admin_mobile_phone = Request.Form["admin_mobile_phone"];
            bhhsofficeInfo.Admin_id = Request.Form["admin_id"];

            if (bhhsofficeInfo.Company_name.Length == 0 || bhhsofficeInfo.Company_id.Length == 0 || bhhsofficeInfo.Office_name.Length == 0 || bhhsofficeInfo.Office_id.Length == 0 ||
                bhhsofficeInfo.Agent_count.Length == 0 || bhhsofficeInfo.Is_open.Length == 0 || bhhsofficeInfo.Formatted_address.Length == 0 || bhhsofficeInfo.Office_phone_number.Length == 0 ||
                bhhsofficeInfo.Mb_first_name.Length == 0 || bhhsofficeInfo.Mb_last_name.Length == 0 || bhhsofficeInfo.Mb_email_address.Length == 0 || bhhsofficeInfo.Mb_id.Length == 0)
            {
                errorMessage = "All fields except 'admin' fields are required";
                return;
            }

            //save the new RN office info to HSA_BHHS_Office_Roster table
            try
            {
                string connectionString = "Data Source=******;Initial Catalog=******;Persist Security Info=True;User ID=******;Password=******";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "insert into ****** " +
                                 "(Company_name, Company_id, Office_name, Office_id, Agent_count, Is_open, Formatted_address, Office_phone_number, Mb_first_name, Mb_last_name, Mb_email_address, " +
                                 "Mb_mobile_phone, Mb_id, Admin_first_name, Admin_last_name, Admin_email_address, Admin_mobile_phone, Admin_id) values " +
                                 "(@Company_name, @Company_id, @Office_name, @Office_id, @Agent_count, @Is_open, @Formatted_address, @Office_phone_number, @Mb_first_name, @Mb_last_name, @Mb_email_address, " +
                                 "@Mb_mobile_phone, @Mb_id, @Admin_first_name, @Admin_last_name, @Admin_email_address, @Admin_mobile_phone, @Admin_id);";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Company_name", bhhsofficeInfo.Company_name);
                        command.Parameters.AddWithValue("@Company_id", bhhsofficeInfo.Company_id);
                        command.Parameters.AddWithValue("@Office_name", bhhsofficeInfo.Office_name);
                        command.Parameters.AddWithValue("@Office_id", bhhsofficeInfo.Office_id);
                        command.Parameters.AddWithValue("@Agent_count", bhhsofficeInfo.Agent_count);
                        command.Parameters.AddWithValue("@Is_open", bhhsofficeInfo.Is_open);
                        command.Parameters.AddWithValue("@Formatted_address", bhhsofficeInfo.Formatted_address);
                        command.Parameters.AddWithValue("@Office_phone_number", bhhsofficeInfo.Office_phone_number);
                        command.Parameters.AddWithValue("@Mb_first_name", bhhsofficeInfo.Mb_first_name);
                        command.Parameters.AddWithValue("@Mb_last_name", bhhsofficeInfo.Mb_last_name);
                        command.Parameters.AddWithValue("@Mb_email_address", bhhsofficeInfo.Mb_email_address);
                        command.Parameters.AddWithValue("@Mb_mobile_phone", bhhsofficeInfo.Mb_mobile_phone);
                        command.Parameters.AddWithValue("@Mb_id", bhhsofficeInfo.Mb_id);
                        command.Parameters.AddWithValue("@Admin_first_name", bhhsofficeInfo.Admin_first_name);
                        command.Parameters.AddWithValue("@Admin_last_name", bhhsofficeInfo.Admin_last_name);
                        command.Parameters.AddWithValue("@Admin_email_address", bhhsofficeInfo.Admin_email_address);
                        command.Parameters.AddWithValue("@Admin_mobile_phone", bhhsofficeInfo.Admin_mobile_phone);
                        command.Parameters.AddWithValue("@Admin_id", bhhsofficeInfo.Admin_id);

                        command.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception ex)
            {

                errorMessage = ex.Message;
                return;
            }

            bhhsofficeInfo.Company_name = ""; bhhsofficeInfo.Company_id = ""; bhhsofficeInfo.Office_name = ""; bhhsofficeInfo.Office_id = ""; bhhsofficeInfo.Agent_count = ""; bhhsofficeInfo.Is_open = "";
            bhhsofficeInfo.Formatted_address = ""; bhhsofficeInfo.Office_phone_number = ""; bhhsofficeInfo.Mb_first_name = ""; bhhsofficeInfo.Mb_last_name = ""; bhhsofficeInfo.Mb_email_address = "";
            bhhsofficeInfo.Mb_mobile_phone = ""; bhhsofficeInfo.Mb_id = ""; bhhsofficeInfo.Admin_first_name = ""; bhhsofficeInfo.Admin_last_name = ""; bhhsofficeInfo.Admin_email_address = "";
            bhhsofficeInfo.Admin_id = "";
            successMessage = "New Office Saved Correctly!";

            Response.Redirect("/BHHSOffices/Index");

        }
    }
}
