using FrontEnd.ApiModels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class UsuarioHelper : IUsuarioHelper

    {

        IServiceRepository _serviceRepository;

        UsuarioViewModel Convertir(UsuarioAPI usuario)

        {

            return new UsuarioViewModel()

            {

                Id = usuario.Id,

                Nombre = usuario.Nombre,

                Correo = usuario.Correo,

                Contrasena = usuario.Contrasena,

                Telefono = usuario.Telefono

            };

        }



        UsuarioAPI Convertir(UsuarioViewModel usuario)

        {

            return new UsuarioAPI()

            {

                Id = usuario.Id,

                Nombre = usuario.Nombre,

                Correo = usuario.Correo,

                Contrasena = usuario.Contrasena,

                Telefono = usuario.Telefono

            };

        }



        public UsuarioHelper(IServiceRepository serviceRepository)

        {

            _serviceRepository = serviceRepository;

        }

        public UsuarioViewModel Add(UsuarioViewModel usuario)

        {

            HttpResponseMessage responseMessage = _serviceRepository.PostResponse("api/Usuario", usuario);

            if (responseMessage.IsSuccessStatusCode)

            {

                var content = responseMessage.Content.ReadAsStringAsync().Result;

            }

            return usuario;

        }



        public void Delete(int id)

        {

            HttpResponseMessage responseMessage = _serviceRepository.DeleteResponse("api/Usuario/" + id.ToString());

            if (responseMessage != null)

            {

                var content = responseMessage.Content;

            }

        }



        public UsuarioViewModel GetByID(int id)

        {

            HttpResponseMessage responseMessage = _serviceRepository.GetResponse("api/Usuario/" + id.ToString());

            UsuarioAPI usuario = new UsuarioAPI();

            if (responseMessage != null)

            {

                var content = responseMessage.Content.ReadAsStringAsync().Result;

                usuario = JsonConvert.DeserializeObject<UsuarioAPI>(content);

            }

            UsuarioViewModel resultado = Convertir(usuario);


            return resultado;

        }



        public List<UsuarioViewModel> Get()

        {

            HttpResponseMessage responseMessage = _serviceRepository.GetResponse("api/Usuario");

            List<UsuarioAPI> usuarios = new List<UsuarioAPI>();

            if (responseMessage != null)

            {

                var content = responseMessage.Content.ReadAsStringAsync().Result;

                usuarios = JsonConvert.DeserializeObject<List<UsuarioAPI>>(content);

            }

            List<UsuarioViewModel> lista = new List<UsuarioViewModel>();

            foreach (var item in usuarios)

            {

                lista.Add(Convertir(item));

            }

            return lista;

        }



        public UsuarioViewModel Update(UsuarioViewModel usuario)

        {

            HttpResponseMessage responseMessage = _serviceRepository.PutResponse("api/Usuario", Convertir(usuario));

            if (responseMessage != null)

            {

                var content = responseMessage.Content;

            }





            return usuario;

        }

    }
}
