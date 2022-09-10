using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using SGEFront.Models;
using SGEFront.Util;

namespace SGEFront.Service
{
    public class FuncionarioService
    {
        static RestApi restApi = new RestApi();
        HttpClient baseUrl = new HttpClient();


        public List<Funcionario> ListarFuncionarios()
        {

            baseUrl = restApi.BaseUrl();

            try
            {

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(String.Format(baseUrl.BaseAddress + restApi.ListarFuncionarios));
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "GET";

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {

                    var retorno = JsonConvert.DeserializeObject<List<Funcionario>>(streamReader.ReadToEnd());

                    if (retorno != null)
                    {
                        return retorno;
                    }
                }
            }
            catch
            {
                throw new Exception("Erro ao pesquisar os funcionarioes!");
            }

            return null;

        }

        //Chamada do método que busca funcionario por id
        public Funcionario BuscarFuncionario(int id)
        {
            baseUrl = restApi.BaseUrl();

            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(string.Format(baseUrl.BaseAddress + restApi.BuscarFuncionario, id));
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "GET";

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var retorno = JsonConvert.DeserializeObject<Funcionario>(streamReader.ReadToEnd());

                    if (retorno != null)
                    {
                        return retorno;
                    }

                }

            }
            catch
            {
                throw new Exception("Erro ao pesquisar o funcionario!");
            }

            return null;
        }

        public Funcionario IncluirFuncionario(Funcionario funcionario)
        {
            baseUrl = restApi.BaseUrl();

            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(String.Format(baseUrl.BaseAddress + restApi.SalvarFuncionario));

                httpWebRequest.Method = "POST";
                httpWebRequest.ContentType = "application/json";
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    string json = serializer.Serialize(funcionario);
                    streamWriter.Write(json);
                    streamWriter.Flush();
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var retorno = JsonConvert.DeserializeObject<Funcionario>(streamReader.ReadToEnd());


                    if (retorno != null)
                    {
                        return retorno;
                    }
                }
            }
            catch
            {
                throw new Exception("Erro ao cadastrar o candidato!");
            }

            return null;
        }

        //Chamada do método que edita um funcionario
        public Funcionario EditarFuncionario(int id, Funcionario funcionario)
        {
            baseUrl = restApi.BaseUrl();

            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(String.Format(baseUrl.BaseAddress + restApi.EditarFuncionario, id));

                httpWebRequest.Method = "PUT";
                httpWebRequest.ContentType = "application/json";
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    string json = serializer.Serialize(funcionario);
                    streamWriter.Write(json);
                    streamWriter.Flush();
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var retorno = JsonConvert.DeserializeObject<Funcionario>(streamReader.ReadToEnd());

                    if (retorno != null)
                    {
                        return retorno;
                    }
                }
            }
            catch
            {
                throw new Exception("Erro ao editar o funcionario!");
            }

            return null;
        }

        //Chamada do método que exclui um funcionario
        public Funcionario ExcluirFuncionario(int id)
        {
            baseUrl = restApi.BaseUrl();

            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(string.Format(baseUrl.BaseAddress + restApi.DeletarFuncionario, id));
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "DELETE";

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var retorno = JsonConvert.DeserializeObject<Funcionario>(streamReader.ReadToEnd());

                    if (retorno != null)
                    {
                        return retorno;
                    }

                }
            }
            catch
            {
                throw new Exception("Erro ao excluir o funcionario!");
            }

            return null;
        }

    }
}
