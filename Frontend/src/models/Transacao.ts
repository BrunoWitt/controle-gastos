export type TipoTransacao =
    "Receita" | "Despesa";


export interface Transacao {

    id:number;

    descricao:string;

    valor:number;

    tipo:TipoTransacao;

    pessoaId:number;

}