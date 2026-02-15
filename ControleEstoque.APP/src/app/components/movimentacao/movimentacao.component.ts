import { Component } from '@angular/core';
import { map, Observable } from 'rxjs';
import { CommonModule } from '@angular/common';
import { movimentacao } from '../../models/movimentacao';
import { MovimentacaoService } from '../../core/services/movimentacao.service';

@Component({
  selector: 'app-movimentacao',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './movimentacao.component.html',
  styleUrl: './movimentacao.component.css'
})
export class MovimentacaoComponent {
movimentacoes$!: Observable<movimentacao[]>;

  constructor(private movimentacaoService: MovimentacaoService) {
    this.getMovimentacoes();
  }

  getMovimentacoes(){
    this.movimentacoes$ = this.movimentacaoService.getMovimentacao();
  }
}
