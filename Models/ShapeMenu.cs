using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlPack.Models
{
    //Supporting items
    public enum ShapeType
    {
        tetrahedron,
        cube,
        pentagon,
        octahedron,
        dodecahedron,
        icosahedron
    }
    public enum TextureType
    {
        flat,
        image,
        live,
        stipple,
        water
    }

    public class FaceParam
    {
        public int Id { get; set; }
        public string FaceName { get; set; }
        public bool Protected { get; set; }
        public string ControllerActionName { get; set; }
        public object IdValue { get; set; }
        public string TexturePath { get; set; }
        public TextureType TextureType { get; set; }
        public string JsCall { get; set; }

    }

    public class ShapeMenu
    {
        public List<FaceParam> Faces { get; set; }
        public string InitialFace { get; set; }
        public ShapeType ShapeType { get; set; }
        public double Zoom { get; set; }
        public double Speed { get; set; }
    }

}