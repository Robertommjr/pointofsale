using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;

namespace PointOfSale.Controllers
{
    public class MapController : Controller
    {
        public MapperConfiguration AutomMapperConfig { get; set; }
        public IMapper Mapper { get; set; }
    }
}