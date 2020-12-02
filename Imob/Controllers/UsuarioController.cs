using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Imob.Models;
using Microsoft.AspNetCore.Authorization;

namespace Imob.Controllers
{
    //[Authorize(Roles = "ADMIN")]
    [Authorize]
    public class UsuarioController : Controller
    {
        private readonly Context _context;
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UsuarioController(Context context,
            UserManager<Usuario> userManager,
            SignInManager<Usuario> signInManager,
            RoleManager<IdentityRole> roleManager
            )
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        // GET: Usuario
        public async Task<IActionResult> ListaUsuarios()
        {
            return View(await _context.UsuarioLogado.ToListAsync());
        }
        // GET: Usuario/Create
        public IActionResult CadastrarUsuario()
        {
            return View();
        }

        // POST: Usuario/CadastrarUsuario
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CadastrarUsuario([Bind("Email,Senha,Id,CriadoEm,ConfirmacaoSenha")] UsuarioLogado usuarioLogado)
        {
            if (ModelState.IsValid)
            {
                Usuario usuario = new Usuario
                {
                    UserName = usuarioLogado.Email,
                    Email = usuarioLogado.Email
                };

                IdentityResult result = await _userManager.CreateAsync(usuario, usuarioLogado.Senha);
                var token = _userManager.GenerateEmailConfirmationTokenAsync(usuario);
                if (result.Succeeded)
                {
                    _context.Add(usuarioLogado);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(ListaUsuarios));
                }
                AdicionarErros(result);
            }
            return View(usuarioLogado);
        }

        public void AdicionarErros(IdentityResult result)
        {
            foreach (IdentityError erro in result.Errors)
            {
                ModelState.AddModelError("", erro.Description);
            }
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Index([Bind("Email, Senha")] UsuarioLogado usuarioLogado)
        {
            var result = await _signInManager.PasswordSignInAsync(usuarioLogado.Email, usuarioLogado.Senha, false, false);

            if (result.Succeeded)
            {
                return RedirectToAction("InicialMenu", "Home");
            }
            ModelState.AddModelError("", "Login ou senha inválidos!");
            return View(usuarioLogado);
        }

        //[Authorize(Roles = "USERS")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Usuario");
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CriarRole role)
        {
            if(ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name = role.RoleName
                };
                IdentityResult identityResult = await _roleManager.CreateAsync(identityRole);

                if (identityResult.Succeeded)
                {
                    return RedirectToAction("ListaUsuarios", "Usuario");
                }

                foreach(IdentityError error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(role);
        }
    }
}
