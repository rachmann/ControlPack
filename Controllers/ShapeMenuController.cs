using System.Configuration;
using ControlPack.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlPack.Controllers
{
    public class ShapeMenuController : Controller
    {

        public IDbConnection GetOpenConnection(string connection)
        {
            var dbConnection = new SqlConnection(connection);
            dbConnection.Open();
            return dbConnection;
        }

        // GET: ShapeMenu
        public ActionResult Index(string id = null)
        {
            var uriMe = HttpContext.Request.Url;
            var formatString = "{0}://{1}:{2}{3}";
            var imageBasePath = String.Format(formatString, uriMe.Scheme, uriMe.Host, uriMe.Port, uriMe.Segments[0]);
            if (uriMe.Port == 80)
            {
                formatString = "{0}://{1}{2}";
                imageBasePath = String.Format(formatString, uriMe.Scheme, uriMe.Host, uriMe.Segments[0]);
            }

            using (var conn = GetOpenConnection(ConfigurationManager.AppSettings["DefaultConnection"]))
            {
                var faces = conn.Query<FaceParam>("select * from FaceParam");

            }
            
            var model = new ShapeMenu
            {
                InitialFace = "Login",
                ShapeType = ShapeType.cube,
                Speed = 1,
                Zoom = 1,
                Faces = new List<FaceParam>
                {
                    new FaceParam{ FaceName = "Login", ControllerActionName = "Account~Login", Protected = false, TextureType = TextureType.image, TexturePath  =  "~/Content/ControlPack/login.jpg"},
                    new FaceParam{ FaceName = "Statistics", ControllerActionName = "System~PublicStatistics", Protected = false, TextureType = TextureType.live, TexturePath = "#dd22ae"},
                    new FaceParam{ FaceName = "Welcome", ControllerActionName = "Home~Index", Protected = false, TextureType = TextureType.flat, TexturePath = "#dd22ae"},
                    new FaceParam{ FaceName = "Welcome", ControllerActionName = "Home~Index", Protected = false, TextureType = TextureType.flat, TexturePath = "#22ddae"},
                    new FaceParam{ FaceName = "Welcome", ControllerActionName = "Home~Index", Protected = false, TextureType = TextureType.flat, TexturePath = "#ddse22"},
                    new FaceParam{ FaceName = "Welcome", ControllerActionName = "Home~Index", Protected = false, TextureType = TextureType.flat, TexturePath = "#aedd22"}
                }
            };
            return View(model);
        }
    }
}