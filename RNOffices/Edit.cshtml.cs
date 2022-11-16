using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;

namespace HSALeadershipWebApp.Pages.RNOffices
{
    [Authorize]
    public class EditModel : PageModel
    {
        public RNofficeInfo rnofficeInfo = new RNofficeInfo();
        public string errorMessage = "";
        public string successMessage = "";
        public void OnGet()
        {
            string id = Request.Query["id"];

            try
            {
                string connectionString = "Data Source=******;Initial Catalog=******;Persist Security Info=True;User ID=******;Password=******";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "select company_name, company_id, office_name, office_id, agent_count, is_open, formatted_address, isnull(office_phone_number,'') as office_phone_number, " +
                                 "isnull(mb_first_name,'') as mb_first_name, isnull(mb_last_name,'') as mb_last_name, isnull(mb_email_address,'') as mb_email_address, isnull(mb_mobile_phone,'') as mb_mobile_phone, " +
                                 "isnull(mb_id,'') as mb_id, isnull(admin_first_name,'') as admin_first_name, isnull(admin_last_name,'') as admin_last_name, isnull(admin_email_address,'') as admin_email_address, " +
                                 "isnull(admin_mobile_phone,'') as admin_mobile_phone, isnull(admin_id,'') as admin_id from ****** where office_id=@id;";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
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
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                errorMessage = ex.Message;
            }
        }

        public void OnPost()
        {
            rnofficeInfo.Company_name = Request.Form["company_name"];
            rnofficeInfo.Company_id = Request.Form["company_id"];
            rnofficeInfo.Office_name = Request.Form["office_name"];
            rnofficeInfo.Office_id = Request.Form["office_id"];
            rnofficeInfo.Agent_count = Request.Form["agent_count"];
            rnofficeInfo.Is_open = Request.Form["is_open"];
            rnofficeInfo.Formatted_address = Request.Form["formatted_address"];
            rnofficeInfo.Office_phone_number = Request.Form["office_phone_number"];
            rnofficeInfo.Mb_first_name = Request.Form["mb_first_name"];
            rnofficeInfo.Mb_last_name = Request.Form["mb_last_name"];
            rnofficeInfo.Mb_email_address = Request.Form["mb_email_address"];
            rnofficeInfo.Mb_mobile_phone = Request.Form["mb_mobile_phone"];
            rnofficeInfo.Mb_id = Request.Form["mb_id"];
            rnofficeInfo.Admin_first_name = Request.Form["admin_first_name"];
            rnofficeInfo.Admin_last_name = Request.Form["admin_last_name"];
            rnofficeInfo.Admin_email_address = Request.Form["admin_email_address"];
            rnofficeInfo.Admin_mobile_phone = Request.Form["admin_mobile_phone"];
            rnofficeInfo.Admin_id = Request.Form["admin_id"];

            if (rnofficeInfo.Company_name.Length == 0 || rnofficeInfo.Company_id.Length == 0 || rnofficeInfo.Office_name.Length == 0 || rnofficeInfo.Office_id.Length == 0 ||
                rnofficeInfo.Agent_count.Length == 0 || rnofficeInfo.Is_open.Length == 0 || rnofficeInfo.Formatted_address.Length == 0 || rnofficeInfo.Office_phone_number.Length == 0 ||
                rnofficeInfo.Mb_first_name.Length == 0 || rnofficeInfo.Mb_last_name.Length == 0 || rnofficeInfo.Mb_email_address.Length == 0 || rnofficeInfo.Mb_id.Length == 0)
            {
                errorMessage = "All fields except 'admin' fields are required";
                return;
            }

            try
            {
                string connectionString = "Data Source=******;Initial Catalog=******;Persist Security Info=True;User ID=******;Password=******";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "update ****** " +
                                 "set company_name=@Company_name, company_id=@Company_id, office_name=@Office_name, office_id=@Office_id, agent_count=@Agent_count, is_open=@Is_open, " +
                                 "formatted_address=@Formatted_address, office_phone_number=@Office_phone_number, mb_first_name=@Mb_first_name, mb_last_name=@Mb_last_name, mb_email_address=@Mb_email_address, " +
                                 "mb_mobile_phone=@Mb_mobile_phone, mb_id=@Mb_id, admin_first_name=@Admin_first_name, admin_last_name=@Admin_last_name, admin_email_address=@Admin_email_address, " +
                                 "admin_mobile_phone=@Admin_mobile_phone, admin_id=@Admin_id where office_id=@Office_id";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Company_name", rnofficeInfo.Company_name);
                        command.Parameters.AddWithValue("@Company_id", rnofficeInfo.Company_id);
                        command.Parameters.AddWithValue("@Office_name", rnofficeInfo.Office_name);
                        command.Parameters.AddWithValue("@Office_id", rnofficeInfo.Office_id);
                        command.Parameters.AddWithValue("@Agent_count", rnofficeInfo.Agent_count);
                        command.Parameters.AddWithValue("@Is_open", rnofficeInfo.Is_open);
                        command.Parameters.AddWithValue("@Formatted_address", rnofficeInfo.Formatted_address);
                        command.Parameters.AddWithValue("@Office_phone_number", rnofficeInfo.Office_phone_number);
                        command.Parameters.AddWithValue("@Mb_first_name", rnofficeInfo.Mb_first_name);
                        command.Parameters.AddWithValue("@Mb_last_name", rnofficeInfo.Mb_last_name);
                        command.Parameters.AddWithValue("@Mb_email_address", rnofficeInfo.Mb_email_address);
                        command.Parameters.AddWithValue("@Mb_mobile_phone", rnofficeInfo.Mb_mobile_phone);
                        command.Parameters.AddWithValue("@Mb_id", rnofficeInfo.Mb_id);
                        command.Parameters.AddWithValue("@Admin_first_name", rnofficeInfo.Admin_first_name);
                        command.Parameters.AddWithValue("@Admin_last_name", rnofficeInfo.Admin_last_name);
                        command.Parameters.AddWithValue("@Admin_email_address", rnofficeInfo.Admin_email_address);
                        command.Parameters.AddWithValue("@Admin_mobile_phone", rnofficeInfo.Admin_mobile_phone);
                        command.Parameters.AddWithValue("@Admin_id", rnofficeInfo.Admin_id);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

                errorMessage = ex.Message;
                return;
            }

            Response.Redirect("/RNOffices/Index");
        }
    }
}
