using IronPdf;
using Imob.Models;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using System;

namespace Imob.Utils
{
    public class GeradorDePDFUtils
    {
        private IWebHostEnvironment _hosting;
        public GeradorDePDFUtils(IWebHostEnvironment hosting)
        {
            _hosting = hosting;
        }
        public string GetPdf(Contrato contrato)
        {
            var Renderer = new HtmlToPdf();
            var nomeArquivo = new Random().Next();
            Renderer.RenderHtmlAsPdf("" + 
                                     "<h1>Contrato de locação - Imob</h1>" +
                                     "<br><h4>LOCATARIO: "+ contrato.Locatario.Nome+"</h4>"+
                                     "<br><h4>CORRETOR: " + contrato.Corretor.Nome + "</h4>"+
                                     "<br><h4>ENDEREÇO DE IMÓVEL: " + contrato.Imovel.Endereco+','+ contrato.Imovel.Cidade+','+ contrato.Imovel.UF+"</h4>"+
                                     "<br><h4>VALOR DO ALUGUEL: " + contrato.Imovel.ValorAluguel+"</h4>"+
                                     "<br><br><br><br><br><br><h4>ASSINATURAS: </h4>"+
                                     "<br><h4>"+ contrato.Locatario.Nome+ ":______________________________ </h4>" +
                                     "<br><h4>" + contrato.Corretor.Nome+ ":______________________________</h4>"
                                     
                                     + "<style></style>")
                .SaveAs(_hosting.WebRootPath + $"\\Contratos\\{nomeArquivo}.pdf");
            return nomeArquivo + ".pdf";
        }
    }
}
