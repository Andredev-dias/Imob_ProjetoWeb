using IronPdf;
using LocadoraDeImoveis.Models;
using System.IO;
using System.Reflection;

namespace Imob.Utils
{
    class GeradorDeCpfUtils
    { 

        public static void GetPdf(Contrato contrato)
        {
            var PathDestino = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var Renderer = new HtmlToPdf();
            Renderer.RenderHtmlAsPdf("<h1>Contrato de locação residencial</h1>" +
                                     "<br><h4>Locatario: "+ contrato.Locatario.Nome+"</h4>"+
                                     "<br><h4>Corretor: " + contrato.Corretor.Nome + "</h4>"+
                                     "<br><h4>Endereço do Imóvel: " + contrato.Imovel.Endereco+','+ contrato.Imovel.Cidade+','+ contrato.Imovel.UF+"</h4>"+
                                     "<br><h4>Valor do Aluguel: " + contrato.Imovel.ValorAluguel+"</h4>"+
                                     "<br><br><br><br><br><br><h4>Assinaturas </h4>"+
                                     "<br><h4>"+ contrato.Locatario.Nome+":______________________________"+
                                     "<br><h4>"+ contrato.Corretor.Nome+":______________________________")
                .SaveAs(PathDestino.ToString()+$"..\\..\\..\\..\\ContratosPDF\\{contrato.Id+ contrato.Locatario.Nome}.pdf");
        }
    }
}
