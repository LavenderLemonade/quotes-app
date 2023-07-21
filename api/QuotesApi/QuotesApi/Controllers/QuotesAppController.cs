using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace QuotesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesAppController : ControllerBase
    {
        private IConfiguration _configuration;

        public QuotesAppController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("GetQuotes")]
        public JsonResult GetQuotes()
        {
            string query = "SELECT * FROM abby_quotes";
            DataTable table = new DataTable();

            string sqlDataSource = _configuration.GetConnectionString("quotesAppDBConn");

            SqlDataReader myReader;
            using(SqlConnection myCon = new SqlConnection(sqlDataSource)) 
            { 
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }

            }

            return new JsonResult(table);
        }
    }
}
