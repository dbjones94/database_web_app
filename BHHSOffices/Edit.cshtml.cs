using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;

namespace HSALeadershipWebApp.Pages.BHHSOffices
{
    [Authorize]
    public class EditModel : PageModel
    {
        public BHHSofficeInfo bhhsofficeInfo = new BHHSofficeInfo();
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

            Response.Redirect("/BHHSOffices/Index");
        }
    }
}
