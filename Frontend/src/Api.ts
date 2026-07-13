import axios from "axios";


const api = axios.create({
//Configuração da instância do Axios para fazer requisições HTTP para o Backend.
//URL localhost por teste
    baseURL:
        "http://localhost:5130/api"

});


export default api;