using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prueba2.Data;
using Prueba2.Models;
using System.Threading.Tasks;

namespace Prueba2.Controllers
{
    [Route("articulo")]
    public class ItemController : Controller
    {
        private readonly SupermarketContext _context;

        public ItemController(SupermarketContext context)
        {
            _context = context;
        }

        [Route("insertar")]
        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        [Route("insertar")]
        public async Task<IActionResult> Insert([FromBody]ItemInsertModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Verificar que el código del artículo no esté repetido
                    var item = await _context.Items.FirstOrDefaultAsync(i => i.Code.Equals(model.Code));

                    if (item != null)
                    {
                        return BadRequest("Un artículo con este código ya existe.");
                    }

                    // Insertar el nuevo artículo en la base de datos
                    _context.Items.Add(new Item
                    {
                        Code = model.Code,
                        Name = model.Name,
                        Description = model.Description,
                        Quantity = model.Quantity
                    });

                    // Guardar cambios y volver al inicio
                    await _context.SaveChangesAsync();

                    return Ok(model);
                }
                else
                {
                    return BadRequest("Datos incorrectos.");
                }
            }
            catch (DbUpdateException)
            {
                return BadRequest("Error en base de datos.");
            }
        }

        [Route("modificar")]
        public IActionResult Update()
        {
            return View();
        }

        [HttpPost]
        [Route("modificar")]
        public async Task<IActionResult> Update([FromBody]ItemUpdateModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Verificar que el código del artículo exista
                    var item = await _context.Items.FirstOrDefaultAsync(i => i.Code.Equals(model.Code));

                    if (item == null)
                    {
                        return BadRequest($"No existe ningún artículo con código {model.Code}.");
                    }

                    // Modificar los campos del artículo que se desean modificar
                    if (model.Name != null)
                    {
                        item.Name = model.Name;
                    }

                    if (model.Description != null)
                    {
                        item.Description = model.Description;
                    }

                    if (model.Quantity != null)
                    {
                        item.Quantity = model.Quantity ?? 0;
                    }

                    // Guardar cambios y volver al inicio
                    await _context.SaveChangesAsync();

                    return Ok(model);
                }
                else
                {
                    return BadRequest("Datos incorrectos.");
                }
            }
            catch (DbUpdateException)
            {
                return BadRequest("Error en base de datos.");
            }
        }

        [Route("eliminar")]
        public IActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        [Route("eliminar")]
        public async Task<IActionResult> Delete([FromBody]ItemDeleteModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Verificar que el código del artículo exista
                    var item = await _context.Items.FirstOrDefaultAsync(i => i.Code.Equals(model.Code));

                    if (item == null)
                    {
                        return BadRequest($"No existe ningún artículo con código {model.Code}.");
                    }

                    // Eliminar el artículo de la base de datos
                    _context.Items.Remove(item);

                    // Guardar cambios y volver al inicio
                    await _context.SaveChangesAsync();

                    return Ok(model);
                }
                else
                {
                    return BadRequest("Datos incorrectos.");
                }
            }
            catch (DbUpdateException)
            {
                return BadRequest("Error en base de datos.");
            }
        }
    }
}