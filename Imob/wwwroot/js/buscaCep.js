var btnCep = document.getElementById("btn-CEP");
var inputCidade = document.getElementById("cidade");
var inputUF = document.getElementById("UF");
var inputRua = document.getElementById("rua");

var url = "";

btnCep.addEventListener("click", (event) => {
    event.preventDefault();
    var inputCep = document.getElementById("cep");
    var CepDigitado = inputCep.value;

    url = "https://viacep.com.br/ws/" + CepDigitado + "/json/";

    buscarCep();
});

const buscarCep = () => {
    fetch(url, { method: "GET" })
        .then(response => response.json())
        .then(json => {
            console.log(json);
            console.log(json.logradouro);

            inputCidade.value = json.localidade;
            inputUF.value = json.uf;
            inputRua.value = json.logradouro;
        })
        .catch(error => console.log(error));
}
