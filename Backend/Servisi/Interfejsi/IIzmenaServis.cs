using Microsoft.AspNetCore.Mvc;

namespace Backend.Servisi.Interfejsi
{
    public interface IIzmenaServis
    {
        IActionResult OporaviObrisaniMaterijal();
        IActionResult PrikaziIzmene();
        IActionResult DodajIzmenu();
        IActionResult PrikaziIzmeneBrisanja();
        IActionResult ObrisiIzmenu();
    }
}