import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { map, Observable } from 'rxjs';
import { itemMovimentado } from '../../../models/itemMovimentado';
import { MovimentacaoService } from '../../../core/services/movimentacao.service';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-exibir-itens',
  standalone: true,
  imports: [CommonModule, MatIconModule],
  templateUrl: './exibir-itens.component.html',
  styleUrl: './exibir-itens.component.css'
})
export class ExibirItensComponent {
  itens$?: Observable<itemMovimentado[]>;
  insumos?: Observable<itemMovimentado[]>
  quimicos?: Observable<itemMovimentado[]>
  constructor(private route: ActivatedRoute, private movimentacaoService: MovimentacaoService){
    this.carregarItens()
  }

  carregarItens(){
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.itens$ = this.movimentacaoService.listarItensMovimentados(id);
    
    this.quimicos = this.itens$.pipe(map( item => item.filter(i => i.produtoQuimico)));
    this.insumos = this.itens$.pipe(map(item => item.filter(i => !i.produtoQuimico)));
  }
}
