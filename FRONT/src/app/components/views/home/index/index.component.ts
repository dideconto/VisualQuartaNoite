import { ItemVenda } from "./../../../../models/item-venda";
import { Router } from "@angular/router";
import { Component, OnInit } from "@angular/core";
import { ProdutoService } from "src/app/services/produto.service";
import { Produto } from "src/app/models/produto";

@Component({
    selector: "app-index",
    templateUrl: "./index.component.html",
    styleUrls: ["./index.component.css"],
})
export class IndexComponent implements OnInit {
    produtos!: Produto[];
    itens: ItemVenda[] = [];

    constructor(
        private produtoService: ProdutoService,
        private router: Router
    ) {}

    ngOnInit(): void {
        this.produtoService.list().subscribe((produtos) => {
            this.produtos = produtos;
            this.itens = JSON.parse(localStorage.getItem("itens")!) || [];
        });
    }

    adicionar(produto: Produto): void {
        let item: ItemVenda = {
            produto: produto,
            produtoId: produto.id!,
            quantidade: 1,
            preco: produto.preco,
        };
        this.itens.push(item);
        localStorage.setItem("itens", JSON.stringify(this.itens));
        this.router.navigate(["/home/carrinho"]);
    }
}
