using CadastroDeFornecedores.Data;
using CadastroDeFornecedores.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CadastroDeFornecedores.Controllers
{
    public class FornecedorController : Controller
    {
        private readonly AppCont _appCont;
        public FornecedorController(AppCont appCont)
        {
            _appCont = appCont;
        }
        public IActionResult Index()
        {
            var allTasks = _appCont.Fornecedor.ToList();
            return View(allTasks);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fornecedor = await _appCont.Fornecedor.FirstOrDefaultAsync(mbox => mbox.Id == id);
            if (fornecedor == null)
            {
                return NotFound();
            }

            return View(fornecedor);
        }

        public async Task<IActionResult> DetailsModal(int id)
        {
            var fornecedor = await _appCont.Fornecedor.FirstOrDefaultAsync(mbox => mbox.Id == id);
            return PartialView("_DetailsModal", fornecedor);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarefa = await _appCont.Fornecedor.FirstOrDefaultAsync(mbox => mbox.Id == id);
            if (tarefa == null)
            {
                return NotFound();
            }

            return View(tarefa);
        }
        private bool FornecedorExists(int id)
        {
            return _appCont.Fornecedor.Any(e => e.Id == id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, FornecedorModel fornecedorInput)
        {
            if (id != fornecedorInput.Id)
            {
                return NotFound();
            }

            var fornecedor = await _appCont.Fornecedor.FindAsync(id);
            if (fornecedor == null)
            {
                return NotFound();
            }
            fornecedor.CNPJ = fornecedorInput.CNPJ;
            fornecedor.RazaoSocial = fornecedorInput.RazaoSocial;
            fornecedor.NomeFantasia = fornecedorInput.NomeFantasia;
            fornecedor.Email = fornecedorInput.Email;
            fornecedor.Telefone = fornecedorInput.Telefone;
            fornecedor.NomePessoaContato = fornecedorInput.NomePessoaContato;
            fornecedor.CEP = fornecedorInput.CEP;
            fornecedor.Rua = fornecedorInput.Rua;
            fornecedor.Complemento = fornecedorInput.Complemento;
            fornecedor.Numero = fornecedorInput.Numero;
            fornecedor.Bairro = fornecedorInput.Bairro;
            fornecedor.Municipio = fornecedorInput.Municipio;
            fornecedor.Estado = fornecedorInput.Estado;

            try
            {
                _appCont.Update(fornecedor);
                await _appCont.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FornecedorExists(fornecedor.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToAction(nameof(Index));
        }



        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FornecedorModel fornecedor)
        {
            if (ModelState.IsValid)
            {
                _appCont.Add(fornecedor);
                await _appCont.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fornecedor);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fornecedor = await _appCont.Fornecedor.FirstOrDefaultAsync(m => m.Id == id);
            if (fornecedor == null)
            {
                return NotFound();
            }
            return View(fornecedor);

        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fornecedor = await _appCont.Fornecedor.FindAsync(id);
            _appCont.Fornecedor.Remove(fornecedor);
            await _appCont.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
