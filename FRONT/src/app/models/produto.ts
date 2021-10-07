import { Categoria } from "./categoria";

export interface Produto {
    id?: number;
    nome: string;
    descricao: string;
    preco: number;
    quantidade: number;
    criadoem?: string;
    categoria?: Categoria;
    categoriaId: number;
}
