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
    public class AdministradorService
    {
            static RestApi restApi = new RestApi();
            HttpClient baseUrl = new HttpClient();


            public List<Administrador> ListarAdministradores()
            {

                baseUrl = restApi.BaseUrl();

                try
                {

                    var httpWebRequest = (HttpWebRequest)WebRequest.Create(String.Format(baseUrl.BaseAddress + restApi.ListarAdministradores));
                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.Method = "GET";

                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {

                        var retorno = JsonConvert.DeserializeObject<List<Administrador>>(streamReader.ReadToEnd());

                        if (retorno != null)
                        {
                            return retorno;
                        }
                    }
                }
                catch
                {
                    throw new Exception("Erro ao pesquisar os administradores!");
                }

                return null;

            }

            //Chamada do método que busca administrador por id
            public Administrador BuscarAdministrador(int id)
            {
                baseUrl = restApi.BaseUrl();

                try
                {
                    var httpWebRequest = (HttpWebRequest)WebRequest.Create(string.Format(baseUrl.BaseAddress + restApi.BuscarAdministrador, id));
                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.Method = "GET";

                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var retorno = JsonConvert.DeserializeObject<Administrador>(streamReader.ReadToEnd());

                        if (retorno != null)
                        {
                            return retorno;
                        }

                    }

                }
                catch
                {
                    throw new Exception("Erro ao pesquisar o administrador!");
                }

                return null;
            }

            public Administrador IncluirAdministrador(Administrador administrador)
            {
                baseUrl = restApi.BaseUrl();

                try
                {
                    var httpWebRequest = (HttpWebRequest)WebRequest.Create(String.Format(baseUrl.BaseAddress + restApi.SalvarAdministrador));

                    httpWebRequest.Method = "POST";
                    httpWebRequest.ContentType = "application/json";
                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        JavaScriptSerializer serializer = new JavaScriptSerializer();
                        string json = serializer.Serialize(administrador);
                        streamWriter.Write(json);
                        streamWriter.Flush();
                    }
                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var retorno = JsonConvert.DeserializeObject<Administrador>(streamReader.ReadToEnd());


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

            //Chamada do método que edita um administrador
            public Administrador EditarAdministrador(int id, Administrador administrador)
            {
                baseUrl = restApi.BaseUrl();

                try
                {
                    var httpWebRequest = (HttpWebRequest)WebRequest.Create(String.Format(baseUrl.BaseAddress + restApi.EditarAdministrador, id));

                    httpWebRequest.Method = "PUT";
                    httpWebRequest.ContentType = "application/json";
                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        JavaScriptSerializer serializer = new JavaScriptSerializer();
                        string json = serializer.Serialize(administrador);
                        streamWriter.Write(json);
                        streamWriter.Flush();
                    }
                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var retorno = JsonConvert.DeserializeObject<Administrador>(streamReader.ReadToEnd());

                        if (retorno != null)
                        {
                            return retorno;
                        }
                    }
                }
                catch
                {
                    throw new Exception("Erro ao editar o administrador!");
                }

                return null;
            }

            //Chamada do método que exclui um administrador
            public Administrador ExcluirAdministrador(int id)
            {
                baseUrl = restApi.BaseUrl();

                try
                {
                    var httpWebRequest = (HttpWebRequest)WebRequest.Create(string.Format(baseUrl.BaseAddress + restApi.DeletarAdministrador, id));
                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.Method = "DELETE";

                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var retorno = JsonConvert.DeserializeObject<Administrador>(streamReader.ReadToEnd());

                        if (retorno != null)
                        {
                            return retorno;
                        }

                    }
                }
                catch
                {
                    throw new Exception("Erro ao excluir o administrador!");
                }

                return null;
            }

        }
    }
