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
    public class CursoService
    {
        static RestApi restApi = new RestApi();
        HttpClient baseUrl = new HttpClient();

        public List<Curso> ListarCursos()
        {

            baseUrl = restApi.BaseUrl();
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(String.Format(baseUrl.BaseAddress + restApi.ListarCursos));
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "GET";



                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var retorno = JsonConvert.DeserializeObject<List<Curso>>(streamReader.ReadToEnd());

                    if (retorno != null)
                    {
                        return retorno;
                    }
                }

            }
            catch
            {

                throw new Exception("Erro ao pesquisar os alunos!");
            }

            return null;
        }

        //ttt
        public Curso BuscarCurso(int id)
        {
            baseUrl = restApi.BaseUrl();

            try
            {

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(string.Format(baseUrl.BaseAddress + restApi.BuscarCurso, id));
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "GET";

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    bvar retorno = JsonConvert.DeserializeObject<Curso>(streamReader.ReadToEnd());

                    if (retorno != null)
                    {
                        return retorno;
                    }
                }
            }
            catch
            {
                throw new Exception("Erro ao pesquisar o Curso!");
            }

            return null;
        }

        public Curso IncluirCurso(Curso curso)
        {
            baseUrl = restApi.BaseUrl();

            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(String.Format(baseUrl.BaseAddress + restApi.SalvarCurso));

                httpWebRequest.Method = "POST";
                httpWebRequest.ContentType = "application/json";
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    string json = serializer.Serialize(curso);
                    streamWriter.Write(json);
                    streamWriter.Flush();
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var retorno = JsonConvert.DeserializeObject<Curso>(streamReader.ReadToEnd());


                    if (retorno != null)
                    {
                        return retorno;
                    }
                }
            }
            catch
            {
                throw new Exception("Erro ao cadastrar o aluno!");
            }

            return null;
        }

        public Curso EditarCurso(int id, Curso curso)
        {
            baseUrl = restApi.BaseUrl();

            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(String.Format(baseUrl.BaseAddress + restApi.EditarCurso, id));

                httpWebRequest.Method = "PUT";
                httpWebRequest.ContentType = "application/json";
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    string json = serializer.Serialize(curso);
                    streamWriter.Write(json);
                    streamWriter.Flush();
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var retorno = JsonConvert.DeserializeObject<Curso>(streamReader.ReadToEnd());

                    if (retorno != null)
                    {
                        return retorno;
                    }
                }
            }
            catch
            {
                throw new Exception("Erro ao editar o curso!");
            }

            return null;
        }




        public Curso ExcluirCurso(int id)
        {
            baseUrl = restApi.BaseUrl();

            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(string.Format(baseUrl.BaseAddress + restApi.DeletarCurso, id));
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "DELETE";

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var retorno = JsonConvert.DeserializeObject<Curso>(streamReader.ReadToEnd());

                    if (retorno != null)
                    {
                        return retorno;
                    }

                }
            }
            catch
            {
                throw new Exception("Erro ao excluir o aluno!");
            }

            return null;
        }


    }



}