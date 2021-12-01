using Kontroleri.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;

namespace Kontroleri.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    { 

        [HttpPost]
        public void Foo(Osoba o)
        {
            System.IO.File.AppendAllText("osobe.txt", $"{o.Ime} {o.Prezime}"
                + Environment.NewLine);
        }

        [HttpGet]
        public List<Osoba> Osobeee()
        {
            List<Osoba> ol = new();
            foreach(string linija in System.IO.File.ReadLines("osobe.txt"))
            {
                string[] imeIprezime = linija.Split(' ');
                ol.Add(new Osoba { Ime = imeIprezime[0], Prezime = imeIprezime[1] });
            }
            return ol;
        }
    }
}
